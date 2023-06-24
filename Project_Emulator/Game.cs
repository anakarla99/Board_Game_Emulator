using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Emulator
{
    /// <summary>
    /// Clase que itera por todas las jugadas de un juego
    /// </summary>
    public class Game : IEnumerator<Move>
    {
        int index;
        List<Team> teams;
        BoardGame game;
        bool HasBeenMoveNext;
        bool FirstMoveNext;
        Move current;
        public Game(List<Team> teams, BoardGame game)
        {
            index = -1;
            this.teams = teams;
            this.game = game;
            FirstMoveNext = HasBeenMoveNext = false;
            current = default(Move);
            game.GameStart(teams);
        }
        public Move Current
        {
            get
            {
                if (!FirstMoveNext) throw new Exception("No se ha realizado el primer movimiento");
                if (!HasBeenMoveNext) throw new Exception("No se ha realizado un movimiento");
                return current;
            }
        }
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }
        public void Dispose()
        {
        }
        public bool MoveNext()
        {
            FirstMoveNext = true;
            if (game.Over()) return HasBeenMoveNext = false;
            index++;
            int index_team = index % teams.Count;
            int index_player = (index / teams.Count) % teams[index_team].team.Count;
            Player a = teams[index_team].team[index_player];
            Tuple<int, int> move_tuple = a.Play(game.Moves_value(), game.Possible_moves);
            int index_tuple = game.Possible_moves.FindIndex(x => move_tuple.Equals(x));
            current = new Move(a, move_tuple, game.move_object(index_tuple));
            return HasBeenMoveNext = true;
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
    /// <summary>
    /// Clase del conjunto de todos los juegod de una partida
    /// </summary>
    public class Combined_Games
    {
        List<Combined_Moves> games;
        public Team winner_team { get; private set; }
        public bool party_over { get; private set; }
        public bool showMove { get; set; }
        public bool showGame { get; set; }
        public Combined_Games(List<Combined_Moves> games, Team winner_team, bool party_over)
        {
            showGame = true;
            showMove = true;
            this.games = games;
            if (winner_team != null) this.winner_team = winner_team.Clone();
            this.party_over = party_over;
        }
        public List<Combined_Moves> Games { get { return Copy(games); } }
        private List<Combined_Moves> Copy(List<Combined_Moves> games)
        {
            List<Combined_Moves> g = new List<Combined_Moves>();
            for (int i = 0; i < games.Count; i++)
            {
                g.Add(games[i].Clone());
            }
            return g;
        }
        public override string ToString()
        {
            string s = "";
            if (showGame)
            {
                for (int i = 0; i < games.Count; i++)
                {
                    games[i].showMove = showMove;
                    s += games[i].ToString();
                    if (i >= games.Count) continue;
                    s += "\n";
                }
                s += "\n";
            }
            if (party_over)
            {
                if (winner_team == null) s += "Han empatado";
                else s += "Ha ganado la partida " + winner_team.ToString();
            }
            return s;
        }
        public Combined_Games Clone()
        {
            Combined_Games c;
            if (winner_team != null) c = new Combined_Games(games, winner_team.Clone(), party_over);
            else c = new Combined_Games(games, winner_team, party_over);
            return c;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Combined_Games)) return false;
            Combined_Games games1 = (Combined_Games)obj;
            return EqualityComparer<List<Combined_Moves>>.Default.Equals(games, games1.games) && EqualityComparer<Team>.Default.Equals(winner_team, games1.winner_team);
        }
        public override int GetHashCode()
        {
            var hashCode = 1425138793;
            hashCode = hashCode * -2046358716 + EqualityComparer<List<Combined_Moves>>.Default.GetHashCode(games);
            hashCode = hashCode * -2046358716 + EqualityComparer<Team>.Default.GetHashCode(winner_team);
            return hashCode;
        }
    }
}
