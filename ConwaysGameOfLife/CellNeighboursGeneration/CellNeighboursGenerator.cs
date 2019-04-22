using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.PlayGameOfLife;

namespace ConwaysGameOfLife.CellNeighboursGeneration
{
    public class CellNeighboursGenerator
    {
        private readonly CellNeighboursCoordinatesGenerator _cellNeighboursCoordinatesGenerator;
        private const int CellNeighboursArraySize = 3;

        public CellNeighboursGenerator()
        {
            _cellNeighboursCoordinatesGenerator = new CellNeighboursCoordinatesGenerator();
        }

        public CellType[,] GenerateCellNeighbours(GameGrid gameGrid, Coordinate cellCoordinates)
        {
            // abstraction of data types with game grid dimensions TODO
            var (maxXCoordinate, maxYCoordinate) = gameGrid.GetMaxGridSizeCoordinates();
            var maxGridSizeCoordinates = new Coordinate()
                {X = maxXCoordinate, Y = maxYCoordinate};
            var neighboursCoordinates = GetCellNeighboursCoordinates(cellCoordinates, maxGridSizeCoordinates);

            var neighbours = new CellType[CellNeighboursArraySize, CellNeighboursArraySize];
            var rowCount = 0;
            var columnCount = 0;
            foreach (var neighbourCoordinate in neighboursCoordinates)
            {
                neighbours[rowCount, columnCount] =
                    gameGrid.CurrentGameGrid[neighbourCoordinate.X, neighbourCoordinate.Y];
                columnCount++;

                if (columnCount != 3) continue;
                columnCount = 0;
                rowCount++;
            }

            return neighbours;
        }

        private Coordinate[] GetCellNeighboursCoordinates(Coordinate cellCoordinates,
            Coordinate maxGridSizeCoordinates)
        {
            Coordinate[] neighboursCoordinates;

            if (cellCoordinates.X == 0 || cellCoordinates.Y == 0 ||
                cellCoordinates.X == maxGridSizeCoordinates.X ||
                cellCoordinates.Y == maxGridSizeCoordinates.Y)
            {
                neighboursCoordinates = IsCornerCoordinate(cellCoordinates, maxGridSizeCoordinates)
                    ? _cellNeighboursCoordinatesGenerator.GenerateCornerOverlapCoordinates(cellCoordinates,
                        maxGridSizeCoordinates)
                    : _cellNeighboursCoordinatesGenerator.GenerateBordersOverlapCoordinates(cellCoordinates,
                        maxGridSizeCoordinates);
            }
            else
            {
                neighboursCoordinates =
                    _cellNeighboursCoordinatesGenerator.GenerateNoOverlapCoordinates(cellCoordinates);
            }

            return neighboursCoordinates;
        }

        private bool IsCornerCoordinate(Coordinate cellCoordinates,
            Coordinate maxGridCoordinates)
        {
            return (cellCoordinates.X == 0 && cellCoordinates.Y == 0) ||
                   (cellCoordinates.X == maxGridCoordinates.X && cellCoordinates.Y == maxGridCoordinates.Y) ||
                   (cellCoordinates.X == 0 && cellCoordinates.Y == maxGridCoordinates.Y) ||
                   (cellCoordinates.X == maxGridCoordinates.X && cellCoordinates.Y == 0);
        }
    }
}