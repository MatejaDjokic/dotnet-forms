namespace Codes.Geometry
{
    class Vec3
    {
        // komponente vektora i negova duzina(magnituda)
        double _x, _y, _z, _mag;
        public double x { get { return _x; } }
        public double y { get { return _y; } }
        public double z { get { return _z; } }
        public double mag { get { return _mag; } }
        // nulti vektor
        public static Vec3 Zero { get { return new Vec3(0, 0, 0); } }
        public Vec3(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = z;
            _mag = 1;
        }
        public Vec3()
        {
            string[] str = Console.ReadLine()!.Split();
            _x = double.Parse(str[0]);
            _y = double.Parse(str[1]);
            _z = double.Parse(str[2]);
            _mag = 1;
        }
        /// <summary>
        /// Vraca vektor sa istim pravcem ali magnitudom skaliranom na interval izmedju 0 i 1
        /// </summary>
        /// <returns></returns>
        public Vec3 Normalized() =>
            new Vec3(x / mag, y / mag, z / mag);
        /// <summary>
        /// Vraca zbir vektora
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec3 plus(Vec3 other) =>
            new Vec3(
                x + other.x,
                y + other.y,
                z + other.z
                );
        /// <summary>
        /// Vraca razliku dva vektora
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec3 minus(Vec3 other) =>
            new Vec3(
                x - other.x,
                y - other.y,
                z - other.z
                );
        /// <summary>
        /// Racuna skalarni proizvod dva vektora
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public double dot(Vec3 other) =>
            _x * other._x + _y * other._y + _z * other._z;
        /// <summary>
        /// Racuna vektorski proizvod dva vektora
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vec3 cross(Vec3 other) =>
            new Vec3(
                _y * other._z - other._y * _z,
                _z * other._x - _x * other._z,
                _x * other._y - other._x * _y
                );
        public override string ToString()
        {
            return $"({x}, {y}, {y})";
        }
    }
}
