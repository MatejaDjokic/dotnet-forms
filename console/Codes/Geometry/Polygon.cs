using System.Data;

namespace Codes.Geometry
{
    class Polygon
    {
        // tacke mnogougla
        private Vec2[] _points;
        // povrsina mnogougla
        private double P { get { return Area(); } }
        // tacke mnogougla
        public List<Vec2> points { get { return _points.ToList(); } }

        public Polygon(List<Vec2> p)
        {
            _points = p.ToArray();
        }
        public Polygon(int n)
        {
            _points = new Vec2[n];
            for (int i = 0; i < n; i++)
                _points[i] = new Vec2();
        }

        public Triangle[] GetTrinagles(Vec2 point)
        {
            // niz trouglova
            Triangle[] tris = new Triangle[_points.Length];
            // za datu tacku point spajajuci po 2 incidentna temena mnogougla
            // izracunavamo sve podtrouglove mnogoula
            for (int i = 0; i < _points.Length; i++)
            {
                int j = i + 1;
                // prvo teme
                Vec2 p1 = _points[i % _points.Length];
                // drugo teme
                Vec2 p2 = _points[j % _points.Length];
                // podtrougao
                Triangle tri = new Triangle(p1, p2, point);
                tris[i] = tri;
            }
            // vracamo listu svih trouglova
            return tris;
        }
        /// <summary>
        /// Primena algoritma Gift Wrapping
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public List<Vec2> ConvexHull()
        {
            List<Vec2> points = _points.ToList();
            int n = points.Count;

            if (n < 3)
                throw new InvalidOperationException("Convex hull not possible with less than 3 points.");

            List<Vec2> convexHull = new List<Vec2>();

            int rightmostIndex = points.IndexOf(points.OrderByDescending(p => p.x).ThenByDescending(p => p.y).First());

            int currentPoint = rightmostIndex;
            int nextPoint;

            do
            {
                convexHull.Add(points[currentPoint]);
                nextPoint = (currentPoint + 1) % n;

                for (int i = 0; i < n; i++)
                {
                    if (GetOrientation(points[currentPoint], points[i], points[nextPoint]) == Orientation.COUNTERCLOCKWISE)
                    {
                        nextPoint = i;
                    }
                }

                currentPoint = nextPoint;

            } while (currentPoint != rightmostIndex);

            return convexHull;
        }
        /// <summary>
        /// Sortira tacke tako da moze da se narpavi prost mnogouga -> mnogougao kome se stranice ne preklapaju
        /// </summary>
        /// <returns></returns>
        public Vec2[] SimplePolygon()
        {
            Vec2[] points = this.points.ToArray();
            int i = 2;
            while (points[0].Collinear(points[1], points[i]))
                i++;

            Vec2[] ps = new Vec2[3] { points[0], points[1], points[i] };
            Vec2 centroid = new Triangle(ps).CalculateCentroid();

            Array.Sort(points, (t1, t2) =>
            {
                Vec2 one = new Vec2(t1.x - centroid.x, t1.y - centroid.y);
                Vec2 two = new Vec2(t2.x - centroid.x, t2.y - centroid.y);

                double angle1 = Math.Atan2(one.y, one.x);
                double angle2 = Math.Atan2(two.y, two.x);

                const double EPS = 1e-12;
                if (angle1 < angle2 - EPS)
                    return -1;
                if (angle2 < angle1 - EPS)
                    return 1;
                double d1 = centroid.sqDist(one);
                double d2 = centroid.sqDist(two);
                return d1.CompareTo(d2);
            });

            return points;
        }
        /// <summary>
        /// Proverava da li dato telo sadrzi tacku proveravajuci da li je zbir povrsina podtrouglova koji nastaju od te tacke jednak povrsini tela
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool ContainsPoint(Vec2 point)
        {
            Triangle[] triangles = this.GetTrinagles(point);
            List<double> areas = triangles.ToList().Select(tri => tri.P).ToList();
            return this.P == areas.Sum();
        }
        /// <summary>
        /// Racuna centralnu tacku mnogougla
        /// </summary>
        /// <returns></returns>
        public Vec2 CalculateCentroid()
        {
            double cx = 0, cy = 0;
            int count = _points.Length;

            foreach (Vec2 point in _points)
            {
                cx += point.x;
                cy += point.y;
            }

            return new Vec2(cx / count, cy / count);
        }
        /// <summary>
        /// Racuna povrsinu datog mnogougla
        /// </summary>
        /// <returns></returns>
        protected double Area()
        {
            Vec2 centroid = CalculateCentroid();
            Triangle[] triangles = GetTrinagles(centroid);
            List<double> areas = triangles.ToList().Select(tri => tri.P).ToList();
            return areas.Sum();
        }

        private Orientation GetOrientation(Vec2 p, Vec2 q, Vec2 r)
        {
            double val = (q.y - p.y) * (r.x - q.x) - (q.x - p.x) * (r.y - q.y);
            if (val == 0) return Orientation.COLINEAR;
            return val > 0 ? Orientation.CLOCKWISE : Orientation.COUNTERCLOCKWISE;
        }
    }
}
