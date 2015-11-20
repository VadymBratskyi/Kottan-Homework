using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ButtleBoats;

namespace ButtleBoats
{


    public class Boats
    {
        public uint X { get; protected set; }
        public uint Y { get; protected set; }
        public uint Length { get; protected set; }
        
        public Direction Direction { get; protected set; }

        protected Boats(uint x, uint y)
        {
            X = x;
            Y = y;
        }
        protected Boats(uint x, uint y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
        protected Boats(uint x, uint y, uint length, Direction direction)
        {
            X = x;
            Y = y;
            Length = length;
            Direction = direction;
        }

        public static Boats Parse(string notation)
        {
            const string reg = @"^([A-Ja-j]{1})+(\d|\d{2})$|^([A-Ja-j]{1})+(\d|\d{2})+([x])(\d)+(.?)$";

            if (string.IsNullOrEmpty(notation) || !Regex.IsMatch(notation, reg))
            {
                throw new NotABoatException("It isn't boat");
            }

            var rez = Regex.Split(notation, reg).Where(s => s != string.Empty).ToArray();

            var nX = (uint)char.Parse(rez[0])-64;
            var nY = uint.Parse(rez[1]);
            if (nY < 1 || nY > 10)
            {
                throw new NotABoatException("Error position!!");
            }
            
            var length = rez.Length > 2 ? uint.Parse(rez[3]) : 1;
            var direction = rez.Length > 4 && rez[4] == "|" ? Direction.Vertical : Direction.Horizontal;

            switch (length)
             {
                 case 1: return new PatrolBoat(nX,nY,length,direction);
                 case 2: return new Cruiser(nX, nY, length, direction);
                 case 3: return new Submarine(nX,nY, length, direction);
                 case 4: return new AircraftCarrier(nX, nY, length, direction);
                default: throw new NotABoatException("Error size");
             }
        }

        public static bool TryParse(string notation, out Boats pos)
        {
            try
            {
                pos = Parse(notation);
                return true;
            }
            catch (NotABoatException)
            {
                pos = null;
                return false;
            }
        }

        public bool FitsInSquare(byte squareHeight, byte squareWidth)
        {
            if (Direction == Direction.Horizontal)
            {
                return X + (Length - 1) <= squareWidth && Y <= squareHeight;
            }
            return X <= squareWidth && Y + (Length - 1) <= squareHeight;
        }

        public bool OverlapsWith(Boats pos2)
        {
            switch (Direction)
            {
                case Direction.Horizontal:
                    if (Math.Abs((int)Y - (int)pos2.Y) > 1)
                    {
                        return false;
                    }
                    return Enumerable.Range((int)X, (int)Length)
                            .Any(
                                thisX =>
                                    Enumerable.Range((int)pos2.X, (int)pos2.Length)
                                        .Any(otherX => Math.Abs(thisX - otherX) < 2));
                case Direction.Vertical:
                    if (Math.Abs((int)X - (int)pos2.X) > 1)
                    {
                        return false;
                    }
                    return Enumerable.Range((int)Y, (int)Length)
                            .Any(
                                thisY =>
                                    Enumerable.Range((int)pos2.Y, (int)pos2.Length)
                                        .Any(otherY => Math.Abs(thisY - otherY) < 2));
                default:
                    throw new ArgumentOutOfRangeException();
            }

            //IEnumerable<int> num1;
            //IEnumerable<int> num2;

            //var val1 = "";
            //var val2 = "";

            //switch (Direction)
            //{
            //    case Direction.Horizontal:
            //        num1 = Enumerable.Range((int)X, (int)Length);
            //        val1 = EnumerableToString(num1, Direction, (int)X, (int)Y);
            //        break;
            //    case Direction.Vertical:
            //        num1 = Enumerable.Range((int)Y, (int)Length);
            //        val1 = EnumerableToString(num1, Direction, (int)X, (int)Y);
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException();
            //}

            //switch (pos2.Direction)
            //{
            //    case Direction.Horizontal:
            //        num2 = Enumerable.Range((int)pos2.X, (int)pos2.Length);
            //        val2 = EnumerableToString(num2, pos2.Direction, (int)pos2.X, (int)pos2.Y);
            //        break;
            //    case Direction.Vertical:
            //        num2 = Enumerable.Range((int)pos2.Y, (int)pos2.Length);
            //        val2 = EnumerableToString(num2, pos2.Direction, (int)pos2.X, (int)pos2.Y);
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException();
            //}
            //var result = SameValueBool(val1, val2) != true ? XandY(pos2) : SameValueBool(val1, val2);
        }

        //public static string EnumerableToString(IEnumerable<int> en, Direction dr, int x, int y)
        //{
        //    var str = new StringBuilder();

        //    switch (dr)
        //    {
        //        case Direction.Horizontal:
        //            foreach (var i in en)
        //            {
        //                str.Append("x" + i);
        //            }
        //            str.Append("y" + y);
        //            break;
        //        case Direction.Vertical:
        //            foreach (var i in en)
        //            {
        //                str.Append("y" + i);
        //            }
        //            str.Append("x" + x);
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(dr), dr, null);
        //    }

        //    return str.ToString();
        //}

        //public static string SameValue(string val1, string val2)
        //{
        //    const string reg = @"([x|y]\d)";
        //    var countX = 0;
        //    var countY = 0;

        //    var vl1 = Regex.Split(val1, reg).Where(s => s != string.Empty).ToArray();
        //    var vl2 = Regex.Split(val2, reg).Where(s => s != string.Empty).ToArray();

        //    var ss = vl1.Aggregate("", (current1, t) => vl2.Where(t1 => t == t1).Aggregate(current1, (current, t1) => current + t1));

        //    countX = ss.Count(x => x.Equals('x'));
        //    countY = ss.Count(x => x.Equals('y'));

        //    return (from t in vl1 from t1 in vl2 where t == t1 select t1).Aggregate("", (current, t1) => current + t1)+" cX: "+countX+" cY:"+countY;
        //}

        //private static bool SameValueBool(string val1, string val2)
        //{
        //    const string reg = @"([x|y]\d)";
        //    var countX = 0;
        //    var countY = 0;
        //    var vl1 = Regex.Split(val1, reg).Where(s => s != string.Empty).ToArray();
        //    var vl2 = Regex.Split(val2, reg).Where(s => s != string.Empty).ToArray();

        //    var ss = (from t in vl1 from t1 in vl2 where t == t1 select t1).Aggregate("", (current, t1) => current + t1);

        //    countX = ss.Count(x => x.Equals('x'));
        //    countY = ss.Count(x => x.Equals('y'));

        //    return countX >= 1 && countY >= 1;
        //}
    }
}
