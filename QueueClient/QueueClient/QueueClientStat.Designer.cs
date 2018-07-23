namespace QueueClient
{
    partial class QueueClientStat
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DateLabel = new System.Windows.Forms.Label();
            this.CubicleStats = new System.Windows.Forms.Label();
            this.CloseStatistics = new System.Windows.Forms.Button();
            this.StudentLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.DateLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.CloseStatistics, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.90805F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 41.95402F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.56322F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(390, 174);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.CubicleStats, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.StudentLabel, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 62);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(384, 67);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // DateLabel
            // 
            this.DateLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLabel.Location = new System.Drawing.Point(38, 21);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(313, 17);
            this.DateLabel.TabIndex = 1;
            this.DateLabel.Text = "As of <this date + time>, you have served around... ";
            // 
            // CubicleStats
            // 
            this.CubicleStats.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CubicleStats.AutoSize = true;
            this.CubicleStats.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CubicleStats.Location = new System.Drawing.Point(80, 15);
            this.CubicleStats.Name = "CubicleStats";
            this.CubicleStats.Size = new System.Drawing.Size(32, 37);
            this.CubicleStats.TabIndex = 0;
            this.CubicleStats.Text = "0";
            // 
            // CloseStatistics
            // 
            this.CloseStatistics.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CloseStatistics.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseStatistics.Location = new System.Drawing.Point(157, 141);
            this.CloseStatistics.Name = "CloseStatistics";
            this.CloseStatistics.Size = new System.Drawing.Size(75, 23);
            this.CloseStatistics.TabIndex = 2;
            this.CloseStatistics.Text = "OK";
            this.CloseStatistics.UseVisualStyleBackColor = true;
            this.CloseStatistics.Click += new System.EventHandler(this.CloseStatistics_Click);
            // 
            // StudentLabel
            // 
            this.StudentLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.StudentLabel.AutoSize = true;
            this.StudentLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StudentLabel.Location = new System.Drawing.Point(249, 23);
            this.StudentLabel.Name = "StudentLabel";
            this.StudentLabel.Size = new System.Drawing.Size(78, 21);
            this.StudentLabel.TabIndex = 1;
            this.StudentLabel.Text = "students...";
            // 
            // QueueClientStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 174);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QueueClientStat";
            this.Text = "Statistics (Cubicle)";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label CubicleStats;
        private System.Windows.Forms.Label StudentLabel;
        private System.Windows.Forms.Button CloseStatistics;
    }
}