using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Emulator
{
    public partial class Bitacora : Form
    {
        Tournament tournament;
        protected Event event1 { get; set; }
        Combined_Matchs combined;
        bool move;
        bool game;
        bool matches;

        public Bitacora()
        {
            InitializeComponent();
        }
        public void Assign_Event(Event event1)
        {
            if (this.event1 != null) return;
            this.event1 = event1;
            tournament_bt.Visible = (event1 is Match) ? false : true;
            match_bt.Visible = (event1 is Match) ? true : false;
            combined = new Combined_Matchs(new List<Combined_Games>(), new List<Team>(), false);
        }
        private void RefreshLabel()
        {
            if (event1 is Tournament)
            {
                Tournament tournament = event1 as Tournament;
                List<Combined_Games> match_list = combined.Matchs;
                if (match_list.Count == 0 || match_list[match_list.Count - 1].party_over)
                {
                    tournament.MoveNext();
                    match_list.Add(tournament.Current);
            }
            else match_list[match_list.Count - 1] = tournament.Current;
                combined = new Combined_Matchs(match_list, tournament.teams, tournament.tournament_over);
                bitacora_lbl.Text = null;
                bitacora_lbl.Text = combined.ToString();
            }
        }
        private void Bitacora_Load(object sender, EventArgs e){ }
        private void Bitacora_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void move_bt_Click(object sender, EventArgs e)
        {
            if (move || game || matches) return;
            if (event1.NextMove()) RefreshLabel();
           
        }

        private void game_bt_Click(object sender, EventArgs e)
        {
            if (game || matches) return;
            if ((event1 as Tournament).NextGame()) RefreshLabel();
        }
        private void match_bt_Click(object sender, EventArgs e)
        {
            if (matches) return;
            if (event1.MoveNext()) RefreshLabel();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {}

        private void all_bt_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }

        private void tournament_bt_Click(object sender, EventArgs e)
        {
            if (event1 is Tournament)
            {
                Tournament tournament = event1 as Tournament;
                List<Combined_Games> match_list = combined.Matchs;
                if (match_list.Count == 0 || match_list[match_list.Count - 1].party_over) match_list.Add(tournament.Current);
                else match_list[match_list.Count - 1] = tournament.Current;
                foreach (var item in new Generic_Enumerable<Combined_Games>(tournament))
                {
                    match_list.Add(item);
                }
                combined = new Combined_Matchs(match_list, tournament.teams, tournament.tournament_over);
                bitacora_lbl.Text = combined.ToString();
            }
        }

        private void move_cb_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
