using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Emulator
{
    public class Match : Event, IEnumerator<Combined_Moves>
    {
        public bool match_over { get; private set; }
        public Team winner { get; private set; }
        public List<Team> teams { get; private set; }
        BoardGame game;
        bool HasBeenMoveNext;
        Game g;
        Combined_Moves current;
        private int maxScore;
        public Match(): base() { }
        public void CMatch(List<Team> teams, BoardGame game, int maxScore)
        { 
            this.teams = new List<Team>();
            this.game = game;
            HasBeenMoveNext = false;
            List<Team> temp = new List<Team>();
            foreach (var item in teams)
            {
                temp.Add(item.Clone());
                teams.Add(item.Clone());
            }

            game.PartyStart(temp);
            cursor = -1;
            this.maxScore = maxScore;
        }
        public override bool EndEvent()
        {
            foreach (var item in teams)
            {
                if (item.score >= maxScore) return true;
            }
            return false;
        }
        public new Combined_Moves Current
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
        public override bool MoveNext()
        {
            match_over = EndEvent();
            if (match_over) return HasBeenMoveNext = false;
            g = new Game(teams, game);
            List<Move> moves = new List<Move>();
            foreach (var item in new Generic_Enumerable<Move>(g))
            {
                moves.Add(item);
            }
            winner = null;
            if (game.GameWinner().Length == 1) winner = game.GameWinner()[0];
            current = new Combined_Moves(moves, winner, game.Over());
            cursor++;
            return HasBeenMoveNext = true;
        }
        public override void Reset()
        {
            throw new NotImplementedException();
        }
        public override bool NextMove()
        {
            if (cursor == -1) game.GameStart(teams);
            match_over = game.Over();

            if(cursor == -1 || match_over)
            {
                game.GameStart(teams);
                g = new Game(teams, game);
                cursor++;
                match_over = false;
                winner = null;
                current = new Combined_Moves(new List<Move>(), null, match_over);
            }
            g.MoveNext();
            if (game.Over() && EndEvent()) return false;
            List<Move> moves1 = current.Move;
            moves1.Add(g.Current);
            current = new Combined_Moves(moves1, winner, match_over);
            return HasBeenMoveNext = true;
        }
    }
}
