using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Beryl.Structures
{

    [Serializable]
    public struct Vector2D : ISerializable, IXmlSerializable
    {
        private double _x;
        public double x
        {
            get
            {
                return _x;
            }
        }

        private double _y;
        public double y
        {
            get
            {
                return _y;
            }
        }


        #region Operator overloading

        //returns the dot product of the 2 vectors
        public static double operator *(Vector2D v1, Vector2D v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }

        //returns the vector multiplied by the scalar k
        public static Vector2D operator *(Vector2D v1, double k)
        {
            return new Vector2D(v1.x * k, v1.y * k);
        }

        //returns the vector multiplied by the scalar k
        public static Vector2D operator *(double k, Vector2D v1)
        {
            return new Vector2D(v1.x * k, v1.y * k);
        }

        //returns the addition of the 2 given vectors
        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x + v2.x, v1.y + v2.y);
        }

        //returns the subtraction of the 2 given vectors
        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1.x - v2.x, v1.y - v2.y);
        }

        //returns the vector multiplied by the scalar 1/k
        public static Vector2D operator /(Vector2D v, double k)
        {
            Vector2D result;
            try
            {
                result = new Vector2D(v.x / k, v.y / k);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        //converts the vector into a 3d vector (Vector3d) as (x,y,0)
        public static implicit operator Vector3D(Vector2d vector)
        {
            return new Vector3D(vector.x, vector.y, 0);
        }

        #endregion

        #region binary serialization

        //ISerializable implementation
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("x", x);
            info.AddValue("y", y);
        }

        //special constructor used during the deserialization
        public Vector2D(SerializationInfo info, StreamingContext context)
        {
            _x = info.GetDouble("x");
            _y = info.GetDouble("y");
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
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("x", x.ToString());
            writer.WriteElementString("y", y.ToString());
        }

        #endregion

        //sets base value
        public Vector2D(double x, double y)
        {
            _x = x;
            _y = y;
        }

        //returns a string with the following format: x:[xvalue] y:[yvalue]
        public override string ToString()
        {
            return "x:" + x.ToString() + " y:" + y.ToString();
        }
    }
}
