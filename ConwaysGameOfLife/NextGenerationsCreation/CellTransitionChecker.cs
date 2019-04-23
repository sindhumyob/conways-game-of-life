using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.NextGenerationsCreation
{
    public class CellTransitionChecker
    {
        public bool IsCellLive(CellType[,] cellNeighbours)
        {
            var cellIsLive = false;

            var currentCell = cellNeighbours[1, 1];
            var numberOfLiveNeighbours = GetNumberOfLiveNeighbours(cellNeighbours);

            if ((currentCell == CellType.Live && numberOfLiveNeighbours == 2) ||
                (currentCell == CellType.Live && numberOfLiveNeighbours == 3) ||
                (currentCell == CellType.Dead && numberOfLiveNeighbours == 3))
            {
                cellIsLive = true;
            }

            return cellIsLive;
        }

        private int GetNumberOfLiveNeighbours(CellType[,] cellNeighbours)
        {
            var liveNeighboursCount = 0;
            for (var i = 0; i < cellNeighbours.GetLength(0); i++)
            {
                for (var j = 0; j < cellNeighbours.GetLength(1); j++)
                {
                    if (i == 1 && j == 1)
                    {
                        continue;
                    }

                    if (cellNeighbours[i, j] == CellType.Live)
                    {
                        liveNeighboursCount++;
                    }
                }
            }

            return liveNeighboursCount;
        }
    }
}