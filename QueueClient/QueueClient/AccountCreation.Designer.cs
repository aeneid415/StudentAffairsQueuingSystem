namespace QueueClient
{
    partial class AccountCreation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountCreation));
            this.button2 = new System.Windows.Forms.Button();
            this.AccountCreate = new System.Windows.Forms.Button();
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.Txt_Username = new System.Windows.Forms.TextBox();
            this.Txt_ConfPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Txt_Lastname = new System.Windows.Forms.TextBox();
            this.Txt_Firstname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(227, 280);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AccountCreate
            // 
            this.AccountCreate.Location = new System.Drawing.Point(97, 280);
            this.AccountCreate.Name = "AccountCreate";
            this.AccountCreate.Size = new System.Drawing.Size(104, 23);
            this.AccountCreate.TabIndex = 6;
            this.AccountCreate.Text = "Create Account";
            this.AccountCreate.UseVisualStyleBackColor = true;
            this.AccountCreate.Click += new System.EventHandler(this.AccountCreate_Click);
            // 
            // Txt_Password
            // 
            this.Txt_Password.Location = new System.Drawing.Point(157, 173);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.PasswordChar = '⚫';
            this.Txt_Password.Size = new System.Drawing.Size(216, 20);
            this.Txt_Password.TabIndex = 4;
            // 
            // Txt_Username
            // 
            this.Txt_Username.Location = new System.Drawing.Point(157, 125);
            this.Txt_Username.Name = "Txt_Username";
            this.Txt_Username.Size = new System.Drawing.Size(216, 20);
            this.Txt_Username.TabIndex = 3;
            // 
            // Txt_ConfPass
            // 
            this.Txt_ConfPass.Location = new System.Drawing.Point(157, 223);
            this.Txt_ConfPass.Name = "Txt_ConfPass";
            this.Txt_ConfPass.PasswordChar = '⚫';
            this.Txt_ConfPass.Size = new System.Drawing.Size(216, 20);
            this.Txt_ConfPass.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Confirm Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 176);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Username:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Last Name:";
            // 
            // Txt_Lastname
            // 
            this.Txt_Lastname.Location = new System.Drawing.Point(157, 76);
            this.Txt_Lastname.Name = "Txt_Lastname";
            this.Txt_Lastname.Size = new System.Drawing.Size(216, 20);
            this.Txt_Lastname.TabIndex = 2;
            // 
            // Txt_Firstname
            // 
            this.Txt_Firstname.Location = new System.Drawing.Point(157, 30);
            this.Txt_Firstname.Name = "Txt_Firstname";
            this.Txt_Firstname.Size = new System.Drawing.Size(216, 20);
            this.Txt_Firstname.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "First Name:";
            // 
            // AccountCreation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 323);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Txt_Lastname);
            this.Controls.Add(this.Txt_Firstname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AccountCreate);
            this.Controls.Add(this.Txt_Password);
            this.Controls.Add(this.Txt_Username);
            this.Controls.Add(this.Txt_ConfPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountCreation";
            this.Text = "Create Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button AccountCreate;
        private System.Windows.Forms.TextBox Txt_Password;
        private System.Windows.Forms.TextBox Txt_Username;
        private System.Windows.Forms.TextBox Txt_ConfPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Txt_Lastname;
        private System.Windows.Forms.TextBox Txt_Firstname;
        private System.Windows.Forms.Label label4;
    }
}