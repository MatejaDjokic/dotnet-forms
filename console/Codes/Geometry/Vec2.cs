using System.Diagnostics;
using System.Linq.Expressions;

namespace Codes.Geometry
{
    class Vec2
    {
        // x i y kordinate tacke(vektora) i njegova duzina(magnituda)
        double _x, _y, _mag;
        public double x { get { return _x; } }
        public double y { get { return _y; } }
        public double mag { get { return _mag; } }
        // nulti vektor
        public static Vec2 Zero { get { return new Vec2(0, 0); } }

        public Vec2(double x, double y)
        {
            _x = x;
            _y = y;
            _mag = 1;
        }
        public Vec2()
        {
            string[] str = Console.ReadLine()!.Split();
            _x = double.Parse(str[0]);
            _y = double.Parse(str[1]);
            _mag = 1;
        }

        /// <summary>
        /// Vraca vektor sa istim pravcem ali magnitudom skaliranom na interval izmedju 0 i 1
        /// </summary>
        /// <returns></returns>
        public Vec2 Normalized() =>
            new Vec2(x / mag, y / mag);
        /// <summary>
        /// Racuna distancu(razdaljinu) izdmedju dve tacke(vektora)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double dist(Vec2 other) =>
            Math.Sqrt(dist(other));
        /// <summary>
        /// Racuna kvadratnu distancu(razdaljinu) izdmedju dve tacke(vektora)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double sqDist(Vec2 other) =>
            (x - other.x) * (x - other.x) + (y - other.y) * (y - other.y);
        /// <summary>
        /// Vraca zbir dva vektora
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec2 plus(Vec2 other) =>
            new Vec2(
                x + other.x,
                y + other.y
                );
        /// <summary>
        /// Vraca razliku dva vektora
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec2 minus(Vec2 other) =>
            new Vec2(
                x - other.x,
                y - other.y
                );
        /// <summary>
        /// Racuna skalarni proizvod dva vektora
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double dot(Vec2 other) =>
            _x * other._x + _y * other._y;
        /// <summary>
        /// Racuna vektorski proizvod dva vektora
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double cross(Vec2 other) =>
            x * other.y - y * other.x;
        /// <summary>
        /// Racuna maksimalnu distancu izmdju sebe i liste vektora
        /// </summary>
        /// <param name="others"></param>
        /// <returns></returns>
        public Tuple<Vec2, double> maxDist(Vec2[] others)
        {
            Vec2 vector = Zero;
            double maxDistance = double.MinValue;

            others.ToList().ForEach(other =>
            {
                double dist = this.dist(other);
                if (dist > maxDistance)
                {
                    maxDistance = dist;
                    vector = other;
                }
            });

            Tuple<Vec2, double> tuple = Tuple.Create(vector, maxDistance);
            return tuple;
        }
        /// <summary>
        /// Racuna minimalnu distancu izmdju sebe i liste vektora
        /// </summary>
        /// <param name="others"></param>
        /// <returns></returns>
        public Tuple<Vec2, double> minDist(Vec2[] others)
        {
            Vec2 vector = Zero;
            double minDistance = double.MaxValue;

            others.ToList().ForEach(other =>
            {
                double dist = this.dist(other);
                if (dist < minDistance)
                {
                    minDistance = dist;
                    vector = other;
                }
            });

            Tuple<Vec2, double> tuple = Tuple.Create(vector, minDistance);
            return tuple;
        }
        /// <summary>
        /// Racuna da li su dva vektora kolinearna
        /// </summary>
        /// <param name="other1"></param>
        /// <param name="other2"></param>
        /// <returns></returns>
        public bool Collinear(Vec2 other1, Vec2 other2) =>
            (x - other1.x) * (y - other2.y) == (y - other1.y) * (x - other2.x);
        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}