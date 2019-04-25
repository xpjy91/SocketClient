namespace SocketClient
{
    partial class FrmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtInput = new System.Windows.Forms.TextBox();
            this.lblInput = new System.Windows.Forms.Label();
            this.btnInq = new System.Windows.Forms.Button();
            this.btnTran = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtView = new System.Windows.Forms.TextBox();
            this.lblView = new System.Windows.Forms.Label();
            this.btnDummy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(9, 36);
            this.txtInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInput.MaxLength = 0;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(499, 30);
            this.txtInput.TabIndex = 49;
            // 
            // lblInput
            // 
            this.lblInput.AutoSize = true;
            this.lblInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInput.Location = new System.Drawing.Point(12, 9);
            this.lblInput.Name = "lblInput";
            this.lblInput.Size = new System.Drawing.Size(114, 25);
            this.lblInput.TabIndex = 48;
            this.lblInput.Text = "전문 번호 입력";
            this.lblInput.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnInq
            // 
            this.btnInq.BackColor = System.Drawing.SystemColors.Control;
            this.btnInq.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnInq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInq.ForeColor = System.Drawing.Color.Black;
            this.btnInq.Location = new System.Drawing.Point(9, 143);
            this.btnInq.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnInq.Name = "btnInq";
            this.btnInq.Size = new System.Drawing.Size(96, 60);
            this.btnInq.TabIndex = 50;
            this.btnInq.Text = "INQ";
            this.btnInq.UseVisualStyleBackColor = false;
            this.btnInq.Click += new System.EventHandler(this.btnInq_Click);
            // 
            // btnTran
            // 
            this.btnTran.BackColor = System.Drawing.SystemColors.Control;
            this.btnTran.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTran.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTran.ForeColor = System.Drawing.Color.Black;
            this.btnTran.Location = new System.Drawing.Point(111, 143);
            this.btnTran.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTran.Name = "btnTran";
            this.btnTran.Size = new System.Drawing.Size(96, 60);
            this.btnTran.TabIndex = 51;
            this.btnTran.Text = "TRAN";
            this.btnTran.UseVisualStyleBackColor = false;
            this.btnTran.Click += new System.EventHandler(this.btnTran_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.SystemColors.Control;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.Black;
            this.btnClear.Location = new System.Drawing.Point(412, 143);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(96, 60);
            this.btnClear.TabIndex = 53;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtView
            // 
            this.txtView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtView.Location = new System.Drawing.Point(9, 105);
            this.txtView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtView.MaxLength = 0;
            this.txtView.Name = "txtView";
            this.txtView.Size = new System.Drawing.Size(499, 30);
            this.txtView.TabIndex = 54;
            // 
            // lblView
            // 
            this.lblView.AutoSize = true;
            this.lblView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblView.Location = new System.Drawing.Point(12, 76);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(42, 25);
            this.lblView.TabIndex = 55;
            this.lblView.Text = "결과";
            this.lblView.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnDummy
            // 
            this.btnDummy.BackColor = System.Drawing.SystemColors.Control;
            this.btnDummy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDummy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDummy.ForeColor = System.Drawing.Color.Black;
            this.btnDummy.Location = new System.Drawing.Point(213, 143);
            this.btnDummy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDummy.Name = "btnDummy";
            this.btnDummy.Size = new System.Drawing.Size(96, 60);
            this.btnDummy.TabIndex = 56;
            this.btnDummy.Text = "TEST";
            this.btnDummy.UseVisualStyleBackColor = false;
            this.btnDummy.Click += new System.EventHandler(this.btnDummy_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 223);
            this.Controls.Add(this.btnDummy);
            this.Controls.Add(this.lblView);
            this.Controls.Add(this.txtView);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnTran);
            this.Controls.Add(this.btnInq);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.lblInput);
            this.Name = "FrmMain";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label lblInput;
        private System.Windows.Forms.Button btnInq;
        private System.Windows.Forms.Button btnTran;
        private System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.TextBox txtView;
        private System.Windows.Forms.Label lblView;
        private System.Windows.Forms.Button btnDummy;
    }
}

