using System;
using System.Collections.Generic;

namespace testTwo
{
   
    class Vector3
    {
        public float x, y, z;

        public Vector3()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public Vector3 normalize()
        {
            Vector3 temp = new Vector3();
            temp.x = (float)(x / (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2))));
            temp.y = (float)(y / (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2))));
            temp.z = (float)(z / (Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2) + Math.Pow(z, 2))));
            return temp;
        }
    }

    class vecLineInfo
    {
        public Vector3 startPoint { get; set; }
        public Vector3 k { get; set; }
        public vecLineInfo()
        {
        }

        public vecLineInfo(Vector3 k, Vector3 startPoint)
        {
            this.startPoint = startPoint;
            this.k = k;
        }

    }
}
