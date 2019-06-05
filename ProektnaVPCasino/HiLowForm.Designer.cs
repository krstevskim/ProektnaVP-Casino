namespace ProektnaVPCasino
{
    partial class HiLowForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnHi = new System.Windows.Forms.Button();
            this.btnLow = new System.Windows.Forms.Button();
            this.pogodeni = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.pari = new System.Windows.Forms.TextBox();
            this.betTip = new System.Windows.Forms.NumericUpDown();
            this.cashOutbtn = new System.Windows.Forms.Button();
            this.cashOutAmount = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.endGamebtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.musicBtn = new System.Windows.Forms.Button();
            this.picBoxNext = new System.Windows.Forms.PictureBox();
            this.picBoxCurr = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.betTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCurr)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHi
            // 
            this.btnHi.Location = new System.Drawing.Point(340, 100);
            this.btnHi.Name = "btnHi";
            this.btnHi.Size = new System.Drawing.Size(75, 23);
            this.btnHi.TabIndex = 1;
            this.btnHi.Text = "Високо";
            this.btnHi.UseVisualStyleBackColor = true;
            this.btnHi.Click += new System.EventHandler(this.btnHi_Click);
            // 
            // btnLow
            // 
            this.btnLow.Location = new System.Drawing.Point(340, 169);
            this.btnLow.Name = "btnLow";
            this.btnLow.Size = new System.Drawing.Size(75, 23);
            this.btnLow.TabIndex = 2;
            this.btnLow.Text = "Ниско";
            this.btnLow.UseVisualStyleBackColor = true;
            this.btnLow.Click += new System.EventHandler(this.btnLow_Click);
            // 
            // pogodeni
            // 
            this.pogodeni.AutoSize = true;
            this.pogodeni.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pogodeni.Location = new System.Drawing.Point(347, 294);
            this.pogodeni.Name = "pogodeni";
            this.pogodeni.Size = new System.Drawing.Size(68, 73);
            this.pogodeni.TabIndex = 5;
            this.pogodeni.Text = "0";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pari
            // 
            this.pari.Enabled = false;
            this.pari.Location = new System.Drawing.Point(125, 410);
            this.pari.Name = "pari";
            this.pari.ReadOnly = true;
            this.pari.Size = new System.Drawing.Size(61, 20);
            this.pari.TabIndex = 8;
            this.pari.Text = "100";
            // 
            // betTip
            // 
            this.betTip.Location = new System.Drawing.Point(211, 410);
            this.betTip.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.betTip.Name = "betTip";
            this.betTip.Size = new System.Drawing.Size(58, 20);
            this.betTip.TabIndex = 9;
            this.betTip.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cashOutbtn
            // 
            this.cashOutbtn.Location = new System.Drawing.Point(555, 410);
            this.cashOutbtn.Name = "cashOutbtn";
            this.cashOutbtn.Size = new System.Drawing.Size(75, 23);
            this.cashOutbtn.TabIndex = 10;
            this.cashOutbtn.Text = "Искеширај";
            this.cashOutbtn.UseVisualStyleBackColor = true;
            this.cashOutbtn.Click += new System.EventHandler(this.cashOutbtn_Click);
            // 
            // cashOutAmount
            // 
            this.cashOutAmount.Enabled = false;
            this.cashOutAmount.Location = new System.Drawing.Point(487, 412);
            this.cashOutAmount.Name = "cashOutAmount";
            this.cashOutAmount.ReadOnly = true;
            this.cashOutAmount.Size = new System.Drawing.Size(48, 20);
            this.cashOutAmount.TabIndex = 11;
            this.cashOutAmount.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // endGamebtn
            // 
            this.endGamebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endGamebtn.Location = new System.Drawing.Point(12, 267);
            this.endGamebtn.Name = "endGamebtn";
            this.endGamebtn.Size = new System.Drawing.Size(100, 100);
            this.endGamebtn.TabIndex = 12;
            this.endGamebtn.Text = "Заврши Игра";
            this.endGamebtn.UseVisualStyleBackColor = true;
            this.endGamebtn.Click += new System.EventHandler(this.endGamebtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 387);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Облог";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(129, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 14;
            this.label2.Text = "Пари";
            // 
            // musicBtn
            // 
            this.musicBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.musicBtn.Location = new System.Drawing.Point(656, 267);
            this.musicBtn.Name = "musicBtn";
            this.musicBtn.Size = new System.Drawing.Size(100, 100);
            this.musicBtn.TabIndex = 15;
            this.musicBtn.Text = "Музика";
            this.musicBtn.UseVisualStyleBackColor = true;
            this.musicBtn.Click += new System.EventHandler(this.musicBtn_Click);
            // 
            // picBoxNext
            // 
            this.picBoxNext.InitialImage = global::ProektnaVPCasino.Properties.Resources.hearts_7;
            this.picBoxNext.Location = new System.Drawing.Point(487, 40);
            this.picBoxNext.Name = "picBoxNext";
            this.picBoxNext.Size = new System.Drawing.Size(143, 197);
            this.picBoxNext.TabIndex = 7;
            this.picBoxNext.TabStop = false;
            // 
            // picBoxCurr
            // 
            this.picBoxCurr.Image = global::ProektnaVPCasino.Properties.Resources.hearts_7;
            this.picBoxCurr.InitialImage = global::ProektnaVPCasino.Properties.Resources.hearts_7;
            this.picBoxCurr.Location = new System.Drawing.Point(125, 40);
            this.picBoxCurr.Name = "picBoxCurr";
            this.picBoxCurr.Size = new System.Drawing.Size(143, 197);
            this.picBoxCurr.TabIndex = 6;
            this.picBoxCurr.TabStop = false;
            // 
            // HiLowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(768, 446);
            this.Controls.Add(this.musicBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.endGamebtn);
            this.Controls.Add(this.cashOutAmount);
            this.Controls.Add(this.cashOutbtn);
            this.Controls.Add(this.betTip);
            this.Controls.Add(this.pari);
            this.Controls.Add(this.picBoxNext);
            this.Controls.Add(this.picBoxCurr);
            this.Controls.Add(this.pogodeni);
            this.Controls.Add(this.btnLow);
            this.Controls.Add(this.btnHi);
            this.Name = "HiLowForm";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HiLowForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.betTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxCurr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnHi;
        private System.Windows.Forms.Button btnLow;
        private System.Windows.Forms.Label pogodeni;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.PictureBox picBoxCurr;
        private System.Windows.Forms.PictureBox picBoxNext;
        private System.Windows.Forms.TextBox pari;
        private System.Windows.Forms.NumericUpDown betTip;
        private System.Windows.Forms.Button cashOutbtn;
        private System.Windows.Forms.TextBox cashOutAmount;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button endGamebtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button musicBtn;
    }
}

