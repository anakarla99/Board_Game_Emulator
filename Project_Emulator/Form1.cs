using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Project_Emulator
{
    public partial class Game_Emulator : Form
    {
        List<string> player_names;
        List<string> games;
        List<string> players_types;
        List<string> player_names_playing;
        List<string> tournaments;
        List<string> players_mode_name;
        List<Team> teams;
        List<Player> players;
        List<Tuple<int, int>> players_mode;
        BoardGame game;
        Tournament tournament;
        public Game_Emulator()
        {
            InitializeComponent();
            games = new List<string> { "Tictactoe"};
            players_types = new List<string> { "Random", "Greedy" };
            tournaments = new List<string> { "Dos_A_Dos", "Titulo" };
            player_names_playing = new List<string>();
            Assembly assembly;
            try
            {
                assembly = Assembly.Load("Reflection");

                foreach (var item in assembly.GetTypes())
                {
                    if (!item.IsAbstract && item.BaseType != null)
                    {
                        if (item.BaseType.Name == "Game") games.Add(item.Name);
                        if (item.BaseType.Name == "Player") players_types.Add(item.Name);
                        if (item.BaseType.Name == "Tournament") tournaments.Add(item.Name);
                    }

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al cargar el archivo", "Error de carga", MessageBoxButtons.OK);
            }
            game = null;
            players = new List<Player>();
            game_cb.DataSource = games;
            game_cb.SelectedItem = null;
            player_cb.DataSource = null;
            players_add_cb.Visible = false;
            max_bt.Visible = false;
            min_b.Visible = false;
            player_lb.Visible = false;
            players_types_cb.Visible = false;
            tournament_cb.DataSource = null;
        }
        private void game_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (game_cb.SelectedItem == null)
            {
                game = null;
                return;
            }
            if (game_cb.SelectedItem.ToString() == ("Tictactoe")) game = new TicTacToe();
            Assembly assembly;
            try
            {
                assembly = Assembly.Load("Reflection");
                foreach (var item in assembly.GetTypes())
                {
                    if (item.Name.Equals(game_cb.SelectedItem.ToString())) game = (BoardGame)assembly.CreateInstance(item.FullName);
                }
            }
            catch (Exception)
            {

                throw;
            }
            if(game != null)
            {
                players_mode_name = new List<string>();
                players_mode = game.teams_mode();
                string add = "";
                for (int i = 0; i < players_mode.Count; i++)
                {
                    add = players_mode[i].Item1.ToString() + " equipo(s) con " + players_mode[i].Item2.ToString() + " jugador(es)";
                    players_mode_name.Add(add);
                }
                player_names = new List<string>();
                player_cb.DataSource = null;
                player_cb.DataSource = players_mode_name;
                player_cb.SelectedItem = null;
                players_types_cb.DataSource = players_types;
                players_types_cb.SelectedItem = null;
            }
        }
        private void player_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (game == null) return;
            
            players_add_cb.Visible = true;
            max_bt.Visible = true;
            min_b.Visible = true;
            player_lb.Visible = true;
            players_types_cb.Visible = true;
            tournament_cb.DataSource = tournaments;
            tournament_cb.SelectedItem = null;

        }
        private void players_types_cb_SelectedIndexChanged(object sender, EventArgs e){}
        private void tournament_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tournament_cb.SelectedItem == null) { tournament = null; return; }
            if (tournament_cb.SelectedItem.ToString().Equals("Dos_A_Dos")) tournament = new Dos_A_Dos();
            if (tournament_cb.SelectedItem.ToString().Equals("Titulo")) tournament = new Titulo();
            Assembly assembly;
            try
            {
                assembly = Assembly.Load("Reflection");
                foreach (var item in assembly.GetTypes())
                {
                    if (item.Name.Equals(tournament_cb.SelectedItem.ToString()))
                    {
                        tournament = (Tournament)assembly.CreateInstance(item.FullName);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void next_bt_Click(object sender, EventArgs e)
        {
            if (game == null) { MessageBox.Show("Tiene que escoger un juego"); return; }
            if (players.Count == 0) { MessageBox.Show("Tiene que añadir jugadores"); return; }
            if( tournament == null) { MessageBox.Show("Tiene que escoger un torneo"); return; }
            int teams_amount = players_mode[player_cb.SelectedIndex].Item1;
            int players_amount = players_mode[player_cb.SelectedIndex].Item2;
            if (players_amount != 1 && players.Count % (teams_amount * players_amount) != 0 || players.Count < teams_amount) { MessageBox.Show("La cantidad de jugadores no es compatible con la modalidad seleccionada"); return; }
            Team team = new Team(new List<Player>());
            teams = new List<Team>();
            for (int i = 0; i < players.Count; i++)
            {
                if(teams.Count <= teams_amount)
                {
                    team.team.Add(players[i]);
                    if (team.team.Count < players_amount) continue;
                    else { teams.Add(team); team = new Team(new List<Player>()); }
                }
            }
            Bitacora b = new Bitacora();
            b.Show();
            tournament.CTournament(teams, game, teams_amount, 3);
            b.Assign_Event(tournament);
            this.Hide();
        }
        private void max_bt_Click(object sender, EventArgs e)
        {
            if (players_add_cb.Text.Trim(' ') == null) MessageBox.Show("Necesita escribir un nombre");
            if (players_types_cb.SelectedItem == null) MessageBox.Show("Necesita escoger un tipo");
            if (player_names_playing.Any(x => x.Equals(players_add_cb.Text))) return;
            Assembly assembly;
            Player add = default(Player);
            if (players_types_cb.SelectedItem.ToString().Equals("Random")) add = new RandomPlayer();
            if (players_types_cb.SelectedItem.ToString().Equals("Greedy")) add = new GreedyPlayer();
            try
            {
                assembly = Assembly.Load("Reflection");
                foreach (var item in assembly.GetTypes())
                {
                    if (item.Name.Equals(players_types_cb.SelectedItem.ToString()))
                    {
                        add = (Player)assembly.CreateInstance(item.FullName);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            add.Name(players_add_cb.Text);
            players.Add(add);
            player_names.Add(add.name);
            players_add_cb.DataSource = default(string);
            players_add_cb.DataSource = player_names;
            player_names_playing.Add(add.name);
            player_lb.DataSource = null;
            player_lb.DataSource = player_names_playing;
        }
        private void min_b_Click(object sender, EventArgs e)
        {
            if (players_add_cb.Text == null) MessageBox.Show("Necesita escribir un nombre");
            if (players_types_cb.Text == null) MessageBox.Show("Necesita escoger un tipo");
            string name = players_add_cb.Text;
            for (int i = 0; i < players.Count; i++)
            {
                if (name.Equals(players[i].name)) { player_names_playing.Remove(players[i].name); players.Remove(players[i]); player_lb.DataSource = default(string) ; player_lb.DataSource = player_names_playing; }
            }
        }
        private void Game_Emulator_Load(object sender, EventArgs e) { }
        private void players_add_cb_SelectedIndexChanged(object sender, EventArgs e) { }
        private void player_lb_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Game_Emulator_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
