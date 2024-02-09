using System;
using System.Numerics;

namespace Codes.Geometry
{
    class Line
    {
        // tacke koje definisu liniju
        Vec2 _a, _b;
        // duzina linije
        double _len;
        public Vec2 a { get { return _a; } }
        public Vec2 b { get { return _b; } }
        public double len { get { return _len; } }
        public Line(Vec2 a, Vec2 b)
        {
            _a = a;
            _b = b;
            _len = this.a.dist(this.b);
        }
        public Line()
        {
            _a = new Vec2();
            _b = new Vec2();
            _len = a.dist(b);
        }
        public bool ContainsPoint(Vec2 p)
        {
            Vec2 AB = b.minus(a);
            Vec2 AP = p.minus(a);
            double cross = AB.cross(AP);
            if (cross == 0)
                return true;
            return false;
        }
        public Vec2? Interection(Line other)
        {
            Vec2 A = a;
            Vec2 B = b;
            Vec2 C = other.a;
            Vec2 D = other.b;

            double denominator = (A.x - B.x) * (C.y - D.y) - (A.y - B.y) * (C.x - D.x);

            // ako je denominator jednak nuli prave se ne presecaju
            if (denominator == 0)
                return null;

            double t = ((A.x - C.x) * (C.y - D.y) - (A.y - C.y) * (C.x - D.x)) / denominator;
            double u = -((A.x - B.x) * (A.y - C.y) - (A.y - B.y) * (A.x - C.x)) / denominator;

            // ako je uslov tacan prave se presecaju
            if (t >= 0 && t <= 1 && u >= 0 && u <= 1)
            {
                double x = A.x + t * (B.x - A.x);
                double y = A.y + t * (B.y - A.y);
                return new Vec2(x, y);
            }
            else
                // prave se ne presecaju
                return null;
        }

        public Orientation GetOrientation(Vec2 r)
        {
            // p i q definisu liniju
            Vec2 p = a;
            Vec2 q = b;
            // u odnosu na vrednost val gledamo da li je tacka r 
            // levo, desno ili na liniji
            double val = (q.y - p.y) * (r.x - q.x) - (q.x - p.x) * (r.y - q.y);
            if (val == 0) return Orientation.COLINEAR;
            return val > 0 ? Orientation.CLOCKWISE : Orientation.COUNTERCLOCKWISE;
        }
    }
}
