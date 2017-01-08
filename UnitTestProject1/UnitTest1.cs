using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var grid = new Grid(4);

            Assert.AreEqual(grid.CheckVector(Grid.Vectors.XYZ, 43, 64, Grid.Direction.Up), false);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.XYZ, 38, 59, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.XYZ, 59, 80, Grid.Direction.Up), false);

            Assert.AreEqual(grid.CheckVector(Grid.Vectors.minXZ, 10, 25, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.minXZ, 15, 30, Grid.Direction.Up), true);
            Assert.AreEqual(grid.CheckVector(Grid.Vectors.minXZ, 40, 55,Grid.Direction.Up), false);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var grid = new Grid(4);
            int position;
            List<int> winningPositions;
            grid.MakeMove(0, 0, 1, out position);
            grid.MakeMove(0, 1, 2, out position);
            grid.MakeMove(0, 0, 1, out position);
            grid.MakeMove(0, 1, 2, out position);
            grid.MakeMove(0, 0, 1, out position);
            grid.MakeMove(0, 1, 2, out position);
            grid.MakeMove(0, 0, 1, out position);

            Assert.AreEqual(grid.HasWinner(position, out winningPositions), true);

            Assert.AreEqual(grid.MakeMove(0,0,1,out position), false);

            //Assert.ThrowsException<Exception>(()=>grid.MakeMove(0, 0, 3),"Out of range");

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


    }
}
