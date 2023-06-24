using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Emulator
{
    /// <summary>
    /// Esta clase es crea una jugada con un jugador, su posicion y el nomvre del objeto con el que este representandose
    /// </summary>
    public class Move
    {
        public Player player;
        public Tuple<int, int> move_posicion;
        public string play_object;

        public Move( Player player, Tuple<int, int> move_posicion,  string play_object)
        {
            this.player = player;
            this.move_posicion = move_posicion;
            this.play_object = play_object;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Move)) return false;
            Move move = (Move)obj;
            return move.move_posicion.Item1.Equals(move_posicion.Item1) && move.move_posicion.Item2.Equals(move_posicion.Item2) 
                   && play_object.Equals(move.play_object) && player.Equals(move.player);
        }
        public override int GetHashCode()
        {
            var result = 1452718923;
            result *= (-1239174723 + player.GetHashCode());
            result *= (-1239174723 + play_object.GetHashCode());
            result *= (-1239174723 + move_posicion.GetHashCode());
            return result;
        }
        public override string ToString()
        {
            return player.name + " ha jugado " + play_object + " en la posición " + move_posicion.ToString();
        }
    }
    /// <summary>
    /// Esta clase es la creacion de un juego con una lista de jugadas, el ganador y un bool que me diga si se acabo el juego o no
    /// </summary>
    public class Combined_Moves
    {
        List<Move> moves;
        Team winner_team;
        public bool game_over { get; private set; } 
        public bool showMove { get; set; }
        public Combined_Moves(List<Move> moves, Team winner_team, bool game_over)
        {
            showMove = true;
            this.moves = moves;
            if (winner_team != null) this.winner_team = winner_team.Clone();
            this.game_over = game_over;
        }
        public List<Move> Move { get { return moves.ToList(); }}
        public Team Winner_team { get { return winner_team == null ? null : winner_team; } }
        public override string ToString()
        {
            string s = "";
            if (showMove)
            {
                for (int i = 0; i < moves.Count; i++)
                {
                    s += moves[i].ToString();
                    if (i >= moves.Count) continue;
                    s += "\n";
                }
                s += "\n";
            }
            if (!game_over) return s;
            if (winner_team == null) s += "Han empatado el juego";
            else s += "Ha ganado el juego" + winner_team.ToString();
            return s;
        }
        public Combined_Moves Clone()
        {
            Combined_Moves c;
            if (winner_team != null) c = new Combined_Moves(moves, winner_team.Clone(), game_over);
            else c = new Combined_Moves(moves, winner_team, game_over);
            return c;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Combined_Moves)) return false;
            Combined_Moves moves1 = (Combined_Moves)obj;
            return EqualityComparer<List<Move>>.Default.Equals(moves, moves1.moves) && EqualityComparer<Team>.Default.Equals(winner_team, moves1.winner_team);
        }
        public override int GetHashCode()
        {
            var hashCode = 1425138793;
            hashCode = hashCode * -2046358716 + EqualityComparer<List<Move>>.Default.GetHashCode(moves);
            hashCode = hashCode * -2046358716 + EqualityComparer<Team>.Default.GetHashCode(winner_team);
            return hashCode;
        }
    }
}
