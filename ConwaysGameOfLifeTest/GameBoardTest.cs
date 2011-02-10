using ConwaysGame_StartAtBoard;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace TestProject1
{
    [TestClass()]
    public class GameBoardTest
    {
        private static void AssertEqualBoard(GameBoard gameBoard, int[][] expectedState)
        {
            Assert.AreEqual(expectedState.Length, gameBoard.CurrentState.Length);

            for (int boardRow = 0; boardRow < gameBoard.CurrentState.Length; boardRow++)
            {
                CollectionAssert.AreEqual(expectedState[boardRow], gameBoard.CurrentState[boardRow]);
            }
        }

        [TestMethod]
        public void TestEmptyBoard()
        {
            var g = new GameBoard(new int[][] 
            {
                new[] { 0, 0, 0 },
                new[] { 0, 0, 0 },
                new[] { 0, 0, 0 },
            });

            g.Tick();

            AssertEqualBoard(g, new int[][] 
            {
                new[] { 0, 0, 0 },
                new[] { 0, 0, 0 },
                new[] { 0, 0, 0 },
            });
        }

        [TestMethod]
        public void TestOneAliveDies()
        {
            var g = new GameBoard(new int[][]
            {
                new [] { 0, 0, 0 },
                new [] { 0, 1, 0 },
                new [] { 0, 0, 0 },
            });

            g.Tick();

            AssertEqualBoard(g, new int[][]
            {
                new [] { 0, 0, 0 },
                new [] { 0, 0, 0 },
                new [] { 0, 0, 0 },
            });
        }

        [TestMethod]
        public void TestBlock()
        {
            var g = new GameBoard(new int[][]
            {
                new [] { 0, 0, 0, 0 },
                new [] { 0, 1, 1, 0 },
                new [] { 0, 1, 1, 0 },
                new [] { 0, 0, 0, 0 },
            });

            g.Tick();

            AssertEqualBoard(g, new int[][]
            {
                new [] { 0, 0, 0, 0 },
                new [] { 0, 1, 1, 0 },
                new [] { 0, 1, 1, 0 },
                new [] { 0, 0, 0, 0 },
            });            
        }

        [TestMethod]
        public void TestLeftEdgeReturnsEmpty()
        {
            var g = new GameBoard(new int[][]
            {
                new [] { 0, 0, 0 },
                new [] { 1, 0, 0 },
                new [] { 0, 0, 0 },
            });

            g.Tick();

            AssertEqualBoard(g, new int[][]
            {
                new [] { 0, 0, 0 },
                new [] { 0, 0, 0 },
                new [] { 0, 0, 0 },
            });
        }

        [TestMethod]
        public void TestRightEdgeReturnsEmpty()
        {
            var g = new GameBoard(new int[][]
            {
                new [] { 0, 0, 0 },
                new [] { 0, 0, 1 },
                new [] { 0, 0, 0 },
            });

            g.Tick();

            AssertEqualBoard(g, new int[][]
            {
                new [] { 0, 0, 0 },
                new [] { 0, 0, 0 },
                new [] { 0, 0, 0 },
            });
        }

        [TestMethod]
        public void TestUpperEdgeReturnsEmpty()
        {
            var g = new GameBoard(new int[][]
            {
                new [] { 0, 1, 0 },
                new [] { 0, 0, 0 },
                new [] { 0, 0, 0 },
            });

            g.Tick();

            AssertEqualBoard(g, new int[][]
            {
                new [] { 0, 0, 0 },
                new [] { 0, 0, 0 },
                new [] { 0, 0, 0 },
            });
        }

        [TestMethod]
        public void TestLowerEdgeReturnsEmpty()
        {
            var g = new GameBoard(new int[][]
            {
                new [] { 0, 0, 0 },
                new [] { 0, 0, 0 },
                new [] { 0, 1, 0 },
            });

            g.Tick();

            AssertEqualBoard(g, new int[][]
            {
                new [] { 0, 0, 0 },
                new [] { 0, 0, 0 },
                new [] { 0, 0, 0 },
            });
        }

        [TestMethod]
        public void TestFourCornersReturnEmpty()
        {
            var g = new GameBoard(new int[][]
            {
                new [] { 1, 0, 1 },
                new [] { 0, 0, 0 },
                new [] { 1, 0, 1 },
            });

            g.Tick();

            AssertEqualBoard(g, new int[][]
            {
                new [] { 0, 0, 0 },
                new [] { 0, 0, 0 },
                new [] { 0, 0, 0 },
            });
        }

        [TestMethod]
        public void TestOneNeighborDies()
        {
            var g = new GameBoard(new int[][]
            {
                new [] { 0, 0, 0,},
                new [] { 0, 0, 1,},
                new [] { 0, 0, 1,},
            });

            g.Tick();

            AssertEqualBoard(g, new int[][]
            {
                new [] { 0, 0, 0,},
                new [] { 0, 0, 0,},
                new [] { 0, 0, 0,},
            });
        }        
    }
}
