using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.NextGenerationsCreation
{
    public class CellTransitionChecker
    {
        public bool IsCellLive(CellType[,] cellAndNeighbours)
        {
            var cellIsLive = false;

            var currentCell = cellAndNeighbours[1, 1];
            var numberOfLiveNeighbours = GetNumberOfLiveNeighbours(cellAndNeighbours);

            if ((currentCell == CellType.Live && numberOfLiveNeighbours == 2) ||
                (currentCell == CellType.Live && numberOfLiveNeighbours == 3) ||
                (currentCell == CellType.Dead && numberOfLiveNeighbours == 3))
            {
                cellIsLive = true;
            }

            return cellIsLive;
        }

        private int GetNumberOfLiveNeighbours(CellType[,] cellAndNeighbours)
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

                    if (cellAndNeighbours[i, j] == CellType.Live)
                    {
                        liveNeighboursCount++;
                    }
                }
            }

            return liveNeighboursCount;
        }
    }
}