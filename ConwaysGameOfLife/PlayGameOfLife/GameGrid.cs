using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class GameGrid
    {
        public char[,] CurrentGameGrid { get; set; }

        public void GenerateInitialGrid(int heightOfGrid, int widthOfGrid)
        {
            CurrentGameGrid = new char[heightOfGrid, widthOfGrid];

            for (var i = 0; i < CurrentGameGrid.GetLength(0); i++)
            {
                for (var j = 0; j < CurrentGameGrid.GetLength(1); j++)
                {
                    CurrentGameGrid[i, j] = (char) CellType.Dead;
                }
            }
        }

        public void UpdateGameGridCells(List<Coordinate> cellCoordinates, CellType cellType)
        {
            foreach (var coordinate in cellCoordinates)
            {
                CurrentGameGrid[coordinate.X, coordinate.Y] = (char) cellType;
            }
        }
        
        public string ConvertGridToOutput()
        {
            var output = new List<string>();
            var line = string.Empty;
            for (var i = 0; i < CurrentGameGrid.GetLength(0); i++)
            {
                for (var j = 0; j < CurrentGameGrid.GetLength(1); j++)
                {
                    line += CurrentGameGrid[i, j] + " ";
                }

                output.Add(line);
                line = string.Empty;
            }

            return string.Join("\n", output) + "\n";
        }

        public (int,int) GetMaxGridSizeCoordinates()
        {
            return (CurrentGameGrid.GetLength(0)-1,CurrentGameGrid.GetLength(1)-1);
        }

        public Coordinate ConvertInputCoordinateToGridCoordinate(Coordinate coordinate)
        {
            coordinate.X += - 1;
            coordinate.Y += - 1;
            return coordinate;
        }
    }
}