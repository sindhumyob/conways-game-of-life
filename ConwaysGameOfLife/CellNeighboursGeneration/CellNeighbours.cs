using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.PlayGameOfLife;

namespace ConwaysGameOfLife.CellNeighboursGeneration
{
    public class CellNeighbours
    {
        private readonly NeighboursCoordinates _neighboursCoordinates;
        private const int CellNeighboursArraySize = 3;

        public CellNeighbours()
        {
            _neighboursCoordinates = new NeighboursCoordinates();
        }

        public CellType[,] GetNeighbours(GameGrid gameGrid, Coordinate cellCoordinates)
        {
            var gridDimensions = gameGrid.GetSize();
            var neighboursCoordinates =
                _neighboursCoordinates.GetCoordinates(cellCoordinates, gridDimensions);

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