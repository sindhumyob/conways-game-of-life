using ConwaysGameOfLife.CellNeighboursGeneration.CellNeighboursCoordinates;
using ConwaysGameOfLife.GamePlayHelpers;

namespace ConwaysGameOfLife.CellNeighboursGeneration
{
    public class CellNeighboursGenerator
    {
        private readonly CellNeighboursCoordinatesGenerator _cellNeighboursCoordinatesGenerator;

        public CellNeighboursGenerator()
        {
            _cellNeighboursCoordinatesGenerator = new CellNeighboursCoordinatesGenerator();
        }

        public char[,] GenerateCellNeighbours(char[,] gameGrid, Coordinate currentCellCoordinates)
        {
            var neighboursCoordinates = GetNeighboursCoordinates(currentCellCoordinates.XCoordinate,
                currentCellCoordinates.YCoordinate, gameGrid.GetLength(0) - 1,
                gameGrid.GetLength(1) - 1);

            var neighbours = new char[3, 3];
            var rowCount = 0;
            var columnCount = 0;
            foreach (var neighbourCoordinate in neighboursCoordinates)
            {
                neighbours[rowCount, columnCount] =
                    gameGrid[neighbourCoordinate.XCoordinate, neighbourCoordinate.YCoordinate];
                columnCount++;

                if (columnCount != 3) continue;
                columnCount = 0;
                rowCount++;
            }

            return neighbours;
        }

        private Coordinate[] GetNeighboursCoordinates(int rowCoord, int colCoord, int maxRowCoord, int maxColumnCoord)
        {
            Coordinate[] neighboursCoordinates;

            if (rowCoord == 0 || colCoord == 0 || rowCoord == maxRowCoord || colCoord == maxColumnCoord)
            {
                neighboursCoordinates = IsCornerCoordinate(rowCoord, colCoord, maxRowCoord, maxColumnCoord)
                    ? _cellNeighboursCoordinatesGenerator.GetCornerOverlapCoordinates(rowCoord, colCoord, maxRowCoord,
                        maxColumnCoord)
                    : _cellNeighboursCoordinatesGenerator.GetBordersOverlapCoordinates(rowCoord, colCoord, maxRowCoord,
                        maxColumnCoord);
            }
            else
            {
                neighboursCoordinates = _cellNeighboursCoordinatesGenerator.GetNoOverlapCoordinates(rowCoord, colCoord);
            }

            return neighboursCoordinates;
        }

        private bool IsCornerCoordinate(int rowCoord, int colCoord, int maxRowCoord, int maxColumnCoord)
        {
            return (rowCoord == 0 && colCoord == 0) || (rowCoord == maxRowCoord && colCoord == maxColumnCoord)
                                                    || (rowCoord == 0 && colCoord == maxColumnCoord) ||
                                                    (rowCoord == maxRowCoord && colCoord == 0);
        }
    }
}