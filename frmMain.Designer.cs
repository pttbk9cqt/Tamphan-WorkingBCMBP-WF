namespace Tamphan_WorkingBCMBP_WF
{
    partial class frmMain
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
            this.chromiumeof = new CefSharp.WinForms.ChromiumWebBrowser();
            this.SuspendLayout();
            // 
            // chromiumeof
            // 
            this.chromiumeof.ActivateBrowserOnCreation = false;
            this.chromiumeof.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chromiumeof.Location = new System.Drawing.Point(0, 0);
            this.chromiumeof.Name = "chromiumeof";
            this.chromiumeof.Size = new System.Drawing.Size(800, 450);
            this.chromiumeof.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chromiumeof);
            this.Name = "frmMain";
            this.Text = "EofficeBecamexBinhphuoc";
            this.ResumeLayout(false);

        }

        #endregion

        private CefSharp.WinForms.ChromiumWebBrowser chromiumeof;
    }
}