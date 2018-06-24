namespace TCPServerNew
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cubicleNumber = new System.Windows.Forms.Label();
            this.servingNumber = new System.Windows.Forms.Label();
            this.acceptConn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server has not yet started...";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(99, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(509, 73);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cubicle Number:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(834, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(430, 73);
            this.label3.TabIndex = 2;
            this.label3.Text = "Now Serving: ";
            // 
            // cubicleNumber
            // 
            this.cubicleNumber.AutoEllipsis = true;
            this.cubicleNumber.AutoSize = true;
            this.cubicleNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 104.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cubicleNumber.Location = new System.Drawing.Point(262, 263);
            this.cubicleNumber.Name = "cubicleNumber";
            this.cubicleNumber.Size = new System.Drawing.Size(144, 159);
            this.cubicleNumber.TabIndex = 3;
            this.cubicleNumber.Text = "0";
            // 
            // servingNumber
            // 
            this.servingNumber.AutoSize = true;
            this.servingNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 104.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.servingNumber.Location = new System.Drawing.Point(981, 263);
            this.servingNumber.Name = "servingNumber";
            this.servingNumber.Size = new System.Drawing.Size(144, 159);
            this.servingNumber.TabIndex = 4;
            this.servingNumber.Text = "0";
            this.servingNumber.Click += new System.EventHandler(this.servingNumber_Click);
            // 
            // acceptConn
            // 
            this.acceptConn.Location = new System.Drawing.Point(1144, 673);
            this.acceptConn.Name = "acceptConn";
            this.acceptConn.Size = new System.Drawing.Size(172, 23);
            this.acceptConn.TabIndex = 5;
            this.acceptConn.Text = "Accept Incoming Connections";
            this.acceptConn.UseVisualStyleBackColor = true;
            this.acceptConn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "label6";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 683);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "label7";
            this.label7.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.acceptConn);
            this.Controls.Add(this.servingNumber);
            this.Controls.Add(this.cubicleNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label servingNumber;
        private System.Windows.Forms.Button acceptConn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label cubicleNumber;
    }
}

