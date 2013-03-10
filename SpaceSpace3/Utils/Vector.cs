using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Utils
{
    public class Vector
    {
        private float _X;
        private float _Y;
        private float _Z;

        public static Vector cop_YVector(Vector v)
        {
            return new Vector(v.X, v.Y);
        }

        public float Y
        {
            get { return _Y; }
            set { _Y = value; }
        }
        public float X
        {
            get { return _X; }
            set { _X = value; }
        }
        public float Z
        {
            get { return _Z; }
            set { _Z = value; }
        }

        public Vector()
        {
            _Z = _Y = _X = 0;
        }
        public Vector(float x, float y)
        {
            _X = x;
            _Y = y;
            _Z = 0;
        }
        public Vector(float x, float y, float z)
        {
            _X = x;
            _Y = y;
            _Z = Z;
        }

        public Vector(Vector location)
        {
            this.X = location.X;
            this.Y = location.Y;
            this.Z = location.Z;
        }

        public static Vector Zero = new Vector();

        public Vector2 toVector2()
        {
            return new Vector2(_X, _Y);
        }

        public Vector3 toVector3()
        {
            return new Vector3(_X, _Y, _Z);
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1._X + v2._X, v1._Y + v2._Y, v1._Z + v2._Z);
        }
        public static Vector operator +(Vector v1, float f)
        {
            return new Vector(v1._X + f, v1._Y + f, v1._Z + f);
        }

        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1._X - v2._X, v1._Y - v2._Y);
        }
        public static Vector operator -(Vector v1, float f)
        {
            return new Vector(v1._X - f, v1._Y - f);
        }

        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1._X * v2._X, v1._Y * v2._Y, v1._Z * v2._Z);
        }
        public static Vector operator *(Vector v1, float f)
        {
            return new Vector(v1._X * f, v1._Y * f, v1._Z * f);
        }
        /*public static bool operator >(Vector v1, Vector v2)
        {
            return v1.Magnitude > v2.Magnitude;
        }
        public static bool operator <(Vector v1, Vector v2)
        {
            return v1.Magnitude < v2.Magnitude;
        }
        public static bool operator <=(Vector v1, Vector v2)
        { return v2 > v1; }
        public static bool operator >=(Vector v1, Vector v2)
        { return v2 < v1; }*/

        public static Vector operator /(Vector v1, Vector v2)
        {
            return new Vector(v1._X / v2.X, v1._Y / v2.Y, v1._Z / v2.Z);
        }
        public static Vector operator /(Vector v1, float f)
        {
            return new Vector(v1._X / f, v1._Y / f, v1._Z / f);
        }

        public override string ToString()
        {
            return ("{Vector: " + _X + ", " + _Y + ", " + _Z + "}");
        }

    }
}
