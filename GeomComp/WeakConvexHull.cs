using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GeomComp
{
    public class WeakConvexHull
    {
        public List<Point> Hull { get; private set; }

        private bool isPointAtRightSide(Point p, Point q, Point find)
        { 
            int delta = (p.X * q.X) + (p.Y * find.X) + (q.X * find.Y)
                        - (find.X * q.Y) - (q.X * p.Y) - (p.X * find.Y);
            return delta >= 0;
        }

        public void ExecWeakAlg(List<Point> pointList)
        {
            if (pointList.Count < 4)
            {
                this.Hull = pointList;
                return;
            }

            foreach (Point p in pointList)
            {
                foreach (Point q in pointList)
                {
                    if (p != q)
                    {
                        bool valid = true;
                        foreach (Point r in pointList)
                        {
                            if ( (r != q) && (r != p))
                            {
                                if (isPointAtRightSide(p, q, r)) valid = false;
                            }
                        }

                        if (valid)
                        {
                            if (this.Hull.Contains(p)) this.Hull.Add(q);
                            else this.Hull.Add(p);
                        }
                    }
                }
            }
        }
    }
}
