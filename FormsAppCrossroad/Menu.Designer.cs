namespace FormsAppCrossroad
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.NameProgram = new System.Windows.Forms.Label();
            this.buttonStartGame = new System.Windows.Forms.Button();
            this.buttonInstruction = new System.Windows.Forms.Button();
            this.buttonRaiting = new System.Windows.Forms.Button();
            this.total = new System.Windows.Forms.Label();
            this.bestses = new System.Windows.Forms.Label();
            this.reason = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.userName = new System.Windows.Forms.TextBox();
            this.bestcustomer = new System.Windows.Forms.Label();
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
            this.NameProgram.TabIndex = 0;
            this.NameProgram.Text = "Crossroad";
            this.NameProgram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonStartGame
            // 
            this.buttonStartGame.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonStartGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonStartGame.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonStartGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartGame.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStartGame.Location = new System.Drawing.Point(199, 329);
            this.buttonStartGame.Name = "buttonStartGame";
            this.buttonStartGame.Size = new System.Drawing.Size(259, 70);
            this.buttonStartGame.TabIndex = 1;
            this.buttonStartGame.Text = "Новая игра";
            this.buttonStartGame.UseVisualStyleBackColor = false;
            this.buttonStartGame.Click += new System.EventHandler(this.buttonStartGame_Click);
            // 
            // buttonInstruction
            // 
            this.buttonInstruction.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonInstruction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonInstruction.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonInstruction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonInstruction.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonInstruction.Location = new System.Drawing.Point(199, 466);
            this.buttonInstruction.Name = "buttonInstruction";
            this.buttonInstruction.Size = new System.Drawing.Size(259, 70);
            this.buttonInstruction.TabIndex = 1;
            this.buttonInstruction.Text = "Инструкция";
            this.buttonInstruction.UseVisualStyleBackColor = false;
            this.buttonInstruction.Click += new System.EventHandler(this.buttonInstruction_Click);
            // 
            // buttonRaiting
            // 
            this.buttonRaiting.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.buttonRaiting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRaiting.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonRaiting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRaiting.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRaiting.Location = new System.Drawing.Point(199, 603);
            this.buttonRaiting.Name = "buttonRaiting";
            this.buttonRaiting.Size = new System.Drawing.Size(259, 70);
            this.buttonRaiting.TabIndex = 1;
            this.buttonRaiting.Text = "Рейтинг";
            this.buttonRaiting.UseVisualStyleBackColor = false;
            this.buttonRaiting.Click += new System.EventHandler(this.buttonRaiting_Click);
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.total.Location = new System.Drawing.Point(1479, 294);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(93, 32);
            this.total.TabIndex = 2;
            this.total.Text = "label1";
            this.total.Paint += new System.Windows.Forms.PaintEventHandler(this.total_Paint);
            // 
            // bestses
            // 
            this.bestses.AutoSize = true;
            this.bestses.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bestses.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bestses.Location = new System.Drawing.Point(1479, 350);
            this.bestses.Name = "bestses";
            this.bestses.Size = new System.Drawing.Size(93, 32);
            this.bestses.TabIndex = 2;
            this.bestses.Text = "label1";
            this.bestses.Paint += new System.Windows.Forms.PaintEventHandler(this.bestses_Paint);
            // 
            // reason
            // 
            this.reason.AutoSize = true;
            this.reason.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reason.Location = new System.Drawing.Point(47, 63);
            this.reason.Name = "reason";
            this.reason.Size = new System.Drawing.Size(0, 32);
            this.reason.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(199, 740);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(259, 70);
            this.button1.TabIndex = 1;
            this.button1.Text = "Выход";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttonEnd_Click);
            // 
            // userName
            // 
            this.userName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userName.ForeColor = System.Drawing.SystemColors.MenuText;
            this.userName.Location = new System.Drawing.Point(53, 113);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(107, 28);
            this.userName.TabIndex = 4;
            this.userName.Text = "Ваше имя";
            this.userName.Click += new System.EventHandler(this.userName_Click);
            this.userName.TextChanged += new System.EventHandler(this.userName_TextChanged);
            // 
            // bestcustomer
            // 
            this.bestcustomer.AutoSize = true;
            this.bestcustomer.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.bestcustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bestcustomer.Location = new System.Drawing.Point(1479, 406);
            this.bestcustomer.Name = "bestcustomer";
            this.bestcustomer.Size = new System.Drawing.Size(0, 32);
            this.bestcustomer.TabIndex = 5;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1924, 938);
            this.Controls.Add(this.bestcustomer);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.reason);
            this.Controls.Add(this.bestses);
            this.Controls.Add(this.total);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonRaiting);
            this.Controls.Add(this.buttonInstruction);
            this.Controls.Add(this.buttonStartGame);
            this.Controls.Add(this.NameProgram);
            this.Name = "Menu";
            this.Text = "Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Menu_Load);
            this.Shown += new System.EventHandler(this.Menu_Shown);
            this.Click += new System.EventHandler(this.Menu_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameProgram;
        private System.Windows.Forms.Button buttonStartGame;
        private System.Windows.Forms.Button buttonInstruction;
        private System.Windows.Forms.Button buttonRaiting;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label bestses;
        public System.Windows.Forms.Label reason;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox userName;
        public System.Windows.Forms.Label bestcustomer;
    }
}