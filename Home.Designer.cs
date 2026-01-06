using System;

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
            this.btn_account_riêng_lẻ = new System.Windows.Forms.Button();
            this.EVNSPC = new System.Windows.Forms.Label();
            this.panel_account_lẻ = new System.Windows.Forms.Panel();
            this.button_Login_account_riêng_lẻ = new System.Windows.Forms.Button();
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_nhập_mã_khách_hàng = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_account_lẻ.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnHopdongThoathuan
            // 
            this.btnHopdongThoathuan.Location = new System.Drawing.Point(12, 12);
            this.btnHopdongThoathuan.Name = "btnHopdongThoathuan";
            this.btnHopdongThoathuan.Size = new System.Drawing.Size(257, 75);
            this.btnHopdongThoathuan.TabIndex = 0;
            this.btnHopdongThoathuan.Text = "Thỏa thuận - Hợp tác";
            this.btnHopdongThoathuan.UseVisualStyleBackColor = true;
            this.btnHopdongThoathuan.Click += new System.EventHandler(this.btnHopdongThoathuan_Click);
            // 
            // btn_account_riêng_lẻ
            // 
            this.btn_account_riêng_lẻ.Location = new System.Drawing.Point(492, 66);
            this.btn_account_riêng_lẻ.Name = "btn_account_riêng_lẻ";
            this.btn_account_riêng_lẻ.Size = new System.Drawing.Size(251, 40);
            this.btn_account_riêng_lẻ.TabIndex = 1;
            this.btn_account_riêng_lẻ.Text = "Đăng nhập account riêng lẻ";
            this.btn_account_riêng_lẻ.UseVisualStyleBackColor = true;
            this.btn_account_riêng_lẻ.Click += new System.EventHandler(this.btn_account_riêng_lẻ_Click);
            // 
            // EVNSPC
            // 
            this.EVNSPC.AutoSize = true;
            this.EVNSPC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EVNSPC.Location = new System.Drawing.Point(488, 23);
            this.EVNSPC.Name = "EVNSPC";
            this.EVNSPC.Size = new System.Drawing.Size(87, 24);
            this.EVNSPC.TabIndex = 2;
            this.EVNSPC.Text = "EVNSPC";
            // 
            // panel_account_lẻ
            // 
            this.panel_account_lẻ.Controls.Add(this.button_Login_account_riêng_lẻ);
            this.panel_account_lẻ.Controls.Add(this.textBox_password);
            this.panel_account_lẻ.Controls.Add(this.label2);
            this.panel_account_lẻ.Controls.Add(this.textBox_nhập_mã_khách_hàng);
            this.panel_account_lẻ.Controls.Add(this.label1);
            this.panel_account_lẻ.Location = new System.Drawing.Point(492, 112);
            this.panel_account_lẻ.Name = "panel_account_lẻ";
            this.panel_account_lẻ.Size = new System.Drawing.Size(260, 58);
            this.panel_account_lẻ.TabIndex = 4;
            this.panel_account_lẻ.Visible = false;
            // 
            // button_Login_account_riêng_lẻ
            // 
            this.button_Login_account_riêng_lẻ.Location = new System.Drawing.Point(188, 31);
            this.button_Login_account_riêng_lẻ.Name = "button_Login_account_riêng_lẻ";
            this.button_Login_account_riêng_lẻ.Size = new System.Drawing.Size(66, 24);
            this.button_Login_account_riêng_lẻ.TabIndex = 4;
            this.button_Login_account_riêng_lẻ.Text = "Login";
            this.button_Login_account_riêng_lẻ.UseVisualStyleBackColor = true;
            this.button_Login_account_riêng_lẻ.Click += new System.EventHandler(this.button_Login_account_riêng_lẻ_Click);
            // 
            // textBox_password
            // 
            this.textBox_password.Location = new System.Drawing.Point(82, 31);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(100, 20);
            this.textBox_password.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // textBox_nhập_mã_khách_hàng
            // 
            this.textBox_nhập_mã_khách_hàng.Location = new System.Drawing.Point(82, 5);
            this.textBox_nhập_mã_khách_hàng.Name = "textBox_nhập_mã_khách_hàng";
            this.textBox_nhập_mã_khách_hàng.Size = new System.Drawing.Size(169, 20);
            this.textBox_nhập_mã_khách_hàng.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập mã KH";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 411);
            this.Controls.Add(this.panel_account_lẻ);
            this.Controls.Add(this.EVNSPC);
            this.Controls.Add(this.btn_account_riêng_lẻ);
            this.Controls.Add(this.btnHopdongThoathuan);
            this.Name = "Home";
            this.Text = "Tamphan";
            this.panel_account_lẻ.ResumeLayout(false);
            this.panel_account_lẻ.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button btnHopdongThoathuan;
        private System.Windows.Forms.Button btn_account_riêng_lẻ;
        private System.Windows.Forms.Label EVNSPC;
        private System.Windows.Forms.Panel panel_account_lẻ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_nhập_mã_khách_hàng;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.Button button_Login_account_riêng_lẻ;
    }
}

