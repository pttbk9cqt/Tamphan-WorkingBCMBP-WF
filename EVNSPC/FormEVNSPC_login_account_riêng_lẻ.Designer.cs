namespace Tamphan_WorkingBCMBP_WF
{
    partial class FormEVNSPC_login_account_riêng_lẻ
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
            this.panelBrowser = new System.Windows.Forms.Panel();
            this.btn_TestCaptcha = new System.Windows.Forms.Button();
            this.panelBrowser.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBrowser
            // 
            this.panelBrowser.Controls.Add(this.btn_TestCaptcha);
            this.panelBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBrowser.Location = new System.Drawing.Point(0, 0);
            this.panelBrowser.Name = "panelBrowser";
            this.panelBrowser.Size = new System.Drawing.Size(1145, 661);
            this.panelBrowser.TabIndex = 0;
            // 
            // btn_TestCaptcha
            // 
            this.btn_TestCaptcha.Location = new System.Drawing.Point(3, 3);
            this.btn_TestCaptcha.Name = "btn_TestCaptcha";
            this.btn_TestCaptcha.Size = new System.Drawing.Size(114, 36);
            this.btn_TestCaptcha.TabIndex = 0;
            this.btn_TestCaptcha.Text = "Test Captcha";
            this.btn_TestCaptcha.UseVisualStyleBackColor = true;
            this.btn_TestCaptcha.Click += new System.EventHandler(this.btn_TestCaptcha_Click);
            // 
            // FormEVNSPC_login_account_riêng_lẻ
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 661);
            this.Controls.Add(this.panelBrowser);
            this.Name = "FormEVNSPC_login_account_riêng_lẻ";
            this.Text = "FormEVNSPC";
            this.panelBrowser.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBrowser;
        private System.Windows.Forms.Button btn_TestCaptcha;
    }
}