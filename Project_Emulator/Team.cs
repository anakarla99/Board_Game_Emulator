using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Emulator
{
    /// <summary>
    /// Clase donde se genera un equipo con una lista de jugadores
    /// </summary>
    public class Team
    {
        public List<Player> team;
        public int score;
        public Team(List<Player> team)
        {
            this.team = team;
            score = 0;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is Team)) return false;
            bool s = false;
            for (int i = 0; i < team.Count; i++)
            {
                Team o = (Team)obj;
                s = o.team.Exists(x => x.Equals(team[i]));
            }
            return s;
        }
        public override string ToString()
        {
            string name = "";
            for (int i = 0; i < team.Count; i++)
            {
                if (i == team.Count - 1) name += team[i].name;
                name += team[i].name + " , ";
            }
            return name;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public Team Clone()
        {
            List<Player> n = team.ToList();
            int s = score;
            Team t = new Team(n);
            t.score = s;
            return t;
        }
    }
}
