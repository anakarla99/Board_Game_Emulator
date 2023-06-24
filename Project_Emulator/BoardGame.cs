using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Emulator
{
    /// <summary>
    /// Clase abstracta en la cual se genera un juego de mesa para jugar
    /// </summary>
    abstract public class BoardGame
    {
        protected List<Tuple<int, int>> possible_moves;
        public List<Tuple<int, int>> Possible_moves
        {
            get
            {
                List<Tuple<int, int>> result = new List<Tuple<int, int>>();
                foreach (var item in possible_moves)
                    result.Add(new Tuple<int, int>(item.Item1, item.Item2));
                return result;
            }
        }
        public BoardGame() { }
        public abstract void PartyStart(List<Team> teams);
        public abstract void GameStart(List<Team> teams);
        public abstract List<int> Moves_value();
        public abstract string move_object(int i);
        public abstract Team[] GameWinner();
        public abstract Team[] partyWinner();
        public abstract bool Over();
        public abstract List<Tuple<int, int>> teams_mode();

    }
    /// <summary>
    /// Juego de cero o cruz
    /// </summary>
    public class TicTacToe : BoardGame
    {
        
        public List<Team> teams;
        int[,] board;
        int actual_player;
        bool tie;
        int t;

        public TicTacToe() : base() { }
        public override void GameStart( List<Team> teams)
        {
            if (teams.Count > 2) throw new Exception("No se puede jugar con mas de dos jugadores");
            if (teams.Count == 1) throw new Exception("No se puede jugar con un solo jugador");
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].team.Count > 1) throw new Exception("Este juego no se puede jugar por equipos");
            }
            this.teams = teams;
            board = new int[3, 3];
            actual_player = 1;
            possible_moves = new List<Tuple<int, int>>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    possible_moves.Add(Tuple.Create(i, j));
                }
            }
            tie = false;
            t = 9;
        }

        public override Team[] GameWinner()
        {
            if(tie) {
                Team[] winners = new Team[2];
                winners[0] = teams[0];
                winners[1] = teams[1];
                teams[0].score += 1;
                teams[1].score += 1;
                return winners;
            }
            Team[] winner = new Team[1];
            winner[0] = actual_player == 1 ? teams[0] : teams[1];
            teams[actual_player == 1? 0: 1].score += 2;
            return winner;
        }

        public override string move_object(int i)
        {
            board[possible_moves[i].Item1, possible_moves[i].Item2] = actual_player;
            int I1 = possible_moves[i].Item1;
            int I2 = possible_moves[i].Item2;
            possible_moves.Remove(possible_moves[i]);
            actual_player = actual_player == 1 ? 2 : 1;
            t--;
            return actual_player == 1 ?"cero" : "cruz";
        }

        public override bool Over()
        {
            if ((board[0, 0] == board[1, 1] && board[0, 0] == board[2, 2] && board[0,0] != 0) || (board[2, 0] == board[1, 1] && board[2, 0] == board[0, 2] && board[2, 0] != 0))
                return true;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if ((board[i, 0] == board[i, 1] && board[i, 0] == board[i, 2] && board[i, 0] != 0) || (board[0, i] == board[1, i] && board[0, i] == board[2, i] && board[0, i] != 0))
                    return true;
            }
            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0) return false;
                }

            return tie = true;
        }
        public override void PartyStart(List<Team> teams) { GameStart(teams); }

        public override Team[] partyWinner(){ return GameWinner();}

        public override List<int> Moves_value()
        {
            Tuple<bool, Tuple<int,int>> cw = CanWin();
            List<int> pm = new List<int>();
            if (cw.Item1){
                    Tuple<int, int> bm = cw.Item2;
                    for (int i = 0; i < possible_moves.Count; i++)
                    {
                        if (possible_moves[i].Item1 == bm.Item1 && possible_moves[i].Item2 == bm.Item2)
                            pm.Add(1);
                        else pm.Add(0);
                    }
            }
            else
            {
                for (int i = 0; i < t; i++)
                {
                    pm.Add(0);
                }
            }
            return pm;
        } 

        public Tuple<bool,Tuple<int,int>> CanWin()
        {
            List<Tuple<bool, Tuple<int,int>>> s = new List<Tuple<bool, Tuple<int,int>>>();
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, 0] != 0){
                    if (board[i, 0] == board[i, 1] && board[i,2] == 0)
                    {
                        if (board[i, 0] == actual_player)
                            return Tuple.Create(true, Tuple.Create(i, 2));
                        else s.Add(Tuple.Create(true, Tuple.Create(i, 2)));
                    }
                    if(board[i, 0] == board[i, 2] && board[i,1] == 0)
                    {
                        if (board[i, 0] == actual_player)
                            return Tuple.Create(true, Tuple.Create(i, 1));
                        else s.Add(Tuple.Create(true, Tuple.Create(i, 1)));
                    }
                }
                if (board[i, 1] == board[i, 2] && board[i, 1] != 0 && board[i,0] == 0)
                {
                    if (board[i, 1] == actual_player)
                        return Tuple.Create(true, Tuple.Create(i, 0));
                    else s.Add(Tuple.Create(true, Tuple.Create(i, 0)));
                }
                if(board[0, i] != 0){
                    if (board[0, i] == board[1, i] && board[2,i] == 0) 
                    {
                        if (board[0, i] == actual_player)
                            return Tuple.Create(true, Tuple.Create(2, i));
                        else s.Add(Tuple.Create(true, Tuple.Create(2, i))); 
                    }
                    if(board[0, i] == board[2, i] && board[1,i] == 0)
                    {
                        if (board[0, i] == actual_player)
                            return Tuple.Create(true, Tuple.Create(1, i));
                        else s.Add(Tuple.Create(true, Tuple.Create(1, i)));
                    }
                }
                if (board[1, i] == board[2, i] && board[1, i] != 0 && board[0,i] == 0)
                {
                    if (board[1, i] == actual_player)
                        return Tuple.Create(true, Tuple.Create(0, i));
                    else s.Add(Tuple.Create(true, Tuple.Create(0, i)));
                }
            }
            if(board[1,1] != 0)
            {
                if(board[1,1] == board[2,2] && board[0,0] == 0)
                {
                    if (board[1, 1] == actual_player) return Tuple.Create(true, Tuple.Create(0, 0));
                    else s.Add(Tuple.Create(true, Tuple.Create(0, 0)));
                }
                if(board[1,1] == board[0,0] && board[2,2] == 0)
                {
                    if (board[1, 1] == actual_player) return Tuple.Create(true, Tuple.Create(2, 2));
                    else s.Add(Tuple.Create(true, Tuple.Create(2, 2)));
                }
                if(board[1,1] == board[0,2] && board[2,0] == 0)
                {
                    if (board[1, 1] == actual_player) return Tuple.Create(true, Tuple.Create(2, 0));
                    else s.Add(Tuple.Create(true, Tuple.Create(2, 0)));
                }
                if(board[1,1] == board[2,0] && board[0,2] == 0)
                {
                    if (board[1, 1] == actual_player) return Tuple.Create(true, Tuple.Create(0, 2));
                    else s.Add(Tuple.Create(true, Tuple.Create(0, 2)));
                }
            }
            else
            {
                if((board[0,0] == board[2,2] && board[0,0] != 0) || (board [0,2] == board[2,0] && board[0,2] != 0))
                    if (board[0,0] == actual_player || board[0,2] == actual_player) return Tuple.Create(true, Tuple.Create(1, 1));
                    else s.Add(Tuple.Create(true, Tuple.Create(1, 1)));
            }
            if(s.Count != 0)
            {
                Random a = new Random();
                return s[a.Next(s.Count - 1)];
            }
            return Tuple.Create(false, Tuple.Create(-1,-1));
        }

        public override List<Tuple<int, int>> teams_mode()
        {
            return new List<Tuple<int, int>> { new Tuple<int, int>(2, 1) };
        }
    }

}
