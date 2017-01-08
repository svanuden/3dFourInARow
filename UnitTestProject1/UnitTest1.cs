using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Grid4CheckVector()
        {
            var grid = new Grid(4, 4);

            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 22, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.Y, 21, 25, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.Z, 21, 37, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.XY, 21, 26, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.XZ, 21, 38, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.YZ, 21, 41, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.minXY, 21, 24, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.minYZ, 21, 33, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.minXZ, 21, 36, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.XYZ, 21, 42, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.minXYZ, 21, 40, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.XminYZ, 21, 34, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.minXminYZ, 21, 32, Grid.Direction.Up), true);

            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 20, Grid.Direction.Down), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.Y, 21, 17, Grid.Direction.Down), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.Z, 21, 5, Grid.Direction.Down), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.XY, 21, 16, Grid.Direction.Down), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.XZ, 21, 4, Grid.Direction.Down), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.YZ, 21, 1, Grid.Direction.Down), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.minXY, 21, 18, Grid.Direction.Down), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.minYZ, 21, 9, Grid.Direction.Down), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.minXZ, 21, 6, Grid.Direction.Down), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.XYZ, 21, 0, Grid.Direction.Down), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.minXYZ, 21, 2, Grid.Direction.Down), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.XminYZ, 21, 8, Grid.Direction.Down), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.minXminYZ, 21, 10, Grid.Direction.Down), true);

            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 0, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 1, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 2, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 4, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 5, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 6, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 8, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 9, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 10, Grid.Direction.Up), false);

            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 16, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 17, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 18, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 20, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 22, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 24, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 25, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 26, Grid.Direction.Up), false);

            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 32, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 33, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 34, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 36, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 37, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 38, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 40, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 41, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.X, 21, 42, Grid.Direction.Up), false);

        }

        [TestMethod]
        public void WinnersTestX()
        {
            var grid = new Grid(4, 4);
            int position;
            List<int> winningPositions;
            Assert.AreEqual(grid.MakeMove(0, 0, 1, out position), true);
            Assert.AreEqual(grid.MakeMove(0, 1, 2, out position), true);
            Assert.AreEqual(grid.MakeMove(0, 0, 1, out position), true);
            Assert.AreEqual(grid.MakeMove(0, 1, 2, out position), true);
            Assert.AreEqual(grid.MakeMove(0, 0, 1, out position), true);
            Assert.AreEqual(grid.MakeMove(0, 1, 2, out position), true);
            Assert.AreEqual(grid.MakeMove(0, 0, 1, out position), true);

            Assert.AreEqual(grid.HasWinner(position, out winningPositions), true);

            Assert.AreEqual(grid.MakeMove(0, 0, 1, out position), false);

            Assert.AreEqual(grid.PositionHasValue(0), true);
            Assert.AreEqual(grid.PositionHasValue(16), true);
            Assert.AreEqual(grid.PositionHasValue(32), true);
            Assert.AreEqual(grid.PositionHasValue(48), true);

            Assert.AreEqual(grid.PositionHasValue(4), true);
            Assert.AreEqual(grid.PositionHasValue(20), true);
            Assert.AreEqual(grid.PositionHasValue(36), true);
            Assert.AreEqual(grid.PositionHasValue(52), false);

            Assert.AreEqual(grid.HasWinner(48, out winningPositions), true);
            Assert.AreEqual(grid.HasWinner(33, out winningPositions), false);
        }

        [TestMethod]
        public void WinnersTestXyz()
        {
            var grid = new Grid(4, 4);
            int position;
            List<int> winningPositions;
            Assert.AreEqual(grid.MakeMove(0, 0, 1, out position), true);
            Assert.AreEqual(grid.MakeMove(1, 1, 2, out position), true);
            Assert.AreEqual(grid.MakeMove(1, 1, 1, out position), true);
            Assert.AreEqual(grid.MakeMove(2, 2, 2, out position), true);
            Assert.AreEqual(grid.MakeMove(2, 2, 1, out position), true);
            Assert.AreEqual(grid.MakeMove(3, 3, 2, out position), true);
            Assert.AreEqual(grid.MakeMove(2, 2, 1, out position), true);
            Assert.AreEqual(grid.MakeMove(3, 3, 2, out position), true);
            Assert.AreEqual(grid.MakeMove(3, 3, 1, out position), true);
            Assert.AreEqual(grid.MakeMove(2, 2, 2, out position), true);
            Assert.AreEqual(grid.MakeMove(3, 3, 1, out position), true);

            Assert.AreEqual(grid.HasWinner(position, out winningPositions), true);

            Assert.AreEqual(grid.PositionHasValue(0), true);
            Assert.AreEqual(grid.PositionHasValue(5), true);
            Assert.AreEqual(grid.PositionHasValue(10), true);
            Assert.AreEqual(grid.PositionHasValue(15), true);

            Assert.AreEqual(grid.PositionHasValue(21), true);
            Assert.AreEqual(grid.PositionHasValue(26), true);
            Assert.AreEqual(grid.PositionHasValue(31), true);

            Assert.AreEqual(grid.PositionHasValue(42), true);
            Assert.AreEqual(grid.PositionHasValue(47), true);

            Assert.AreEqual(grid.PositionHasValue(63), true);

            Assert.AreEqual(grid.PositionHasValue(48), false);
            Assert.AreEqual(grid.PositionHasValue(53), false);
        }


    }
}
