using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GeomComp;
using System.Drawing;

namespace TestsGeomComp
{
    [TestFixture]
    public class BehaviorWeakConvexHull
    {
        WeakConvexHull weakCH;
        List<Point> stubPointCloud;

        [SetUp]
        public void SetUp()
        {
            weakCH = new WeakConvexHull();
            stubPointCloud = new List<Point>();
        }

        private List<List<Point>> _stubThreePoints()
        {
            List<List<Point>> data = new List<List<Point>>();
            List<Point> stub1 = new List<Point>();
            stub1.Add(new Point(40, 50));
            List<Point> stub2 = new List<Point>(stub1);
            stub2.Add(new Point(10, 20));
            List<Point> stub3 = new List<Point>(stub2);
            stub3.Add(new Point(200, 30));
            data.Add(stub1);
            data.Add(stub2);
            data.Add(stub3);
            return data;
        }

        [TestCaseSource("_stubThreePoints")]
        public void shouldReturnPoints_upToThreepoints(List<Point> _stubPoints)
        {
            weakCH.ExecWeakAlg(_stubPoints);

            Assert.That(weakCH.Hull, Is.EqualTo(_stubPoints));
        }

        [Test]
        public void shouldNotReturnPoints_forMinFourPoints()
        {
            stubPointCloud.Add(new Point(10, 10));
            stubPointCloud.Add(new Point(40, 10));
            stubPointCloud.Add(new Point(10, 40));
            stubPointCloud.Add(new Point(11, 11));

            weakCH.ExecWeakAlg(stubPointCloud);

            Assert.That(weakCH.Hull, Is.Not.EqualTo(stubPointCloud));
        }

        [Test]
        public void shouldReturnConvexHull_forMinFourPoints()
        {
            stubPointCloud.Add(new Point(10, 10));
            stubPointCloud.Add(new Point(40, 10));
            stubPointCloud.Add(new Point(10, 40));
            stubPointCloud.Add(new Point(11, 11));

            List<Point> stubConvexHull = new List<Point>(stubPointCloud);
            stubConvexHull.Remove(new Point(11, 11));

            weakCH.ExecWeakAlg(stubPointCloud);

            Assert.That(weakCH.Hull, Is.EquivalentTo(stubConvexHull));
        }
    }
}
