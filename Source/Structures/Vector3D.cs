using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Beryl.Structures
{
    public struct Vector3D : IXmlSerializable, ISerializable
    {
        private double _x;
        public double x
        {
            get { return _x; }
        }

        private double _y;
        public double y
        {
            get { return _y; }
        }

        private double _z;
        public double z
        {
            get
            {
                return _z;
            }
        }

        //returns the addition of the 2 given vectors
        public static Vector3D operator +(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.x + vector2.x, vector1.y + vector2.y, vector1.z + vector2.z);
        }

        //returns the subtraction of the 2 given vectors
        public static Vector3D operator -(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.x - vector2.x, vector1.y - vector2.y, vector1.z - vector2.z);
        }

        //returns the dot product of the 2 vectors
        public static double operator *(Vector3D vector1, Vector3D vector2)
        {
            return vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
        }

        //returns the vector multiplied by the scalar k
        public static Vector3D operator *(Vector3D vector, double k)
        {
            return new Vector3D(vector.x * k, vector.y * k, vector.z);
        }

        //returns the vector multiplied by the scalar 1/k
        public static Vector3D operator /(Vector3D vector, double k)
        {
            return new Vector3D(vector.x / k, vector.y / k, vector.z / k);
        }

        //converts the vector into a 2d vector (Vector2d) as (x,y)
        public static explicit operator Vector2D(Vector3D vector)
        {
            return new Vector2D(vector.x, vector.y);
        }

        //returns the cross product of the 2 vectors
        public static Vector3D CrossProduct(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.y * vector2.z - vector1.z * vector2.y, vector1.z * vector2.x - vector1.x * vector2.z, vector1.x * vector2.y - vector1.y * vector2.x);
        }

        #region binary serialization

        //ISerializable implementation

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("x", x);
            info.AddValue("y", y);
            info.AddValue("z", z);
        }

        //special constructor used during the deserialization
        public Vector3D(SerializationInfo info, StreamingContext context)
        {
            _x = info.GetDouble("x");
            _y = info.GetDouble("y");
            _z = info.GetDouble("z");
        }

        #endregion

        #region xml serialization

        //IXmlSerializable implementation

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            _x = Convert.ToDouble(reader.ReadInnerXml());
            _y = Convert.ToDouble(reader.ReadInnerXml());
            _z = Convert.ToDouble(reader.ReadInnerXml());
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("x", x.ToString());
            writer.WriteElementString("y", y.ToString());
            writer.WriteElementString("z", z.ToString());
        }

        #endregion

        //sets base value
        public Vector3D(double x, double y, double z)
        {
            _x = x;
            _y = y;
            _z = y;
        }

        //returns a string with the following format: x:[xvalue] y:[yvalue] z:[zvalue]
        public override string ToString()
        {
            return "x:" + x.ToString() + " y:" + y.ToString();
        }
    }
}
