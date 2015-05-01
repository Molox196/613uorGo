using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace army_go_version
{
    class Group
    {
        public List<Go_point> group;
        private Game game;
        private int turn;
        /*
        public Group(Game game)
        {
            group = new List<Go_point>();
            this.game = game;
        }
         */
        public Group(Go_point point, Game game)
        {
            group = new List<Go_point>();            
            this.game = game;
            this.turn = game.board[point.x, point.y];
            find_group(point);
        }
        private void find_group(Go_point point)
        {
            group.Add(point);
            foreach (Go_point p in point.find_neighbors())
                if (game.board[p.x, p.y] == turn && !group.Contains(p))
                    find_group(p);
        }
        public bool isdead()
        {
            foreach (Go_point point in group)            
                foreach (Go_point p in point.find_neighbors())                
                    if (game.board[p.x, p.y] != -game.board[point.x, point.y] && game.board[p.x,p.y] != game.board[point.x,point.y])                    
                        return false;                                                
            return true;
        }
    }
}
