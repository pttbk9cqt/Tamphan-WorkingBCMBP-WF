namespace Tamphan_WorkingBCMBP_WF
{
    partial class Home
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
            this.btnHopdongThoathuan = new System.Windows.Forms.Button();
            this.btnEVNSPC = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnHopdongThoathuan
            // 
            this.btnHopdongThoathuan.Location = new System.Drawing.Point(259, 89);
            this.btnHopdongThoathuan.Name = "btnHopdongThoathuan";
            this.btnHopdongThoathuan.Size = new System.Drawing.Size(257, 75);
            this.btnHopdongThoathuan.TabIndex = 0;
            this.btnHopdongThoathuan.Text = "Thỏa thuận - Hợp tác";
            this.btnHopdongThoathuan.UseVisualStyleBackColor = true;
            this.btnHopdongThoathuan.Click += new System.EventHandler(this.btnHopdongThoathuan_Click);
            // 
            // btnEVNSPC
            // 
            this.btnEVNSPC.Location = new System.Drawing.Point(259, 207);
            this.btnEVNSPC.Name = "btnEVNSPC";
            this.btnEVNSPC.Size = new System.Drawing.Size(257, 66);
            this.btnEVNSPC.TabIndex = 1;
            this.btnEVNSPC.Text = "EVNSPC";
            this.btnEVNSPC.UseVisualStyleBackColor = true;
            this.btnEVNSPC.Click += new System.EventHandler(this.btnEVNSPC_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnEVNSPC);
            this.Controls.Add(this.btnHopdongThoathuan);
            this.Name = "Home";
            this.Text = "Tamphan";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnHopdongThoathuan;
        private System.Windows.Forms.Button btnEVNSPC;
    }
}

