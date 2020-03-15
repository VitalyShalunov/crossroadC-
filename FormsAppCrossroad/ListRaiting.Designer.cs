namespace FormsAppCrossroad
{
    partial class ListRaiting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListRaiting));
            this.NameProgram = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusDB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.SuspendLayout();
            // 
            // NameProgram
            // 
            this.NameProgram.AutoSize = true;
            this.NameProgram.BackColor = System.Drawing.SystemColors.GrayText;
            this.NameProgram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NameProgram.Font = new System.Drawing.Font("Century Gothic", 72F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameProgram.ForeColor = System.Drawing.SystemColors.Window;
            this.NameProgram.Location = new System.Drawing.Point(471, 63);
            this.NameProgram.Name = "NameProgram";
            this.NameProgram.Size = new System.Drawing.Size(652, 149);
            this.NameProgram.TabIndex = 1;
            this.NameProgram.Text = "Crossroad";
            this.NameProgram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NameProgram.Paint += new System.Windows.Forms.PaintEventHandler(this.NameProgram_Paint);
            // 
            // back
            // 
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.Location = new System.Drawing.Point(63, 63);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(84, 68);
            this.back.TabIndex = 3;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(910, 330);
            this.label1.MaximumSize = new System.Drawing.Size(300, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 29);
            this.label1.TabIndex = 4;
            // 
            // statusDB
            // 
            this.statusDB.AutoSize = true;
            this.statusDB.BackColor = System.Drawing.SystemColors.Control;
            this.statusDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.statusDB.Location = new System.Drawing.Point(589, 330);
            this.statusDB.MaximumSize = new System.Drawing.Size(300, 60);
            this.statusDB.Name = "statusDB";
            this.statusDB.Size = new System.Drawing.Size(0, 29);
            this.statusDB.TabIndex = 6;
            // 
            // ListRaiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1303, 938);
            this.Controls.Add(this.statusDB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.back);
            this.Controls.Add(this.NameProgram);
            this.Name = "ListRaiting";
            this.Text = "ListRaiting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ListRaiting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameProgram;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label statusDB;
    }
}