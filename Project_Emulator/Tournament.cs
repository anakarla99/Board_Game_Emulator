using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_Emulator
{
    public class ComparerTeams : IComparer<Team>
    {
        public int Compare(Team x, Team y)
        {
            return x.score.CompareTo(y.score);
        }
    }
    public class Generic_Enumerable<T> : IEnumerable<T>
    {
        IEnumerator<T> enumerator;
        public Generic_Enumerable(IEnumerator<T> enumerator) { this.enumerator = enumerator; }
        public List<Team> list;
        public void Take(List<Team> list)
        { this.list = list; }
        public IEnumerator<T> GetEnumerator()
        {
            return enumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    /// <summary>
    /// Clase abstracta en la que se genera un torneo
    /// </summary>
    abstract public class Tournament : Event, IEnumerator<Combined_Games>
    {
        public List<Team> teams { get; private set; }
        protected BoardGame game;
        protected int teams_amount;
        protected List<List<Team>> party_list;
        protected int maxScore;
        public Team winner { get; private set; }
        public bool tournament_over;
        bool HasBeenMoveNext;
        Combined_Games current;
        Match p;
        int index;
        int[] score;
        
        public Tournament() { }
        public void CTournament(List<Team> teams, BoardGame game, int teams_amount, int maxScore)
        {
            this.teams = teams;
            this.game = game;
            this.teams_amount = teams_amount;
            party_list = new List<List<Team>>();
            index = 0;
            cursor = -1;
            winner = null;
            HasBeenMoveNext = false;
            this.maxScore = maxScore;
        }
        public override Combined_Games Current
        {
            get
            {
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
        public override void Dispose() { }
        public abstract void Party_planner();
        public override void Reset() { }
        public override bool MoveNext()
        {
            Party_planner();
            tournament_over = false;
            if (index == party_list.Count) { tournament_over = true; return HasBeenMoveNext = false; }
            List<Team> actual_play = party_list[index];
            List<Combined_Games> games = new List<Combined_Games>();
            Match p = new Match();
            p.CMatch(actual_play, game, maxScore);
            foreach (var item in new Generic_Enumerable<Combined_Games>(p))
            {
                games.Add(item);
            }
            foreach (var item in games)
            {
                current = item;
            }
            cursor++;
            index++;
            return HasBeenMoveNext = true;
        }
        public override bool NextMove()
        {
            Party_planner();
            tournament_over = (current == null) ? false : current.party_over;
            if (cursor == -1 || tournament_over) CreateNewEvent();
            p.NextMove();
            if (tournament_over && (index == teams.Count)) return HasBeenMoveNext = false;
            List<Combined_Moves> combined_moves = (current == null) ? new List<Combined_Moves>() : current.Games;
            if (combined_moves.Count == 0 || combined_moves[combined_moves.Count - 1].game_over) combined_moves.Add(p.Current);
            else combined_moves[combined_moves.Count - 1] = p.Current;
            current = new Combined_Games(combined_moves, p.winner, p.match_over);
            return HasBeenMoveNext = true;
        }
        public virtual void CreateNewEvent()
        {
            List<Team> actual_play = party_list[index];
            List<Combined_Games> games = new List<Combined_Games>();
            p = new Match();
            cursor ++;
            p.CMatch(actual_play, game, maxScore);
            foreach (var item in new Generic_Enumerable<Combined_Games>(p))
            {
                games.Add(item);
            }
        }
        public bool NextGame()
        {
            Party_planner();
            tournament_over = (current == null) ? false : current.party_over;
            if (cursor == -1 || tournament_over) CreateNewEvent();
            p.MoveNext();
            if (tournament_over && (index == teams.Count)) return HasBeenMoveNext = false;
            List<Combined_Moves> combined_moves = current.Games;
            if (combined_moves.Count == 0 || combined_moves[combined_moves.Count - 1].game_over) combined_moves.Add(p.Current);
            else combined_moves[combined_moves.Count - 1] = p.Current;
            current = new Combined_Games(combined_moves, p.winner, p.match_over);
            return true;
        }
        public override bool EndEvent()
        {
            foreach (var item in teams)
            {
                if (item.score >= maxScore) return true;
            }
            return false;
        }
    }
    public class Dos_A_Dos : Tournament
    {
        public override void Party_planner()
        {
            Party_planner(teams_amount, new List<Team>(), 0);
        }
        private void Party_planner(int k, List<Team> comb,int index1)
        {
            if (k < 1)
            {
                List<Team> n = new List<Team>();
                for (int i = 0; i < comb.Count; i++)
                {
                    n.Add(comb[i].Clone());
                }
                party_list.Add(n);
                return;
            }
            if (index1 == teams.Count && k > -1) return;
            comb.Add(teams[index1]);
            Party_planner(k - 1, comb, index1 + 1);
            comb.Remove(teams[index1]);
            Party_planner(k, comb, index1 + 1);
        }
    }
    public class Titulo : Tournament
    {
        public override void Party_planner()
        {
            Team titel = null;
            List<Team> teams1 = new List<Team>();
            for (int i = 0; i < teams.Count; i++)
            {
                teams1.Add(teams[0]);
            }
            if (winner == null)
            {
                Random a = new Random();
                titel = teams[a.Next(0, teams.Count - 1)];
                teams1.Remove(titel);
            }
            else
            {
                if (winner == titel) return;
                else
                {
                    titel = winner;
                    teams1.Remove(titel);
                }
            }
            Party_planner(teams_amount, new List<Team>(), 0, teams1, titel);
        }
        private void Party_planner(int k, List<Team> comb, int index1, List<Team> teams1, Team titel)
        {
            if (index1 == teams1.Count && k > 0) return;
            if (k < 1) { comb.Add(titel); party_list.Add(comb); return; }
            comb.Add(teams[index1]);
            Party_planner(k - 1, comb, index1 + 1, teams1, titel);
            comb.Remove(teams[index1]);
            Party_planner(k, comb, index1 + 1, teams1, titel);
        }

        public override void CreateNewEvent()
        {
            Party_planner();
            base.CreateNewEvent();
        }
    }
}
