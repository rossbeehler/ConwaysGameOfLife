using System.Linq;
using ConwaysGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLifeTest
{
    public static class IntegerArrayHelper
    {
        public static string ListContents(this int[] integerArray)
        {
            return "{" + string.Join(", ", integerArray.Select(x => x.ToString()).ToArray()) + "}";
        }

    }

    [TestClass()]
    public class GameBoardTest
    {
        private static void AssertEqualBoard(GameBoard gameBoard, int[][] expectedState)
        {
            Assert.AreEqual(expectedState.Length, gameBoard.CurrentBoard.Length);

            for (int boardRow = 0; boardRow < gameBoard.CurrentBoard.Length; boardRow++)
            {   
                CollectionAssert.AreEqual(expectedState[boardRow], gameBoard.CurrentBoard[boardRow], 
                    string.Format("Row {0} does not match:  Expected:  {1}  Actual:  {2} ", 
                                  boardRow, 
                                  expectedState[boardRow].ListContents(),
                                  gameBoard.CurrentBoard[boardRow].ListContents()));
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

        [TestMethod]
        public void TestThreeNeighborsComesAlive()
        {
            var g = new GameBoard(new int[][]
            {
                new [] { 0, 1, 0 },
                new [] { 0, 1, 0 },
                new [] { 0, 1, 0 },
            });

            g.Tick();

            AssertEqualBoard(g, new int[][]
            {
                new [] { 0, 0, 0 },
                new [] { 1, 1, 1 },
                new [] { 0, 0, 0 },
            });
        }

        [TestMethod]
        public void TestFourNeigborsKillsYou()
        {
            var g = new GameBoard(new int[][]
            {
                new [] { 0, 0, 0, 0 },
                new [] { 0, 1, 1, 0 },
                new [] { 0, 1, 1, 0 },
                new [] { 0, 1, 0, 0 },
            });

            g.Tick();

            AssertEqualBoard(g, new int[][]
            {
                new [] { 0, 0, 0, 0 },
                new [] { 0, 1, 1, 0 },
                new [] { 1, 0, 0, 0 },
                new [] { 0, 1, 1, 0 },
            });
        }

        [TestMethod]
        public void TestBoardGrowsLeft()
        {
            var g = new GameBoard(new int[][]
            {
                new [] { 1, 0, 0 },
                new [] { 1, 0, 0 },
                new [] { 1, 0, 0 },
            });

            g.Tick();

            AssertEqualBoard(g, new int[][]
            {
                new [] { 0, 0, 0, 0 },
                new [] { 1, 1, 0, 0 },
                new [] { 0, 0, 0, 0 },
            });
        }


    }
}
