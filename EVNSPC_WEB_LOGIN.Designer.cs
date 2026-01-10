namespace Tamphan_WorkingBCMBP_WF
{
    partial class EVNSPC_WEB_LOGIN
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
            this.weblogin = new CefSharp.WinForms.ChromiumWebBrowser();
            this.btn_download_thu_cong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // weblogin
            // 
            this.weblogin.ActivateBrowserOnCreation = false;
            this.weblogin.Location = new System.Drawing.Point(0, 0);
            this.weblogin.Name = "weblogin";
            this.weblogin.Size = new System.Drawing.Size(1900, 1000);
            this.weblogin.TabIndex = 0;
            this.weblogin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.weblogin_MouseClick);
            // 
            // btn_download_thu_cong
            // 
            this.btn_download_thu_cong.Location = new System.Drawing.Point(13, 13);
            this.btn_download_thu_cong.Name = "btn_download_thu_cong";
            this.btn_download_thu_cong.Size = new System.Drawing.Size(136, 28);
            this.btn_download_thu_cong.TabIndex = 1;
            this.btn_download_thu_cong.Text = "nút download thủ công";
            this.btn_download_thu_cong.UseVisualStyleBackColor = true;
            this.btn_download_thu_cong.Click += new System.EventHandler(this.btn_download_thu_cong_Click);
            // 
            // EVNSPC_WEB_LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_download_thu_cong);
            this.Controls.Add(this.weblogin);
            this.Name = "EVNSPC_WEB_LOGIN";
            this.Text = "EVNSPC_WEB_LOGIN";
            this.ResumeLayout(false);

        }

        #endregion

        private CefSharp.WinForms.ChromiumWebBrowser weblogin;
        private System.Windows.Forms.Button btn_download_thu_cong;
    }
}