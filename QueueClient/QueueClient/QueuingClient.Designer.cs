namespace QueueClient
{
    partial class QueuingClient
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.callStudent = new System.Windows.Forms.Button();
            this.clientLogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.currentNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cubID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QueueClient.Properties.Resources.slu;
            this.pictureBox1.Location = new System.Drawing.Point(33, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(157, 245);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // callStudent
            // 
            this.callStudent.Location = new System.Drawing.Point(251, 36);
            this.callStudent.Name = "callStudent";
            this.callStudent.Size = new System.Drawing.Size(101, 23);
            this.callStudent.TabIndex = 1;
            this.callStudent.Text = "Call Student";
            this.callStudent.UseVisualStyleBackColor = true;
            this.callStudent.Click += new System.EventHandler(this.callStudent_Click);
            // 
            // clientLogout
            // 
            this.clientLogout.Location = new System.Drawing.Point(251, 89);
            this.clientLogout.Name = "clientLogout";
            this.clientLogout.Size = new System.Drawing.Size(101, 23);
            this.clientLogout.TabIndex = 2;
            this.clientLogout.Text = "Logout";
            this.clientLogout.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(248, 167);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current Number:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentNumber
            // 
            this.currentNumber.AutoSize = true;
            this.currentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentNumber.Location = new System.Drawing.Point(280, 200);
            this.currentNumber.Name = "currentNumber";
            this.currentNumber.Size = new System.Drawing.Size(36, 39);
            this.currentNumber.TabIndex = 4;
            this.currentNumber.Text = "0";
            this.currentNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cubicle Number:";
            // 
            // cubID
            // 
            this.cubID.AutoSize = true;
            this.cubID.Location = new System.Drawing.Point(125, 279);
            this.cubID.Name = "cubID";
            this.cubID.Size = new System.Drawing.Size(27, 13);
            this.cubID.TabIndex = 6;
            this.cubID.Text = "emp";
            // 
            // QueuingClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 318);
            this.Controls.Add(this.cubID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.currentNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clientLogout);
            this.Controls.Add(this.callStudent);
            this.Controls.Add(this.pictureBox1);
            this.Name = "QueuingClient";
            this.Text = "Main Menu (Client)";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button callStudent;
        private System.Windows.Forms.Button clientLogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label cubID;
    }
}