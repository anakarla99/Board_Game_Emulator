namespace Project_Emulator
{
    partial class Bitacora
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
            this.components = new System.ComponentModel.Container();
            this.move_bt = new System.Windows.Forms.Button();
            this.game_bt = new System.Windows.Forms.Button();
            this.match_bt = new System.Windows.Forms.Button();
            this.tournament_bt = new System.Windows.Forms.Button();
            this.all_bt = new System.Windows.Forms.Button();
            this.move_cb = new System.Windows.Forms.CheckBox();
            this.games_cb = new System.Windows.Forms.CheckBox();
            this.matches_cb = new System.Windows.Forms.CheckBox();
            this.bitacora_lbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // move_bt
            // 
            this.move_bt.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.move_bt.Location = new System.Drawing.Point(24, 19);
            this.move_bt.Name = "move_bt";
            this.move_bt.Size = new System.Drawing.Size(144, 32);
            this.move_bt.TabIndex = 1;
            this.move_bt.Text = "Show next move";
            this.move_bt.UseVisualStyleBackColor = true;
            this.move_bt.Click += new System.EventHandler(this.move_bt_Click);
            // 
            // game_bt
            // 
            this.game_bt.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.game_bt.Location = new System.Drawing.Point(24, 72);
            this.game_bt.Name = "game_bt";
            this.game_bt.Size = new System.Drawing.Size(144, 32);
            this.game_bt.TabIndex = 2;
            this.game_bt.Text = "Show  next game";
            this.game_bt.UseVisualStyleBackColor = true;
            this.game_bt.Click += new System.EventHandler(this.game_bt_Click);
            // 
            // match_bt
            // 
            this.match_bt.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.match_bt.Location = new System.Drawing.Point(24, 129);
            this.match_bt.Name = "match_bt";
            this.match_bt.Size = new System.Drawing.Size(144, 33);
            this.match_bt.TabIndex = 3;
            this.match_bt.Text = "Show next match";
            this.match_bt.UseVisualStyleBackColor = true;
            this.match_bt.Click += new System.EventHandler(this.match_bt_Click);
            // 
            // tournament_bt
            // 
            this.tournament_bt.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tournament_bt.Location = new System.Drawing.Point(24, 188);
            this.tournament_bt.Name = "tournament_bt";
            this.tournament_bt.Size = new System.Drawing.Size(144, 38);
            this.tournament_bt.TabIndex = 4;
            this.tournament_bt.Text = "Show next tournament";
            this.tournament_bt.UseVisualStyleBackColor = true;
            this.tournament_bt.Click += new System.EventHandler(this.tournament_bt_Click);
            // 
            // all_bt
            // 
            this.all_bt.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.all_bt.Location = new System.Drawing.Point(24, 254);
            this.all_bt.Name = "all_bt";
            this.all_bt.Size = new System.Drawing.Size(144, 32);
            this.all_bt.TabIndex = 5;
            this.all_bt.Text = "Execute All";
            this.all_bt.UseVisualStyleBackColor = true;
            this.all_bt.Click += new System.EventHandler(this.all_bt_Click);
            // 
            // move_cb
            // 
            this.move_cb.AutoSize = true;
            this.move_cb.Location = new System.Drawing.Point(20, 17);
            this.move_cb.Name = "move_cb";
            this.move_cb.Size = new System.Drawing.Size(72, 17);
            this.move_cb.TabIndex = 6;
            this.move_cb.Text = "no moves";
            this.move_cb.UseVisualStyleBackColor = true;
            this.move_cb.CheckedChanged += new System.EventHandler(this.move_cb_CheckedChanged);
            // 
            // games_cb
            // 
            this.games_cb.AutoSize = true;
            this.games_cb.Location = new System.Drawing.Point(20, 49);
            this.games_cb.Name = "games_cb";
            this.games_cb.Size = new System.Drawing.Size(72, 17);
            this.games_cb.TabIndex = 7;
            this.games_cb.Text = "no games";
            this.games_cb.UseVisualStyleBackColor = true;
            // 
            // matches_cb
            // 
            this.matches_cb.AutoSize = true;
            this.matches_cb.Location = new System.Drawing.Point(20, 82);
            this.matches_cb.Name = "matches_cb";
            this.matches_cb.Size = new System.Drawing.Size(81, 17);
            this.matches_cb.TabIndex = 8;
            this.matches_cb.Text = "no matches";
            this.matches_cb.UseVisualStyleBackColor = true;
            // 
            // bitacora_lbl
            // 
            this.bitacora_lbl.Location = new System.Drawing.Point(192, 29);
            this.bitacora_lbl.Name = "bitacora_lbl";
            this.bitacora_lbl.Size = new System.Drawing.Size(495, 407);
            this.bitacora_lbl.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.move_cb);
            this.panel1.Controls.Add(this.games_cb);
            this.panel1.Controls.Add(this.matches_cb);
            this.panel1.Location = new System.Drawing.Point(24, 319);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(144, 117);
            this.panel1.TabIndex = 10;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Bitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(710, 478);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bitacora_lbl);
            this.Controls.Add(this.all_bt);
            this.Controls.Add(this.tournament_bt);
            this.Controls.Add(this.match_bt);
            this.Controls.Add(this.game_bt);
            this.Controls.Add(this.move_bt);
            this.Name = "Bitacora";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Bitacora_FormClosed);
            this.Load += new System.EventHandler(this.Bitacora_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button move_bt;
        private System.Windows.Forms.Button game_bt;
        private System.Windows.Forms.Button match_bt;
        private System.Windows.Forms.Button tournament_bt;
        private System.Windows.Forms.Button all_bt;
        private System.Windows.Forms.CheckBox move_cb;
        private System.Windows.Forms.CheckBox games_cb;
        private System.Windows.Forms.CheckBox matches_cb;
        private System.Windows.Forms.Label bitacora_lbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
    }
}