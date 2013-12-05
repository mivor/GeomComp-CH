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

        public void ExecWeakAlg(List<Point> _pointList)
        {
            if (_pointList.Count < 4)
            {
                this.Hull = _pointList; 
            }
        }
    }
}
