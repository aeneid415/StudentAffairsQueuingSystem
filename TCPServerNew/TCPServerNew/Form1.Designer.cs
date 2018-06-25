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
            this.label7 = new System.Windows.Forms.Label();
            this.connectionsCount = new System.Windows.Forms.TextBox();
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
            this.label3.Location = new System.Drawing.Point(769, 98);
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
            this.cubicleNumber.Click += new System.EventHandler(this.cubicleNumber_Click);
            // 
            // servingNumber
            // 
            this.servingNumber.AutoSize = true;
            this.servingNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 104.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.servingNumber.Location = new System.Drawing.Point(866, 263);
            this.servingNumber.Name = "servingNumber";
            this.servingNumber.Size = new System.Drawing.Size(221, 159);
            this.servingNumber.TabIndex = 4;
            this.servingNumber.Text = "95";
            this.servingNumber.Click += new System.EventHandler(this.servingNumber_Click);
            // 
            // acceptConn
            // 
            this.acceptConn.Location = new System.Drawing.Point(1071, 642);
            this.acceptConn.Name = "acceptConn";
            this.acceptConn.Size = new System.Drawing.Size(172, 23);
            this.acceptConn.TabIndex = 5;
            this.acceptConn.Text = "Accept Incoming Connections";
            this.acceptConn.UseVisualStyleBackColor = true;
            this.acceptConn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 652);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(270, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Number of Active Terminals (with pending connections):";
            // 
            // connectionsCount
            // 
            this.connectionsCount.Location = new System.Drawing.Point(306, 649);
            this.connectionsCount.Name = "connectionsCount";
            this.connectionsCount.Size = new System.Drawing.Size(100, 20);
            this.connectionsCount.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.connectionsCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.acceptConn);
            this.Controls.Add(this.servingNumber);
            this.Controls.Add(this.cubicleNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "OSA Queuing Server";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label cubicleNumber;
        private System.Windows.Forms.TextBox connectionsCount;
    }
}

