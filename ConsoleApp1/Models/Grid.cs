using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Grid
    {
        public int VectorX = 1;
        public int VectorY = 0;
        public int VectorZ = 0;

        private Dictionary<Vectors, int> VectorValues { get; set; }

        public List<int> Values { get; set; }

        public Grid(int lineWidth)
        {
            VectorY = lineWidth;
            VectorZ = Convert.ToInt32(Math.Pow(lineWidth, 2));

            VectorValues = new Dictionary<Vectors, int>
            {
                {Vectors.X, VectorX},
                {Vectors.Y, VectorY},
                {Vectors.Z, VectorZ},
                {Vectors.XY, VectorX + VectorY},
                {Vectors.minXY, -VectorX + VectorY},
                {Vectors.YZ, VectorY + VectorZ},
                {Vectors.minYZ, -VectorY + VectorZ},
                {Vectors.XZ, VectorX + VectorZ},
                {Vectors.minXZ, -VectorX + VectorZ},
                {Vectors.XYZ, VectorX + VectorY + VectorZ},
                {Vectors.minXYZ, -VectorX + VectorY + VectorZ},
                {Vectors.XminYZ, VectorX + -VectorY + VectorZ},
                {Vectors.minXminYZ, -VectorX + -VectorY + VectorZ}
            };

            Values = new List<int>();
            for (var i = 0; i < Math.Pow(lineWidth, 3); i++)
            {
                Values.Add(0);
            }
        }

        public string Draw(List<int> winningPositions = null)
        {
            if (winningPositions == null)
            {
                winningPositions = new List<int>();
            }
            var layers = new List<string>();
            var i = 0;
            for (var z = 0; z < VectorY; z++)
            {
                var result = new StringBuilder();
                result.Append("|");
                for (var x = 0; x < VectorY; x++)
                {
                    result.Append("---|");
                }
                result.AppendLine();

                for (var y = 0; y < VectorY; y++)
                {
                    result.Append("|");
                    for (var x = 0; x < VectorY; x++)
                    {
                        result.Append(winningPositions.Any(c => c == i) ? $"({Values[i]})|" : $" {Values[i]} |");
                        i++;
                    }
                    result.AppendLine();

                    result.Append("|");
                    for (var x = 0; x < VectorY; x++)
                    {
                        result.Append("---|");
                    }
                    result.AppendLine();
                }
                result.AppendLine();
                layers.Add(result.ToString());
            }
            layers.Reverse();
            return string.Join("", layers);
        }

        public bool MakeMove(int x, int y, int player, out int position)
        {
            position = 0;
            if (x < 0 || x >= VectorY || y < 0 || y >= VectorY)
            {
                return false;
            }
            position = x * VectorX + y * VectorY;
            var positionHasValue = true;
            while (positionHasValue)
            {
                positionHasValue = PositionHasValue(position);
                if (!positionHasValue) continue;
                position += VectorZ;
                if (position >= Math.Pow(VectorY, 3))
                {
                    return false;
                }
            }
            Values[position] = player;
            return true;
        }

        public bool HasWinner(int position, out List<int> winningPositions)
        {
            winningPositions = new List<int>();
            winningPositions.Add(position);

            var currentPlayer = Values[position];
            var direction = Direction.Up;
            const int maxSteps = 4;
            foreach (var vv in VectorValues)
            {
                var winStreak = 1;
                var newPosition = position;
                var previousPosition = position;

                for (var i = 0; i < maxSteps; i++)
                {
                    if (direction == Direction.Up)
                    {
                        newPosition += vv.Value;
                    }
                    else
                    {
                        newPosition -= vv.Value;
                    }
                    if (!CheckVector(vv.Key, previousPosition, newPosition, direction))
                    {
                        if (direction == Direction.Up)
                        {
                            direction = Direction.Down;
                            newPosition = position;
                            previousPosition = position;
                            continue;
                        }
                        break;
                    }
                    if (Values[newPosition] == currentPlayer)
                    {
                        winStreak++;
                        winningPositions.Add(newPosition);
                    }
                    else
                    {
                        break;
                    }
                    previousPosition = newPosition;
                }
                if (winStreak == VectorY)
                {
                    return true;
                }
            }
            return false;
        }

        public bool PositionHasValue(int position)
        {
            return Values[position] != 0;
        }

        public Coordinate GetCoordinate(int position)
        {
            var result = new Coordinate(0, 0, 0);
            if (position == 0)
            {
                return result;
            }

            result.Z = Convert.ToInt32(Math.Floor(Convert.ToDecimal(position / VectorZ)));
            result.X = (position - result.Z * VectorZ) % VectorY;
            result.Y = Convert.ToInt32(Math.Floor(Convert.ToDecimal((position - (result.Z * VectorZ)) / VectorY)));

            return result;
        }

        public bool CheckVector(Vectors vector, int current, int neighbor, Direction direction)
        {
            if (neighbor < 0 || neighbor >= Math.Pow(VectorY, 3))
            {
                return false;
            }
            var currentCoord = GetCoordinate(current);
            var neighborCoord = GetCoordinate(neighbor);
            switch (vector)
            {
                case Vectors.X:
                case Vectors.XY:
                case Vectors.XZ:
                case Vectors.XYZ:
                case Vectors.XminYZ:
                    if (neighborCoord.X - currentCoord.X != (direction == Direction.Up ? 1 : -1))
                    {
                        return false;
                    }
                    break;
            }
            switch (vector)
            {
                case Vectors.minXminYZ:
                case Vectors.minXY:
                case Vectors.minXYZ:
                case Vectors.minXZ:
                    if (neighborCoord.X - currentCoord.X != (direction == Direction.Up ? -1 : 1))
                    {
                        return false;
                    }
                    break;
            }
            switch (vector)
            {
                case Vectors.Y:
                case Vectors.XY:
                case Vectors.XYZ:
                case Vectors.YZ:
                case Vectors.minXY:
                case Vectors.minXYZ:
                    if (neighborCoord.Y - currentCoord.Y != (direction == Direction.Up ? 1 : -1))
                    {
                        return false;
                    }
                    break;
            }
            switch (vector)
            {
                case Vectors.minXminYZ:
                case Vectors.XminYZ:
                case Vectors.minYZ:
                    if (neighborCoord.Y - currentCoord.Y != (direction == Direction.Up ? -1 : 1))
                    {
                        return false;
                    }
                    break;
            }
            switch (vector)
            {
                case Vectors.Z:
                case Vectors.minYZ:
                case Vectors.YZ:
                case Vectors.minXZ:
                case Vectors.XZ:
                case Vectors.XYZ:
                case Vectors.minXYZ:
                case Vectors.XminYZ:
                case Vectors.minXminYZ:
                    if (neighborCoord.Z - currentCoord.Z != (direction == Direction.Up ? 1 : -1))
                    {
                        return false;
                    }
                    break;
            }

            return true;
        }

        [Flags]
        public enum Vectors
        {
            X,
            Y,
            Z,
            XY,
            minXY,
            YZ,
            minYZ,
            XZ,
            minXZ,
            XYZ,
            minXYZ,
            XminYZ,
            minXminYZ
        }

        public enum Direction
        {
            Up,
            Down
        }

        public class Coordinate
        {
            public Coordinate(int x, int y, int z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public int Z { get; set; }
        }
    }
}
