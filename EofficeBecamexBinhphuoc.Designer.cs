namespace Tamphan_WorkingBCMBP_WF
{
    partial class EofficeBecamexBinhphuoc
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
            this.chromiumWebBrowser_Eoffice = new CefSharp.WinForms.ChromiumWebBrowser();
            this.SuspendLayout();
            // 
            // chromiumWebBrowser_Eoffice
            // 
            this.chromiumWebBrowser_Eoffice.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser_Eoffice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chromiumWebBrowser_Eoffice.Location = new System.Drawing.Point(0, 0);
            this.chromiumWebBrowser_Eoffice.Name = "chromiumWebBrowser_Eoffice";
            this.chromiumWebBrowser_Eoffice.Size = new System.Drawing.Size(800, 450);
            this.chromiumWebBrowser_Eoffice.TabIndex = 0;
            // 
            // EofficeBecamexBinhphuoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chromiumWebBrowser_Eoffice);
            this.Name = "EofficeBecamexBinhphuoc";
            this.Text = "EofficeBecamexBinhphuoc";
            this.ResumeLayout(false);

        }

        #endregion

        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser_Eoffice;
    }
}