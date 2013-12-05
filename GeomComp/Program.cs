using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeomComp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            List<System.Drawing.Point> stubPointCloud = new List<System.Drawing.Point>();
            WeakConvexHull weakCH = new WeakConvexHull();

            stubPointCloud.Add(new System.Drawing.Point(10, 10));
            stubPointCloud.Add(new System.Drawing.Point(40, 10));
            stubPointCloud.Add(new System.Drawing.Point(10, 40));
            stubPointCloud.Add(new System.Drawing.Point(11, 11));
            stubPointCloud.Add(new System.Drawing.Point(10, 30));
            stubPointCloud.Add(new System.Drawing.Point(30, 10));

            weakCH.ExecWeakAlg(stubPointCloud);
        }
    }
}
