using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class GameGrid
    {
        public CellType[,] CurrentGameGrid { get; set; }

        public void Generate(GridDimensions gridDimensions)
        {
            CurrentGameGrid = new CellType[gridDimensions.Height, gridDimensions.Width];

            for (var i = 0; i < gridDimensions.Height; i++)
            {
                for (var j = 0; j < gridDimensions.Width; j++)
                {
                    CurrentGameGrid[i, j] = CellType.Dead;
                }
            }
        }

        public void Update(List<Coordinate> cellCoordinates, CellType cellType)
        {
            foreach (var coordinate in cellCoordinates)
            {
                CurrentGameGrid[coordinate.X, coordinate.Y] = cellType;
            }
        }

        public string ConvertGridToOutput()
        {
            var output = new List<string>();
            var line = string.Empty;
            var gridDimensions = GetSize();
            for (var i = 0; i < gridDimensions.Height; i++)
            {
                for (var j = 0; j < gridDimensions.Width; j++)
                {
                    line += (char) CurrentGameGrid[i, j] + " ";
                }

                output.Add(line);
                line = string.Empty;
            }

            return string.Join("\n", output) + "\n";
        }

        public GridDimensions GetSize()
        {
            return new GridDimensions() {Height = CurrentGameGrid.GetLength(0), Width = CurrentGameGrid.GetLength(1)};
        }

        public Coordinate GetGridCoordinate(Coordinate coordinate)
        {
            coordinate.X += -1;
            coordinate.Y += -1;
            return coordinate;
        }
    }
}