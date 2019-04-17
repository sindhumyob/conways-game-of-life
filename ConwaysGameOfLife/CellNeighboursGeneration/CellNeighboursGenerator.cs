using ConwaysGameOfLife.GameHelpers;

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

        public char[,] GenerateCellNeighbours(char[,] gameGrid, Coordinate currentCellCoordinates)
        {
            // abstraction of data types with game grid dimensions
            var neighboursCoordinates = GetCellNeighboursCoordinates(currentCellCoordinates.XCoordinate,
                currentCellCoordinates.YCoordinate, gameGrid.GetLength(0) - 1,
                gameGrid.GetLength(1) - 1);

            var neighbours = new char[CellNeighboursArraySize, CellNeighboursArraySize];
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

        private Coordinate[] GetCellNeighboursCoordinates(int rowCoord, int colCoord, int maxRowCoord,
            int maxColumnCoord)
        {
            Coordinate[] neighboursCoordinates;

            if (rowCoord == 0 || colCoord == 0 || rowCoord == maxRowCoord || colCoord == maxColumnCoord)
            {
                neighboursCoordinates = IsCornerCoordinate(rowCoord, colCoord, maxRowCoord, maxColumnCoord)
                    ? _cellNeighboursCoordinatesGenerator.GenerateCornerOverlapCoordinates(rowCoord, colCoord,
                        maxRowCoord, maxColumnCoord)
                    : _cellNeighboursCoordinatesGenerator.GenerateBordersOverlapCoordinates(rowCoord, colCoord,
                        maxRowCoord, maxColumnCoord);
            }
            else
            {
                neighboursCoordinates =
                    _cellNeighboursCoordinatesGenerator.GenerateNoOverlapCoordinates(rowCoord, colCoord);
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