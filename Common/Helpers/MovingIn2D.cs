using System;
using System.Collections.Generic;
using System.Drawing;
using Common.Enum;

namespace Common.Helpers
{
    public class MovingIn2D
    {
        #region Local Variables

        private readonly SortedSet<string> _visitedLocations = new SortedSet<string>();

        #endregion

        #region Properties

        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public Dictionary<Point, object> Map { get; set; }
        public ECardinals Face { get; set; }
        public string InvalidDestinationString { get; set; }
        public bool MoveAllowed { get; set; } = true;
        public bool ThrowOnInvalidMove { get; set; } = false;
        public int DistanceFrom(int x, int y) => Math.Abs(LocationX - x) + Math.Abs(LocationY - y);
        public string MapValue => Map.ContainsKey(new Point(LocationX, LocationY)) ? Map[new Point(LocationX, LocationY)].ToString() : MapDefaultValue;
        public string MapDefaultValue { get; set; } = "0";
        #endregion

        #region Events

        public delegate void LocationDelegate(MovingIn2D sender, int x, int y);
        public event LocationDelegate AlreadyVisited;

        #endregion

        #region Public Methods

        public void Turn(ETurnOrders order)
        {
            Face = (ECardinals) (((int) Face + (int) order) % 4);
            if (Face < 0) Face = 4 + Face;
        }
        public void Move(ECardinals direction, int steps, bool addToVisited, bool allowNewLocations, bool Peek = false)
        {
            var reps = 1;
            if (addToVisited)
            {
                reps = steps;
                steps = 1;
            }
            for (var i = 0; i < reps; i++)
            {
                switch (direction)
                {
                    case ECardinals.Up:
                        if (IsValidMapLocation(LocationX, LocationY + 1, allowNewLocations))
                        {
                            if (!Peek)
                                LocationY += steps;
                        }
                        else
                            if (ThrowOnInvalidMove) throw new InvalidOperationException();
                        break;
                    case ECardinals.Right:
                        if (IsValidMapLocation(LocationX + 1, LocationY, allowNewLocations))
                        {
                            if (!Peek)
                                LocationX += steps;
                        }
                        else
                            if (ThrowOnInvalidMove) throw new InvalidOperationException();
                        break;
                    case ECardinals.Down:
                        if (IsValidMapLocation(LocationX, LocationY - 1, allowNewLocations))
                        {
                            if (!Peek)
                                LocationY -= steps;
                        }
                        else
                            if (ThrowOnInvalidMove) throw new InvalidOperationException();
                        break;
                    case ECardinals.Left:
                        if (IsValidMapLocation(LocationX - 1, LocationY, allowNewLocations))
                        {
                            if (!Peek)
                                LocationX -= steps;
                        }
                        else
                            if (ThrowOnInvalidMove) throw new InvalidOperationException();
                        break;
                    default:
                        throw new NotSupportedException();
                }
                if (!Peek) AddToVisited();
            }
        }
        public void Peek()
        {
            Move(Face, 1, false, false, true);
        }
        public void MoveForward(int steps, bool addToVisited, bool allowNewLocations)
        {
            for (var i = 1; i <= steps; i++)
            {
                if (!MoveAllowed) break;
                Move(Face, 1, addToVisited, allowNewLocations);
            }
        }
        public void Write(object obj)
        {
            Map[new Point(LocationX, LocationY)] = obj;
        }

        #endregion

        #region Private Methods

                private bool IsValidMapLocation(int x, int y, bool bAllowNewLocations)
                {
                    if (Map == null) return true;
                    try
                    {
                        try
                        {
                            return Map[new Point(x, y)].ToString() != InvalidDestinationString;
                        }
                        catch (Exception)
                        {
                            return bAllowNewLocations;
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }

                private void AddToVisited()
                {
                    if (!_visitedLocations.Add(LocationX + "," + LocationY))
                        AlreadyVisited?.Invoke(this, LocationX, LocationY);
                }
            }

            #endregion
}