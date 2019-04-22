using ConwaysGameOfLife.CellNeighboursGeneration.CellNeighboursCoordinates;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.PlayGameOfLife;

namespace ConwaysGameOfLife.CellNeighboursGeneration
{
    public class CellNeighboursGenerator
    {
        private readonly CellNeighboursCoordinatesGenerator _cellNeighboursCoordinatesGenerator;
        private readonly NoOverlapCoordinates _noOverlapCoordinates;
        private const int CellNeighboursArraySize = 3;

        public CellNeighboursGenerator()
        {
            _cellNeighboursCoordinatesGenerator = new CellNeighboursCoordinatesGenerator();

            _noOverlapCoordinates = new NoOverlapCoordinates();
        }

        public CellType[,] GetCellNeighbours(GameGrid gameGrid, Coordinate cellCoordinates)
        {
            var (maxXCoordinate, maxYCoordinate) = gameGrid.GetMaxGridSizeCoordinates();
            var maxGridSizeCoordinates = new Coordinate {X = maxXCoordinate, Y = maxYCoordinate};
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
                    ? _cellNeighboursCoordinatesGenerator.GetCornerOverlapCoordinates(cellCoordinates,
                        maxGridSizeCoordinates)
                    : _cellNeighboursCoordinatesGenerator.GetBordersOverlapCoordinates(cellCoordinates,
                        maxGridSizeCoordinates);
            }
            else
            {
                neighboursCoordinates =
                    _noOverlapCoordinates.GetNoOverlapCoordinates(cellCoordinates);
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