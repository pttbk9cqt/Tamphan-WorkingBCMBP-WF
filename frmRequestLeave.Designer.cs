namespace Tamphan_WorkingBCMBP_WF
{
    partial class frmRequestLeave
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
            this.chromiumrequestleave = new CefSharp.WinForms.ChromiumWebBrowser();
            this.SuspendLayout();
            // 
            // chromiumrequestleave
            // 
            this.chromiumrequestleave.ActivateBrowserOnCreation = false;
            this.chromiumrequestleave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chromiumrequestleave.Location = new System.Drawing.Point(0, 0);
            this.chromiumrequestleave.Name = "chromiumrequestleave";
            this.chromiumrequestleave.Size = new System.Drawing.Size(800, 450);
            this.chromiumrequestleave.TabIndex = 0;
            // 
            // frmRequestLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chromiumrequestleave);
            this.Name = "frmRequestLeave";
            this.Text = "frmRequestLeave";
            this.ResumeLayout(false);

        }

        #endregion

        private CefSharp.WinForms.ChromiumWebBrowser chromiumrequestleave;
    }
}