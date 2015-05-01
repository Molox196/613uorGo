using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace army_go_version
{
    class Go_point
    {
        public int x;
        public int y;   
     
        public Go_point(int x, int y)
        {
            this.x = x;
            this.y = y;            
        }       

         // need to add gogame to this.
        public List<Go_point> find_neighbors()
        {
            int dim = 19; // switch this to Game.dim
            List<Go_point> points = new List<Go_point>();
            if (this.x > 0)
                points.Add(new Go_point(x - 1, y));
            if (this.x < dim - 1)
                points.Add(new Go_point(x + 1, y));
            if (this.y > 0)
                points.Add(new Go_point(x, y - 1));
            if (this.y < dim - 1)
                points.Add(new Go_point(x, y + 1));
            return points;
        }

        public override string ToString()
        {
            return x.ToString() + "," + y.ToString();
        }
    }
}
