namespace Project_Emulator
{
    partial class Game_Emulator
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
            this.game_cb = new System.Windows.Forms.ComboBox();
            this.player_cb = new System.Windows.Forms.ComboBox();
            this.tournament_cb = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.min_b = new System.Windows.Forms.Button();
            this.max_bt = new System.Windows.Forms.Button();
            this.players_add_cb = new System.Windows.Forms.ComboBox();
            this.player_lb = new System.Windows.Forms.ListBox();
            this.players_types_cb = new System.Windows.Forms.ComboBox();
            this.next_bt = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // game_cb
            // 
            this.game_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.game_cb.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.game_cb.FormattingEnabled = true;
            this.game_cb.Location = new System.Drawing.Point(27, 63);
            this.game_cb.Name = "game_cb";
            this.game_cb.Size = new System.Drawing.Size(241, 27);
            this.game_cb.TabIndex = 0;
            this.game_cb.SelectedIndexChanged += new System.EventHandler(this.game_cb_SelectedIndexChanged);
            // 
            // player_cb
            // 
            this.player_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player_cb.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player_cb.FormattingEnabled = true;
            this.player_cb.Location = new System.Drawing.Point(27, 223);
            this.player_cb.Name = "player_cb";
            this.player_cb.Size = new System.Drawing.Size(241, 27);
            this.player_cb.TabIndex = 1;
            this.player_cb.SelectedIndexChanged += new System.EventHandler(this.player_cb_SelectedIndexChanged);
            // 
            // tournament_cb
            // 
            this.tournament_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tournament_cb.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tournament_cb.FormattingEnabled = true;
            this.tournament_cb.Location = new System.Drawing.Point(27, 372);
            this.tournament_cb.Name = "tournament_cb";
            this.tournament_cb.Size = new System.Drawing.Size(241, 27);
            this.tournament_cb.TabIndex = 2;
            this.tournament_cb.SelectedIndexChanged += new System.EventHandler(this.tournament_cb_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.min_b);
            this.panel1.Controls.Add(this.max_bt);
            this.panel1.Controls.Add(this.players_add_cb);
            this.panel1.Controls.Add(this.player_lb);
            this.panel1.Controls.Add(this.players_types_cb);
            this.panel1.Location = new System.Drawing.Point(286, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(452, 336);
            this.panel1.TabIndex = 3;
            // 
            // min_b
            // 
            this.min_b.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.min_b.Location = new System.Drawing.Point(231, 21);
            this.min_b.Name = "min_b";
            this.min_b.Size = new System.Drawing.Size(27, 27);
            this.min_b.TabIndex = 7;
            this.min_b.Text = "-";
            this.min_b.UseVisualStyleBackColor = true;
            this.min_b.Visible = false;
            this.min_b.Click += new System.EventHandler(this.min_b_Click);
            // 
            // max_bt
            // 
            this.max_bt.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.max_bt.Location = new System.Drawing.Point(198, 21);
            this.max_bt.Name = "max_bt";
            this.max_bt.Size = new System.Drawing.Size(27, 27);
            this.max_bt.TabIndex = 6;
            this.max_bt.Text = "+";
            this.max_bt.UseVisualStyleBackColor = true;
            this.max_bt.Visible = false;
            this.max_bt.Click += new System.EventHandler(this.max_bt_Click);
            // 
            // players_add_cb
            // 
            this.players_add_cb.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.players_add_cb.FormattingEnabled = true;
            this.players_add_cb.Location = new System.Drawing.Point(31, 21);
            this.players_add_cb.Name = "players_add_cb";
            this.players_add_cb.Size = new System.Drawing.Size(161, 27);
            this.players_add_cb.TabIndex = 4;
            this.players_add_cb.Visible = false;
            this.players_add_cb.SelectedIndexChanged += new System.EventHandler(this.players_add_cb_SelectedIndexChanged);
            // 
            // player_lb
            // 
            this.player_lb.Font = new System.Drawing.Font("Rockwell", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.player_lb.FormattingEnabled = true;
            this.player_lb.ItemHeight = 15;
            this.player_lb.Location = new System.Drawing.Point(31, 65);
            this.player_lb.Name = "player_lb";
            this.player_lb.Size = new System.Drawing.Size(392, 244);
            this.player_lb.TabIndex = 3;
            this.player_lb.Visible = false;
            this.player_lb.SelectedIndexChanged += new System.EventHandler(this.player_lb_SelectedIndexChanged);
            // 
            // players_types_cb
            // 
            this.players_types_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.players_types_cb.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.players_types_cb.FormattingEnabled = true;
            this.players_types_cb.Location = new System.Drawing.Point(264, 22);
            this.players_types_cb.Name = "players_types_cb";
            this.players_types_cb.Size = new System.Drawing.Size(159, 27);
            this.players_types_cb.TabIndex = 1;
            this.players_types_cb.Visible = false;
            this.players_types_cb.SelectedIndexChanged += new System.EventHandler(this.players_types_cb_SelectedIndexChanged);
            // 
            // next_bt
            // 
            this.next_bt.Font = new System.Drawing.Font("Rockwell", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next_bt.Location = new System.Drawing.Point(655, 436);
            this.next_bt.Name = "next_bt";
            this.next_bt.Size = new System.Drawing.Size(83, 30);
            this.next_bt.TabIndex = 1;
            this.next_bt.Text = "Next";
            this.next_bt.UseVisualStyleBackColor = true;
            this.next_bt.Click += new System.EventHandler(this.next_bt_Click);
            // 
            // Game_Emulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(768, 478);
            this.Controls.Add(this.next_bt);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tournament_cb);
            this.Controls.Add(this.player_cb);
            this.Controls.Add(this.game_cb);
            this.Name = "Game_Emulator";
            this.Text = "Game Emulator";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Game_Emulator_FormClosed);
            this.Load += new System.EventHandler(this.Game_Emulator_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox game_cb;
        private System.Windows.Forms.ComboBox player_cb;
        private System.Windows.Forms.ComboBox tournament_cb;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button next_bt;
        private System.Windows.Forms.ComboBox players_types_cb;
        private System.Windows.Forms.ListBox player_lb;
        private System.Windows.Forms.ComboBox players_add_cb;
        private System.Windows.Forms.Button max_bt;
        private System.Windows.Forms.Button min_b;
    }
}

