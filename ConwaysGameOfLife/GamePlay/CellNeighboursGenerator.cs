using System.ComponentModel.DataAnnotations;

namespace ConwaysGameOfLife
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
            int[,] neighboursCoordinates;

            var rowCoord = currentCellCoordinates.XCoordinate;
            var colCoord = currentCellCoordinates.YCoordinate;
            var maxRowCoord = gameGrid.GetLength(0) - 1;
            var maxColumnCoord = gameGrid.GetLength(1) - 1;

            if (rowCoord == 0 && colCoord == 0)
            {
                neighboursCoordinates =
                    _cellNeighboursCoordinatesGenerator.GetGridTopLeftCornerOverlapCoordinates(maxRowCoord, maxColumnCoord,
                        rowCoord, colCoord);
            }
            else if (rowCoord == 0 && colCoord == maxColumnCoord)
            {
                neighboursCoordinates = _cellNeighboursCoordinatesGenerator.GetGridTopRightCornerOverlapCoordinates(maxRowCoord, maxColumnCoord,
                rowCoord, colCoord);
            }
            else if (rowCoord == maxRowCoord && colCoord == 0)
            {
                neighboursCoordinates =
                    _cellNeighboursCoordinatesGenerator.GetGridBottomLeftCornerOverlapCoordinates(maxColumnCoord,
                        rowCoord, colCoord);
            }
            else if (rowCoord == maxRowCoord && colCoord == maxColumnCoord)
            {
                neighboursCoordinates =
                    _cellNeighboursCoordinatesGenerator.GetGridBottomRightCornerOverlapCoordinates(rowCoord, colCoord);
            }
            else if (rowCoord == 0)
            {
                neighboursCoordinates =
                    _cellNeighboursCoordinatesGenerator.GetGridTopOverlapCoordinates(maxRowCoord, rowCoord,
                        colCoord);
            }
            else if (rowCoord == maxRowCoord)
            {
                neighboursCoordinates =
                    _cellNeighboursCoordinatesGenerator.GetGridBottomOverlapCoordinates(rowCoord, colCoord);
            }
            else if (colCoord == 0)
            {
                neighboursCoordinates = _cellNeighboursCoordinatesGenerator.GetGridLeftOverlapCoordinates(maxColumnCoord, rowCoord, colCoord);
            }
            else if (colCoord == maxColumnCoord)
            {
                neighboursCoordinates =
                    _cellNeighboursCoordinatesGenerator.GetGridRightOverlapCoordinates(rowCoord, colCoord);
            }

            else
            {
                neighboursCoordinates =
                    _cellNeighboursCoordinatesGenerator.GetGridNoOverlapCoordinates(rowCoord, colCoord);
            }

            var neighbours = new char[3, 3];
            var rowCount = 0;
            var columnCount = 0;
            for (var i = 0; i < neighboursCoordinates.GetLength(0); i++)
            {
                neighbours[rowCount, columnCount] = gameGrid[neighboursCoordinates[i, 0],
                    neighboursCoordinates[i, 1]];
                columnCount++;
                if (columnCount != 3) continue;
                columnCount = 0;
                rowCount++;
            }

            return neighbours;
        }
    }
}