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
    public class BehaviorLibConvexHull
    {
        LibConvexHull chLib;
        List<Point> stubPointCloudList;

        [SetUp]
        public void SetUp()
        {
            chLib = new LibConvexHull();
            stubPointCloudList = new List<Point>();
        }

        private List<Point> _stubThreePoints()
        {
            List<List<Point>> data = new List<List<Point>>();
            List<Point> stub = new List<Point>();
            stub.Add(new Point(40, 50));
            stub.Add(new Point(10, 20));
            stub.Add(new Point(200, 30));
            data.Add(stub);
            return stub;
        }

        [TestCaseSource("_stubThreePoints")]
        public void WeakAlg_shouldReturnPoints_forOnePoint()
        {
            stubPointCloudList.Add(new Point(40,50));

            chLib.ExecWeakAlg(stubPointCloudList);

            Assert.That(chLib.Hull, Is.EqualTo(stubPointCloudList));
        }

        [Test]
        public void WeakAlg_shouldReturnPoints_forTwoPoints()
        {
            stubPointCloudList.Add(new Point(40, 50));
            stubPointCloudList.Add(new Point(10, 20));

            chLib.ExecWeakAlg(stubPointCloudList);

            Assert.That(chLib.Hull, Is.EqualTo(stubPointCloudList));
        }

        [Test]
        public void WeakAlg_shouldReturnPoints_forThreePoints()
        {
            stubPointCloudList.Add(new Point(40, 50));
            stubPointCloudList.Add(new Point(10, 20));
            stubPointCloudList.Add(new Point(200, 30));

            chLib.ExecWeakAlg(stubPointCloudList);

            Assert.That(chLib.Hull, Is.EqualTo(stubPointCloudList));
        }

        [Test]
        public void WeakAlg_shouldNotReturnPoints_forMinFourPoints()
        {
            stubPointCloudList.Add(new Point(10, 10));
            stubPointCloudList.Add(new Point(40, 10));
            stubPointCloudList.Add(new Point(10, 40));
            stubPointCloudList.Add(new Point(11, 11));

            chLib.ExecWeakAlg(stubPointCloudList);

            Assert.That(chLib.Hull, Is.Not.EqualTo(stubPointCloudList));
        }
    }
}
