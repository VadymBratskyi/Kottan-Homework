using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtleBoats
{
    public class Board
    {
        private List<Boats> boats;

        public Board()
        {
            boats = new List<Boats>();
        }

        public void Add(Boats boat)
        {
            switch (boat.Direction)
            {
                case Direction.Horizontal:
                    if (Enumerable.Range((int)boat.X, (int)boat.Length).Any(x => x < 1 || x > 10) || (boat.Y < 1 || boat.Y > 10))
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    break;
                case Direction.Vertical:
                    if (Enumerable.Range((int)boat.Y, (int)boat.Length).Any(y => y < 1 || y > 10) || (boat.X < 1 || boat.X > 10))
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            foreach (var b in boats)
            {
                if (b.Equals(boat))
                {
                    throw new BoatsOverlapException("Ship " + b + " overlaps with " + boat);
                }
            }

           

            boats.Add(boat);
        }

        public void Add(string bo)
        {
            Add(Boats.Parse(bo));
        }


        public List<Boats> GetAll()
        {
            return boats;
        }


        public void Validate()
        {
            var countPatrolBoat = 4 - boats.Count(p => p.GetType() == typeof (PatrolBoat)) ;
            var countCruiser = 3 - boats.Count(p => p.GetType() == typeof (Cruiser));
            var countSubmarine = 2 - boats.Count(p => p.GetType() == typeof (Submarine));
            var countAircraftCarrier = 1 - boats.Count(p => p.GetType() == typeof (AircraftCarrier));

            var value = new List<int>
            {
                countPatrolBoat, countCruiser, countSubmarine, countAircraftCarrier
            };

            if (value.Any(i => i != 0))
            {
                throw new BoardIsNotReadyException($@"There is not sufficient count of ships. We need: " +
                                                   $"PatrolBoat ({countPatrolBoat}), " + 
                                                   $"Cruiser ({countCruiser}), " +
                                                   $"Submarine ({countSubmarine}), " +
                                                   $"AircraftCarrier ({countAircraftCarrier})");
            }


        }
    }
}
