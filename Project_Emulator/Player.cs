using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Emulator
{
    /// <summary>
    /// Clase abstracta en la cual se genera un jugador
    /// </summary>
    abstract public class Player
    {
        public string name { get; private set; }
        public Player() { }
        public override bool Equals(object obj)
        {
            if (!(obj is Player)) return false;

            return name.Equals((obj as Player).name);
        }
        public override int GetHashCode()
        {
            int result = 1243622490;
            result *= (-1432318054 + name.GetHashCode());
            return result;
        }
        public override string ToString()
        {
            return name;
        }
        public void Name ( string player_name)
        {
            if (name != null || player_name.Equals("")|| player_name == null) return;
            name = player_name;
        }
        public abstract Tuple<int, int> Play(List<int> moves_values, List<Tuple<int, int>> possibles_moves);
    }
    /// <summary>
    /// Clase de jugador que juega aleatoriamente
    /// </summary>
    class RandomPlayer : Player
    {
        public RandomPlayer() : base() { }
        public override Tuple<int,int> Play(List<int> moves_values, List<Tuple<int, int>> possibles_moves)
        {
            List<int> moves_value = moves_values;
            List<Tuple<int, int>> possible_move = possibles_moves;
            Random a = new Random();
            return possible_move.ElementAt(a.Next(moves_value.Count - 1));
        }
    }
    /// <summary>
    /// Clase de jugador que juega de manera que siempre quiera ganar
    /// </summary>
    class GreedyPlayer : Player
    {
        public GreedyPlayer(): base() { }
        public override Tuple<int, int> Play(List<int> moves_values, List<Tuple<int, int>> possibles_moves)
        {
            List<int> moves_value = moves_values;
            List<Tuple<int, int>> possible_move = possibles_moves;
            int best = -1;
            List<int> best_moves = new List<int>();
            for (int i = 0; i < moves_value.Count; i++)
            {
                if(best < moves_value[i])
                {
                    best = moves_value[i];
                    best_moves.Clear();
                }
                if (best == moves_value[i])
                    best_moves.Add(i);
            }
            Random a = new Random();
            return possible_move.ElementAt(best_moves[a.Next(best_moves.Count - 1)]);
        }
    }
}
