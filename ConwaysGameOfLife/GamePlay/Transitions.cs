namespace ConwaysGameOfLife
{
    public class Transitions
    {
        public bool IsCellLive(char[,] cellAndNeighbours)
        {
            var cellIsLive = false;

            var cell = cellAndNeighbours[1, 1];
            var numberOfLiveNeighbours = GetNumberOfLiveNeighbours(cellAndNeighbours);

            if ((cell == (char) CellType.Live && numberOfLiveNeighbours == 2) ||
                (cell == (char) CellType.Live && numberOfLiveNeighbours == 3) ||
                (cell == (char) CellType.Dead && numberOfLiveNeighbours == 3))
            {
                cellIsLive = true;
            }

            return cellIsLive;
        }

        private int GetNumberOfLiveNeighbours(char[,] cellAndNeighbours)
        {
            var liveNeighboursCount = 0;
            for (var i = 0; i < cellAndNeighbours.GetLength(0); i++)
            {
                for (var j = 0; j < cellAndNeighbours.GetLength(1); j++)
                {
                    if (i == 1 && j == 1)
                    {
                        continue;
                    }

                    if (cellAndNeighbours[i, j] == (char) CellType.Live)
                    {
                        liveNeighboursCount++;
                    }
                }
            }

            return liveNeighboursCount;
        }
    }
}