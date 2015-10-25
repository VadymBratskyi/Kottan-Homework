using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixResult
{
    public struct Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsSquare { get; set; }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
            IsSquare = (width == height);
        }

        public static bool operator ==(Size a1, Size a2)
        {
            if (a1.Height == a2.Height && a1.Width == a2.Width)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Size a1, Size a2)
        {
            if (a1.Height != a2.Height && a1.Width != a2.Width)
            {
                return false;
            }
            return true;
        }
       
    }
}
