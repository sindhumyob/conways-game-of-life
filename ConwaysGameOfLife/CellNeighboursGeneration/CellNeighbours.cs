using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.PlayGameOfLife;

namespace ConwaysGameOfLife.CellNeighboursGeneration
{
    public class CellNeighbours
    {
        private readonly NeighboursCoordinatesGenerator _neighboursCoordinatesGenerator;
        private const int CellNeighboursArraySize = 3;

        public CellNeighbours()
        {
            _neighboursCoordinatesGenerator = new NeighboursCoordinatesGenerator();
        }

        public CellType[,] GetNeighbours(GameGrid gameGrid, Coordinate cellCoordinates)
        {
            var (gridHeight, gridWidth) = gameGrid.GetSize();
            var neighboursCoordinates =
                _neighboursCoordinatesGenerator.GetCoordinates(cellCoordinates, gridHeight,
                    gridWidth);

            var cellAndNeighbours = new CellType[CellNeighboursArraySize, CellNeighboursArraySize];
            var rowIndex = 0;
            var columnIndex = 0;
            foreach (var neighbourCoordinate in neighboursCoordinates)
            {
                cellAndNeighbours[rowIndex, columnIndex] =
                    gameGrid.CurrentGameGrid[neighbourCoordinate.X, neighbourCoordinate.Y];
                columnIndex++;

                if (columnIndex != 3) continue;
                columnIndex = 0;
                rowIndex++;
            }

            return cellAndNeighbours;
        }
    }
}