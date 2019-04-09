using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class GameGrid
    {
        public char[,] CurrentGameGrid { get; private set; }
        
        public void GenerateInitialGrid(int heightOfGrid, int widthOfGrid)
        {
            CurrentGameGrid = new char[heightOfGrid,widthOfGrid];
            
            for (var i = 0; i < CurrentGameGrid.GetLength(0); i++)
            {
                for (var j = 0; j < CurrentGameGrid.GetLength(1); j++)
                {
                    CurrentGameGrid[i, j] = (char) CellType.Dead;
                }
            }
        }

        public void UpdateGameGridCells(List<Coordinate> liveCellCoordinates, CellType cellType)
        {
            foreach (var coordinate in liveCellCoordinates)
            {
                CurrentGameGrid[coordinate.XCoordinate, coordinate.YCoordinate] = (char) cellType;
            }
        }
    }
}