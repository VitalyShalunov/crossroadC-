namespace FormsAppCrossroad
{
    partial class Instruction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Instruction));
            this.NameProgram = new System.Windows.Forms.Label();
            this.back = new System.Windows.Forms.PictureBox();
            this.description = new System.Windows.Forms.Label();
            this.arrowLeft = new System.Windows.Forms.PictureBox();
            this.arrowTop = new System.Windows.Forms.PictureBox();
            this.space = new System.Windows.Forms.PictureBox();
            this.wish = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.space)).BeginInit();
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
            // 
            // back
            // 
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Image = ((System.Drawing.Image)(resources.GetObject("back.Image")));
            this.back.Location = new System.Drawing.Point(63, 63);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(84, 68);
            this.back.TabIndex = 2;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // description
            // 
            this.description.AutoSize = true;
            this.description.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.description.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.description.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.description.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.description.Location = new System.Drawing.Point(253, 416);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(1217, 218);
            this.description.TabIndex = 3;
            this.description.Text = resources.GetString("description.Text");
            this.description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // arrowLeft
            // 
            this.arrowLeft.Image = ((System.Drawing.Image)(resources.GetObject("arrowLeft.Image")));
            this.arrowLeft.Location = new System.Drawing.Point(1429, 447);
            this.arrowLeft.Name = "arrowLeft";
            this.arrowLeft.Size = new System.Drawing.Size(46, 26);
            this.arrowLeft.TabIndex = 4;
            this.arrowLeft.TabStop = false;
            // 
            // arrowTop
            // 
            this.arrowTop.Image = ((System.Drawing.Image)(resources.GetObject("arrowTop.Image")));
            this.arrowTop.Location = new System.Drawing.Point(1481, 437);
            this.arrowTop.Name = "arrowTop";
            this.arrowTop.Size = new System.Drawing.Size(36, 36);
            this.arrowTop.TabIndex = 5;
            this.arrowTop.TabStop = false;
            // 
            // space
            // 
            this.space.Image = ((System.Drawing.Image)(resources.GetObject("space.Image")));
            this.space.Location = new System.Drawing.Point(1408, 560);
            this.space.Name = "space";
            this.space.Size = new System.Drawing.Size(36, 10);
            this.space.TabIndex = 6;
            this.space.TabStop = false;
            // 
            // wish
            // 
            this.wish.AutoSize = true;
            this.wish.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.wish.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.wish.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wish.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.wish.Location = new System.Drawing.Point(787, 699);
            this.wish.Name = "wish";
            this.wish.Size = new System.Drawing.Size(180, 29);
            this.wish.TabIndex = 3;
            this.wish.Text = "Приятной игры!";
            this.wish.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Instruction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1924, 938);
            this.Controls.Add(this.space);
            this.Controls.Add(this.arrowTop);
            this.Controls.Add(this.arrowLeft);
            this.Controls.Add(this.wish);
            this.Controls.Add(this.description);
            this.Controls.Add(this.back);
            this.Controls.Add(this.NameProgram);
            this.Name = "Instruction";
            this.Text = "Instruction";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrowTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.space)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameProgram;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.Label description;
        private System.Windows.Forms.PictureBox arrowLeft;
        private System.Windows.Forms.PictureBox arrowTop;
        private System.Windows.Forms.PictureBox space;
        private System.Windows.Forms.Label wish;
    }
}