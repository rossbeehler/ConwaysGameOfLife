using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConwaysGame_StartAtBoard
{
    public class GameBoard
    {
        private int[][] currentState;

        public GameBoard(int[][] initialState)
        {
            this.currentState = initialState;
        }

        public void Tick()
        {
            for (int row = 0; row < currentState.Length; row++)
            {
                for (int column = 0; column < currentState[row].Length; column++)
                {
                    if (currentState[row][column] == 1)
                    {
                        if (AliveNeighbors(row, column) < 2)
                        {
                            currentState[row][column] = 0;
                        }
                    }
                }
            }
        }

        public int[][] CurrentState
        {
            get
            {
                return this.currentState;
            }
        }

        private int AliveNeighbors(int row, int column)
        {
            return Left(row, column) +
                   Up(row, column) +
                   UpperLeft(row, column) +
                   UpperRight(row, column) +
                   Right(row, column) +
                   Down(row, column) +
                   LowerRight(row, column) +
                   LowerLeft(row, column);
        }

        private int LowerLeft(int row, int column)
        {
            if (IsOutsideBounds(column - 1, row + 1))
                return 0;
            return currentState[row + 1][column - 1];
        }

        private int LowerRight(int row, int column)
        {
            if (IsOutsideBounds(column + 1, row + 1))
                return 0;
            return currentState[row + 1][column + 1];
        }

        private int Down(int row, int column)
        {
            if (IsOutsideBounds(column, row + 1))
                return 0;
            return currentState[row + 1][column + 0];
        }

        private int Right(int row, int column)
        {
            if (IsOutsideBounds(column + 1, row))
                return 0;
            return currentState[row + 0][column + 1];
        }

        private int UpperRight(int row, int column)
        {
            if (IsOutsideBounds(column + 1, row - 1))
                return 0;
            return currentState[row - 1][column + 1];
        }

        private int UpperLeft(int row, int column)
        {
            if (IsOutsideBounds(column - 1, row - 1))
                return 0;
            return currentState[row - 1][column - 1];
        }

        private int Up(int row, int column)
        {
            if (IsOutsideBounds(column, row - 1))
                return 0;
            return currentState[row - 1][column - 0];
        }

        private int Left(int row, int column)
        {
            if (IsOutsideBounds(column - 1, row))
                return 0;
            return currentState[row - 0][column - 1];
        }
        
        private bool IsOutsideBounds(int column, int row)
        {
            if (column < 0 || column >= currentState[0].Length ||
                row < 0 || row >= currentState.Length)
            {
                return true;
            }

            return false;
        }
    }
}
