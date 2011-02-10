namespace ConwaysGameOfLife
{
    public class GameBoard
    {
        public int[][] CurrentBoard { get; private set; }

        public GameBoard(int[][] initialBoard)
        {
            CurrentBoard = initialBoard;
        }

        public void Tick()
        {
            var nextBoard = new int[CurrentBoard.Length][];

            for (int row = 0; row < CurrentBoard.Length; row++)
            {
                SetAliveOrDead(nextBoard, row);
            }

            CurrentBoard = nextBoard;
        }

        private void SetAliveOrDead(int[][] nextBoard, int row)
        {
            nextBoard[row] = new int[CurrentBoard[row].Length];
            for (int column = 0; column < CurrentBoard[row].Length; column++)
            {
                SetAliveOrDead(nextBoard, row, column);
            }
        }

        private void SetAliveOrDead(int[][] nextBoard, int row, int column)
        {
            if (AliveNeighbors(row, column) == 3)
                nextBoard[row][column] = 1;
            else if (AliveNeighbors(row, column) == 2)
                nextBoard[row][column] = CurrentBoard[row][column];
            else
                nextBoard[row][column] = 0;
        }

        private int AliveNeighbors(int row, int column)
        {
            return AliveAt(row - 1, column - 1) + AliveAt(row - 1, column + 0) + AliveAt(row - 1, column + 1) +
                   AliveAt(row + 0, column - 1) +                                AliveAt(row + 0, column + 1) +
                   AliveAt(row + 1, column - 1) + AliveAt(row + 1, column + 0) + AliveAt(row + 1, column + 1);
        }

        private int AliveAt(int row, int column)
        {
            if (IsOutsideBounds(row, column))
                return 0;

            return CurrentBoard[row][column];
        }

        private bool IsOutsideBounds(int row, int column)
        {
            return column < 0 || column >= CurrentBoard[0].Length ||
                   row < 0 || row >= CurrentBoard.Length;
        }
    }
}
