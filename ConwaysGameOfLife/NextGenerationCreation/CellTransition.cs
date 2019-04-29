using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.NextGenerationCreation
{
    public class CellTransition
    {
        public bool IsCellLive(CellType[,] cellAndNeighbours)
        {
            var currentCell = cellAndNeighbours[1, 1];
            var numberOfLiveNeighbours = GetLiveNeighbourCount(cellAndNeighbours);

            return (currentCell == CellType.Live && numberOfLiveNeighbours == 2) ||
                   (currentCell == CellType.Live && numberOfLiveNeighbours == 3) ||
                   (currentCell == CellType.Dead && numberOfLiveNeighbours == 3);
        }

        private int GetLiveNeighbourCount(CellType[,] cellAndNeighbours)
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