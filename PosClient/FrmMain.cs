using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PosClient
{
    public partial class FrmMain : Form
    {

        IPAddress ip = null;//인자값 : 서버측 IP
        IPEndPoint endPoint = null;//인자값 : IPAddress,포트번호
        Socket socket = null;   //Tcp Socket


        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtInput.Clear();
                TestTranData();
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog(ClsLog.LOG_EXCEPTION, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void SocketProcess()
        {
            String sData = null;
            String sRevData = null;
            byte[] sendBuffer = null;
            byte[] receiveBuffer = new byte[1024];
            try
            {
                ip = IPAddress.Parse("127.0.0.1");//인자값 : 서버측 IP
                endPoint = new IPEndPoint(ip, 8000);//인자값 : IPAddress,포트번호

                //2. Tcp Socket 생성
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                //3. 접속
                socket.Connect(endPoint);

                //4. 데이터
                sData = txtInput.Text;
                sendBuffer = Encoding.UTF8.GetBytes(sData);//전송할 데이터를 인코딩,,인자값 : 전송할 데이터

                //5. 전송
                socket.Send(sendBuffer);

                //6. 결과받기
                int iLength = socket.Receive(receiveBuffer, receiveBuffer.Length, SocketFlags.None);

                //8. 디코딩&출력&서비스처리
                sRevData = Encoding.UTF8.GetString(receiveBuffer, 0, iLength);
                //Console.WriteLine("받은 데이터 : " + sRevData.Substring(40));
                txtView.Clear();
                txtView.Text = sRevData;

                //9. 닫기
                socket.Close();
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog(ClsLog.LOG_EXCEPTION, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnDummy_Click(object sender, EventArgs e)
        {
            String sInput = null;
            try
            {
                sInput = ReplaceAtPosition(txtInput.Text, 9, "4");
                txtInput.Text = sInput;
                Console.WriteLine("txtInput >>>> " + txtInput.Text);
                SocketProcess();
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog(ClsLog.LOG_EXCEPTION, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnTran_Click(object sender, EventArgs e)
        {
            try
            {
                TestTranData();
                SocketProcess();
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog(ClsLog.LOG_EXCEPTION, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void btnInq_Click(object sender, EventArgs e)
        {
            try
            {
                TestInqData();
                SocketProcess();
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog(ClsLog.LOG_EXCEPTION, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                ClsLog.WriteLog(ClsLog.LOG_EXCEPTION, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void TestTranData()
        {
            string sDate = null;
            DateTime dtNow;
            String tranNo = "0001";
            String sSysDate = null;
            String sSysTime = null;

            try
            {
                dtNow = DateTime.Now;
                sDate = dtNow.ToString("yyyyMMdd");
                sSysDate = dtNow.ToString("yyyyMMdd");
                sSysTime = dtNow.ToString("HHmmss");
                String sData =                 /* 
                                                * 통신 헤더 (40)
                                                */
                                  "000188" +                        //전문길이  (6)
                                  "PS" +                            //전문경로  (2)

                                  "00" +                            //전문구분  (2) - 00:TRAN,01:CARD INQ,02:POS INQ,03:JOURNAL,04:DUMMY

                                  "00" +                            //전문종별  (2)
                                  "0001" +                          //전문순번  (4)
                                  "0001" +                          //점포번호  (4) 
                                  "0001" +                          //포스번호  (4)
                                  tranNo +                          //거래번호  (4)
                                  sDate +                           //영업일자  (8)
                                  "0000" +                          //에러코드  (4)
                                              /*
                                               * Tran 헤더 (148)
                                               */
                                  "000188" +                        //전문길이  (6)
                                  "0001" +                          //점포번호  (4)
                                  "0001" +                          //포스번호  (4)
                                  tranNo +                          //거래번호  (4)
                                  sDate +                           //영업일자  (8)
                                  sSysDate +                        //시스템일자(8)
                                  sSysTime +                        //시스템시각(6)
                                  "00" +                            //거래구분  (2)
                                  "00" +                            //거래종별  (2)
                                  "100000" +                        //캐셔번호  (6)
                                  sDate +                           //원거래일자(8)
                                  "0001" +                          //원포스번호(4)
                                  tranNo +                          //원거래번호(4)
                                  "100000" +                        //원캐셔번호(6)
                                  "000001000" +                     //총 매출   (9)
                                  "000000000" +                     //총 할인   (9)
                                  "000000000" +                     //총 에누리 (9)
                                  "1" +                             //현금 구분 (1)
                                  "0" +                             //상품권구분(1)
                                  "0" +                             //쿠폰 구분 (1)
                                  "0" +                             //포인트구분(1)
                                  "0" +                             //신카 구분 (1)
                                  "0" +                             //체카 구분 (1)
                                  "0" +                             //할부 구분 (1)
                                  "8888" +                          //카드회사번호(4)
                                  "99999999999999999999" +          //카드번호 (20)
                                  sDate +                           //실송신일자(8)
                                  sSysTime +                        //실송신시각(6)
                                  tranNo +                          //최초거래번호(4)
                                                                    //상품 ITEM (121)
                                               /*
                                                * ITEM요청 (n * )
                                                */

                                  "ITEM" +                       //ITEM구분

                                  "01" +                           //아이템ID (2) - 상품 : 01
                                  "121" +                           //아이템ID,ITEM_LEN 포함 ITEM 길이 (3)
                                  "001" +                           //아이템순번(3)
                                  "0" +                             //취소구분  (1) - 0:정상,1:취소
                                  "0000000000001" +                 //단품코드 (13)
                                  "0001" +                          //거래선코드(4)
                                  "0000000000001" +                 //본부코드 (13)
                                  "000000000000001" +               //분류코드 (15)
                                  "1" +                            //단품구분 (1) - 1:낱개,2:박스,3:보루
                                  "000001" +                        //수량     (6)
                                  "000002500" +                     //단가     (9) - 할인전 단가 or 신가격이전단가
                                  "000002500" +                     //판매금액 (9)
                                  "0" +                             //행사구분 (1) - 0:정상,1:행사판매
                                  "000002500" +                     //구단가   (9) - 신가격시 구단가
                                  "0" +                             //할인구분 (1)
                                  "00" +                            //할인율   (2)
                                  "000000000" +                     //할인금액 (9)
                                  "0" +                             //과세구분 (1) - 0:과세,1:면세
                                  "0000" +                          //박스/보루 입수  (4)
                                  "0001" +                          //판매유형  (1) - 1:직영,2:특정,3:특약,4:판매분
                                  "1" +                             //스킨플래그(1) - 0:수입력,1:스캐닝,2:신상품
                                  "0000000000000" +                 //쿠폰코드  (13)
                                  "ITEMEND" +                       //ITEM종료
                                                                    //-------------------------------
                                                                    
                                            /*
                                             * 지불요청 (n)
                                             */
                                  "PAY" +                           //PAY구분
                                                                    /*카드*/
                                  "15" +                            //아이템ID (2) - 현금:11,쿠폰:10,상품권:12,신용카드:15
                                  "180" +                           //ITEM길이 (3)
                                  "0200" +                          //거래구분 (4) - 0200:승인요청,0420:승인취소요청
                                  "10" +                            //거래종별 (2) - 10:신용카드,20:포인트적립,40:포인트지불
                                  "00" +                            //승인밴사 (2) - 00:Easy-Check,01:KICC
                                  "111111" +                        //전문일련번호 (6)
                                  "1111222233334444" +              //신용카드번호 (16)
                                  "0425" +                          //유효기간 (4)
                                  "0000000000001234" +              //비밀번호 (16)
                                  "00" +                            //할부개월 (2)
                                  "00002500" +                      //판매금액 (8)
                                  "000000001" +                     //승인번호 (9)
                                  "0" +                             //입력구분 (1)
                                  "1111111111222222222233333333334444444" + // 신용카드데이터 (37)
                                  sSysDate +                        //승인일자 (8)
                                  sSysTime +                        //승인시각 (6)
                                  "070" +                           //발급사코드 (3)
                                  "060" +                           //매입사코드 (3)
                                  "123456789012345" +               //가맹점번호 (15)
                                  "00000000" +                      //합계포인트 (8)
                                  "00000000" +                      //거래포인트 (8)
                                  "00000000" +                      //유효포인트 (8)
                                  "00000000" +                      //공병/쇼핑백금액 (8)
                                  "0" +                             //카드구분 - 0:일반,1:월드패스 (1)

                                 /*현금 샘플*/
                                 //지불 - 현금 ITEM(30)
                                 //"11" +                           //아이템ID (2) - 현금:11,쿠폰:10,상품권:12,신용카드:15
                                 //"030" +                          //ITEM길이 (3)
                                 //"000002500" +                    //현금금액 (9)
                                 //"000000000" +                    //거스름   (8)
                                 //"000000000" +                    //공병/쇼핑백금액(8)

                                 "PAYEND"                          //PAY구분
                                                                    //-------------------------------

                                  ;

                txtInput.Text = sData;
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog(ClsLog.LOG_EXCEPTION, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        private void TestInqData()
        {
            try
            {
                string sDate = null;
                DateTime dtNow;
                String tranNo = "0001";
                String sSysDate = null;
                String sSysTime = null;

                dtNow = DateTime.Now;
                sDate = dtNow.ToString("yyyyMMdd");
                sSysDate = dtNow.ToString("yyyyMMdd");
                sSysTime = dtNow.ToString("HHmmss");
                String sData =                 /* 
                                                * 통신 헤더 (40)
                                                */
                                  "000101" +                        //전문길이  (6)
                                  "PS" +                            //전문경로  (2)
                                  "02" +                            //전문구분  (2) - 00:TRAN,01:CARD INQ,02:POS INQ,03:JOURNAL,04:DUMMY
                                  "00" +                            //전문종별  (2)
                                  "0001" +                          //전문순번  (4)
                                  "0001" +                          //점포번호  (4) 
                                  "0001" +                          //포스번호  (4)
                                  tranNo +                          //거래번호  (4)
                                  sDate +                           //영업일자  (8)
                                  "0000" +                          //에러코드  (4)
                                               /*
                                                * INQ 헤더 (46)
                                                */
                                  "000101" +                        //전문길이  (6)
                                  "0001" +                          //점포번호  (4)
                                  "0001" +                          //포스번호  (4)
                                  tranNo +                          //거래번호  (4)
                                  sDate +                           //영업일자  (8)
                                  sSysDate +                        //시스템일자(8)
                                  sSysTime +                        //시스템시각(6)
                                  "100000" +                        //캐셔번호  (6)
                                                                    //상품 ITEM (121)
                                                                    //-------------------------------
                                                /*
                                                 * PLU 조회 요청 (15)
                                                 */
                                  "20"  +                           //아이템ID (2) - 20:PLU INQ
                                  "0000000000001"                   //PLU코드 (13)
                                                                    //-------------------------------

                                  ;

                txtInput.Text = sData;
            }
            catch (Exception ex)
            {
                ClsLog.WriteLog(ClsLog.LOG_EXCEPTION, System.Reflection.MethodBase.GetCurrentMethod().Name, ex.Message);
            }
        }

        public string ReplaceAtPosition(string self, int position, string newValue)
        {
            return self.Remove(position, newValue.Length).Insert(position, newValue);
        }

    }
}
