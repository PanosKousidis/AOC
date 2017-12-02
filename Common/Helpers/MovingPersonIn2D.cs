using System;
using System.Collections.Generic;
using Common.Enum;

namespace Common.Helpers
{
    public class MovingPersonIn2D
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public string[,] Map { get; set; }

        public string MapValue => Map[LocationX,LocationY];
        public ECardinals Face { get; set; }
        public string InvalidDestinationString { get; set; }
        public bool MoveAllowed { get; set; } = true;

        public delegate void LocationDelegate(MovingPersonIn2D sender, int x, int y);

        public event LocationDelegate AlreadyVisited;
        private readonly SortedSet<string> _visitedLocations = new SortedSet<string>();
        public int DistanceFrom(int x, int y) => Math.Abs(LocationX - x) + Math.Abs(LocationY - y);

        public void Turn(ETurnOrders order)
        {
            Face = (ECardinals) (((int) Face + (int) order) % 4);
            if (Face < 0) Face = 4 + Face;
        }

        public void Move(ECardinals direction)
        {
            switch (direction)
            {
                case ECardinals.North:
                    if (IsValidMapLocation(LocationX, LocationY + 1))
                        LocationY++;
                    break;
                case ECardinals.East:
                    if (IsValidMapLocation(LocationX + 1, LocationY))
                        LocationX++;
                    break;
                case ECardinals.South:
                    if (IsValidMapLocation(LocationX, LocationY - 1))
                        LocationY--;
                    break;
                case ECardinals.West:
                    if (IsValidMapLocation(LocationX - 1, LocationY))
                        LocationX--;
                    break;
                default:
                    throw new NotSupportedException();
            }
        }

        private bool IsValidMapLocation(int x, int y)
        {
            if (Map == null) return true;
            try
            {
                return Map[x,y] != InvalidDestinationString;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void MoveForward(int steps)
        {
            for (var i = 1; i <= steps; i++)
            {
                if (!MoveAllowed) break;
                Move(Face);
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