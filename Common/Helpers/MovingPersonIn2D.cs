using System;
using System.Collections.Generic;
using Common.Enum;

namespace Common.Helpers
{
    public class MovingPersonIn2D
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public ECardinals Face { get; set; }
        public bool MoveAllowed { get; set; } = true;
        public delegate void LocationDelegate(MovingPersonIn2D sender, int x, int y);
        public event LocationDelegate AlreadyVisited;
        private readonly SortedSet<string> _visitedLocations = new SortedSet<string>();
        public int DistanceFrom(int x, int y) => Math.Abs(LocationX - x) + Math.Abs(LocationY - y);

        public void Turn(ETurnOrders order)
        {
            Face = (ECardinals)(((int)Face + (int)order) % 4);
            if (Face < 0) Face = 4 + Face;
        }

        public void Move(int steps)
        {
            for (var i = 1; i <= steps; i++)
            {
                if (!MoveAllowed) break;
                switch (Face)
                {
                    case ECardinals.North:
                        LocationY++;
                        break;
                    case ECardinals.East:
                        LocationX++;
                        break;
                    case ECardinals.South:
                        LocationY--;
                        break;
                    case ECardinals.West:
                        LocationX--;
                        break;
                    default:
                        throw new NotSupportedException();
                }
                AddToVisited();
            }
        }

        private void AddToVisited()
        {
            if (!_visitedLocations.Add(LocationX + "," + LocationY))
                AlreadyVisited?.Invoke(this, LocationX, LocationY);
        }
    }
}