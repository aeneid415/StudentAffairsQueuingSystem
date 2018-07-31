namespace QueueClient
{
    partial class ForgetPassword
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
            this.button2 = new System.Windows.Forms.Button();
            this.AccountUpdate = new System.Windows.Forms.Button();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.Txt_ConfPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_Username = new System.Windows.Forms.TextBox();
            this.IPLabel = new System.Windows.Forms.Label();
            this.Txt_ServerIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(230, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AccountUpdate
            // 
            this.AccountUpdate.Location = new System.Drawing.Point(100, 227);
            this.AccountUpdate.Name = "AccountUpdate";
            this.AccountUpdate.Size = new System.Drawing.Size(104, 23);
            this.AccountUpdate.TabIndex = 14;
            this.AccountUpdate.Text = "Change Password";
            this.AccountUpdate.UseVisualStyleBackColor = true;
            // 
            // Txt_Password
            // 
            this.Txt_Password.Location = new System.Drawing.Point(159, 84);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.PasswordChar = '⚫';
            this.Txt_Password.Size = new System.Drawing.Size(216, 20);
            this.Txt_Password.TabIndex = 13;
            // 
            // Txt_ConfPass
            // 
            this.Txt_ConfPass.Location = new System.Drawing.Point(159, 134);
            this.Txt_ConfPass.Name = "Txt_ConfPass";
            this.Txt_ConfPass.PasswordChar = '⚫';
            this.Txt_ConfPass.Size = new System.Drawing.Size(216, 20);
            this.Txt_ConfPass.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Confirm Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "New Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Username:";
            // 
            // Txt_Username
            // 
            this.Txt_Username.Location = new System.Drawing.Point(159, 36);
            this.Txt_Username.Name = "Txt_Username";
            this.Txt_Username.Size = new System.Drawing.Size(216, 20);
            this.Txt_Username.TabIndex = 16;
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(45, 182);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(95, 13);
            this.IPLabel.TabIndex = 17;
            this.IPLabel.Text = "Server IP Address:";
            this.IPLabel.Visible = false;
            // 
            // Txt_ServerIP
            // 
            this.Txt_ServerIP.Location = new System.Drawing.Point(159, 179);
            this.Txt_ServerIP.Name = "Txt_ServerIP";
            this.Txt_ServerIP.Size = new System.Drawing.Size(216, 20);
            this.Txt_ServerIP.TabIndex = 18;
            this.Txt_ServerIP.Visible = false;
            // 
            // ForgetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 271);
            this.Controls.Add(this.Txt_ServerIP);
            this.Controls.Add(this.IPLabel);
            this.Controls.Add(this.Txt_Username);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AccountUpdate);
            this.Controls.Add(this.Txt_Password);
            this.Controls.Add(this.Txt_ConfPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ForgetPassword";
            this.Text = "Password Change";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button AccountUpdate;
        private System.Windows.Forms.TextBox Txt_Password;
        private System.Windows.Forms.TextBox Txt_ConfPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_Username;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.TextBox Txt_ServerIP;
    }
}