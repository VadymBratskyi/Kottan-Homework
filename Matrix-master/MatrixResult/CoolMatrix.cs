using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MatrixResult
{
    public struct CoolMatrix
    {
        public Size Size { get; set; }
        public bool IsSquare { get; set; }
        public int[,] arr;
    

        public CoolMatrix (int [,] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }
            this.arr = arr;
            Size = new Size {Width = arr.GetLength(0), Height = arr.GetLength(1)};
            IsSquare = (Size.Width == Size.Height);
        }

        public static implicit operator CoolMatrix(int[,] arr)
        {
            return new CoolMatrix(arr);
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i < Size.Width; i++)
            {
                for (int j = 0; j < Size.Height; j++)
                {
                    if (j == 0)
                    {
                        str += "[";
                    }
                    else
                    {
                        str += ", ";
                    }
                    str += arr[i, j];
                }
                if (i!=Size.Width-1)
                {
                    str += "]"+Environment.NewLine;
                }
                else
                {
                    str += "]";
                }
            }
            return str;
        }

        public int this[int w, int h]
        {
            set { arr[w, h] = value; }
            get {
                if (w > Size.Width || w < 0 || h > Size.Height || h < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return arr[w, h]; }
        }

        public static bool operator ==(CoolMatrix a1, CoolMatrix a2)
        {
            if (a1.Size.Width != a2.Size.Width){return false;}
            if (a1.Size.Height != a2.Size.Height){return false;}
           

            for (int i = 0; i < a1.Size.Width; i++)
            {
                for (int j = 0; j < a2.Size.Height; j++)
                {
                    if (a1.arr[i,j] != a2.arr[i,j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator !=(CoolMatrix a1, CoolMatrix a2)
        {
            return !(a1 == a2);
        }

        public static CoolMatrix operator *(CoolMatrix cool, int val)
        {
            CoolMatrix matrixRes = new int[cool.Size.Width,cool.Size.Height];

            for (int i = 0; i < cool.Size.Width; i++)
            {
                for (int j = 0; j < cool.Size.Height; j++)
                {
                    matrixRes.arr[i, j] = cool.arr[i, j] * val;
                }
            }

            return matrixRes;
        }

        public override bool Equals(object obj)
        {
            CoolMatrix cool = (CoolMatrix) obj;

            if (cool.Size.Width != this.Size.Width) { return false; }
            if (cool.Size.Height != this.Size.Height) { return false; }


            for (int i = 0; i < cool.Size.Width; i++)
            {
                for (int j = 0; j < this.Size.Height; j++)
                {
                    if (cool.arr[i, j] != this.arr[i, j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static CoolMatrix operator +(CoolMatrix a1, CoolMatrix a2)
        {
            if (a1.Size.Width != a2.Size.Width || a1.Size.Height != a2.Size.Height){
                throw new ArgumentException();                
            }

           CoolMatrix matrixResSum = new int[a1.Size.Width, a1.Size.Height];

            for (int i = 0; i < a1.Size.Width; i++)
            {
                for (int j = 0; j < a2.Size.Height; j++)
                {
                    matrixResSum.arr[i, j] = a1.arr[i, j] + a2.arr[i,j];
                }
            }

            return matrixResSum;
        }

        public CoolMatrix Transpose()
        {
            var temMatrix = new int[arr.GetLength(1), arr.GetLength(0)];
            
            for (int i = 0; i < temMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < temMatrix.GetLength(1); j++)
                {
                    temMatrix[i, j] = arr[j, i];
                }
            }

            return temMatrix;
        }

        public static CoolMatrix operator *(CoolMatrix m1, CoolMatrix m2)
        {
            CoolMatrix matrixRes = new int[m1.Size.Width, m2.Size.Height];

            for (int i = 0; i < m1.Size.Height; i++)
            {
                for (int j = 0; j < m2.Size.Width; j++)
                {
                    for (int k = 0; k < m1.Size.Width; k++)
                    {
                        matrixRes.arr[i, k] += m1.arr[i, j] * m2.arr[j, k];
                    }
                }
            }

            return matrixRes;
        }
    }
}

