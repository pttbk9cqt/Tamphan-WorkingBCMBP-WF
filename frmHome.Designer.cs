using System;

namespace Tamphan_WorkingBCMBP_WF
{
    partial class frmHome
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
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.btn_login_eof = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_login_Tamphan = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtSoNgayDaNghiPhep = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRequestLeave = new System.Windows.Forms.Button();
            this.Btn_BTS = new System.Windows.Forms.Button();
            this.Btn_new_1506 = new System.Windows.Forms.Button();
            this.btn_process_waiting = new System.Windows.Forms.Button();
            this.btn_calendar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(23, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Becamex - Bình Phước";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.btn_login_eof);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(31, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(297, 81);
            this.panel1.TabIndex = 8;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(49, 38);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(154, 20);
            this.txtPassword.TabIndex = 12;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(49, 12);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(234, 20);
            this.txtUsername.TabIndex = 11;
            // 
            // btn_login_eof
            // 
            this.btn_login_eof.Location = new System.Drawing.Point(209, 38);
            this.btn_login_eof.Name = "btn_login_eof";
            this.btn_login_eof.Size = new System.Drawing.Size(75, 23);
            this.btn_login_eof.TabIndex = 9;
            this.btn_login_eof.Text = "Login";
            this.btn_login_eof.UseVisualStyleBackColor = true;
            this.btn_login_eof.Click += new System.EventHandler(this.Btn_login_eof_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Pass";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Name";
            // 
            // btn_login_Tamphan
            // 
            this.btn_login_Tamphan.Location = new System.Drawing.Point(30, 7);
            this.btn_login_Tamphan.Name = "btn_login_Tamphan";
            this.btn_login_Tamphan.Size = new System.Drawing.Size(75, 23);
            this.btn_login_Tamphan.TabIndex = 10;
            this.btn_login_Tamphan.Text = "Tamphan";
            this.btn_login_Tamphan.UseVisualStyleBackColor = true;
            this.btn_login_Tamphan.Click += new System.EventHandler(this.Btn_login_Tamphan_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.Btn_BTS);
            this.panel2.Controls.Add(this.Btn_new_1506);
            this.panel2.Controls.Add(this.btn_process_waiting);
            this.panel2.Controls.Add(this.btn_calendar);
            this.panel2.Controls.Add(this.btn_login_Tamphan);
            this.panel2.Location = new System.Drawing.Point(31, 169);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(424, 143);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.txtSoNgayDaNghiPhep);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btnRequestLeave);
            this.panel3.Location = new System.Drawing.Point(122, 72);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(227, 42);
            this.panel3.TabIndex = 17;
            // 
            // txtSoNgayDaNghiPhep
            // 
            this.txtSoNgayDaNghiPhep.Location = new System.Drawing.Point(194, 11);
            this.txtSoNgayDaNghiPhep.Name = "txtSoNgayDaNghiPhep";
            this.txtSoNgayDaNghiPhep.Size = new System.Drawing.Size(27, 20);
            this.txtSoNgayDaNghiPhep.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Số ngày đã nghỉ";
            // 
            // btnRequestLeave
            // 
            this.btnRequestLeave.Location = new System.Drawing.Point(3, 9);
            this.btnRequestLeave.Name = "btnRequestLeave";
            this.btnRequestLeave.Size = new System.Drawing.Size(96, 23);
            this.btnRequestLeave.TabIndex = 16;
            this.btnRequestLeave.Text = "Request Leave";
            this.btnRequestLeave.UseVisualStyleBackColor = true;
            this.btnRequestLeave.Click += new System.EventHandler(this.btnRequestLeave_Click);
            // 
            // Btn_BTS
            // 
            this.Btn_BTS.Location = new System.Drawing.Point(163, 43);
            this.Btn_BTS.Name = "Btn_BTS";
            this.Btn_BTS.Size = new System.Drawing.Size(75, 23);
            this.Btn_BTS.TabIndex = 15;
            this.Btn_BTS.Text = "BTS";
            this.Btn_BTS.UseVisualStyleBackColor = true;
            this.Btn_BTS.Click += new System.EventHandler(this.Btn_BTS_Click);
            // 
            // Btn_new_1506
            // 
            this.Btn_new_1506.Location = new System.Drawing.Point(30, 81);
            this.Btn_new_1506.Name = "Btn_new_1506";
            this.Btn_new_1506.Size = new System.Drawing.Size(75, 23);
            this.Btn_new_1506.TabIndex = 14;
            this.Btn_new_1506.Text = "15-06 new";
            this.Btn_new_1506.UseVisualStyleBackColor = true;
            this.Btn_new_1506.Click += new System.EventHandler(this.Btn_new_1506_Click);
            // 
            // btn_process_waiting
            // 
            this.btn_process_waiting.Location = new System.Drawing.Point(142, 7);
            this.btn_process_waiting.Name = "btn_process_waiting";
            this.btn_process_waiting.Size = new System.Drawing.Size(136, 30);
            this.btn_process_waiting.TabIndex = 12;
            this.btn_process_waiting.Text = "Quy trình chờ phê duyệt";
            this.btn_process_waiting.UseVisualStyleBackColor = true;
            this.btn_process_waiting.Click += new System.EventHandler(this.Btn_process_waiting_Click);
            // 
            // btn_calendar
            // 
            this.btn_calendar.Location = new System.Drawing.Point(30, 42);
            this.btn_calendar.Name = "btn_calendar";
            this.btn_calendar.Size = new System.Drawing.Size(75, 23);
            this.btn_calendar.TabIndex = 11;
            this.btn_calendar.Text = "Lịch";
            this.btn_calendar.UseVisualStyleBackColor = true;
            this.btn_calendar.Click += new System.EventHandler(this.Btn_calendar_Click);
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 351);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Name = "frmHome";
            this.Text = "Tamphan";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_login_eof;
        private System.Windows.Forms.Button btn_login_Tamphan;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_calendar;
        private System.Windows.Forms.Button btn_process_waiting;
        private System.Windows.Forms.Button Btn_new_1506;
        private System.Windows.Forms.Button Btn_BTS;
        private System.Windows.Forms.Button btnRequestLeave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoNgayDaNghiPhep;
    }
}

