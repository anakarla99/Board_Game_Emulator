using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Project_Emulator
{
    public abstract class Event : IEnumerator<Combined_Games>
    {
        protected int cursor;
        public virtual Combined_Games Current { get; }
        public abstract bool EndEvent();

        object IEnumerator.Current
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public abstract void Dispose();
        public abstract bool MoveNext();
        public abstract void Reset();
        public abstract bool NextMove();
    }
    public class Combined_Matchs
    {
        List<Combined_Games> matchs;
        List<Team> teams;
        string s;
        public bool tournament_over { get; private set;}
        public bool showMove { get; set; }
        public bool showGame { get; set; }
        public bool showEvent { get; set; }
        public Combined_Matchs(List<Combined_Games> matchs, List<Team> teams, bool tournament_over)
        {
            showGame = true;
            showMove = true;
            showEvent = true;
            this.matchs = matchs;
            if (teams == null) this.teams = teams;
            else
            {
                this.teams = new List<Team>();
                for (int i = 0; i < teams.Count; i++)
                {
                    this.teams.Add(teams[i].Clone());
                }
            }
            this.tournament_over = tournament_over;
        }
        public List<Combined_Games> Matchs { get { return matchs; } }
        public Combined_Matchs Clone()
        {
            Combined_Matchs c;
            if (teams != null) {
                List<Team> teams1 = new List<Team>();
                for (int i = 0; i < teams.Count; i++)
                {
                    teams1.Add(teams[i].Clone());
                }
                c = new Combined_Matchs(matchs, teams1, tournament_over);
            }
            else c = new Combined_Matchs(matchs, teams, tournament_over);
            return c;
        }
        public override string ToString()
        {
            s = "";
            if (showEvent)
            {
                for (int i = 0; i < matchs.Count; i++)
                {
                    matchs[i].showMove = showMove;
                    matchs[i].showGame = showGame;
                    s += matchs[i].ToString();
                    if (i >= matchs.Count) continue;
                    s += "\n";
                }
                s += "\n";
            }
            if (tournament_over) Give_Teams();
            return s;
        }
        private void Give_Teams()
        {
            teams.Sort(new ComparerTeams());
            int j = 1;
            for (int i = 0; i < teams.Count; i++)
            {
                if (i == 0) s += "En la posción número " + j.ToString() + " está" + teams[i].ToString();
                if (teams[i - 1].score == teams[i].score) s += "En la posción número " + j.ToString() + " está" + teams[i].ToString();
                else
                {
                    s += "En la posción número " + j.ToString() + " está" + teams[i].ToString();
                    j++;
                }
            }
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Combined_Games)) return false;
            Combined_Matchs matchs1 = (Combined_Matchs)obj;
            return EqualityComparer<List<Combined_Games>>.Default.Equals(matchs, matchs1.matchs) && EqualityComparer<List<Team>>.Default.Equals(teams, matchs1.teams);
        }
        public override int GetHashCode()
        {
            var hashCode = 1425138793;
            hashCode = hashCode * -2046358716 + EqualityComparer<List<Combined_Games>>.Default.GetHashCode(matchs);
            hashCode = hashCode * -2046358716 + EqualityComparer<List<Team>>.Default.GetHashCode(teams);
            return hashCode;
        }
    }
}
