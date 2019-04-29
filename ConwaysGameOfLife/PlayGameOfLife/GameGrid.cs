using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class GameGrid
    {
        public CellType[,] CurrentGrid { get; set; }

        public void Generate(GridDimensions gridDimensions)
        {
            CurrentGrid = new CellType[gridDimensions.Height, gridDimensions.Width];

            for (var i = 0; i < gridDimensions.Height; i++)
            {
                for (var j = 0; j < gridDimensions.Width; j++)
                {
                    CurrentGrid[i, j] = CellType.Dead;
                }
            }
        }

        public void Update(List<Coordinate> cellCoordinates, CellType cellType)
        {
            foreach (var coordinate in cellCoordinates)
            {
                CurrentGrid[coordinate.X, coordinate.Y] = cellType;
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
                    line += (char) CurrentGrid[i, j] + " ";
                }

                output.Add(line);
                line = string.Empty;
            }

            return string.Join("\n", output) + "\n";
        }

        public GridDimensions GetSize()
        {
            return new GridDimensions {Height = CurrentGrid.GetLength(0), Width = CurrentGrid.GetLength(1)};
        }

        public Coordinate GetGridCoordinate(Coordinate coordinate)
        {
            coordinate.X += -1;
            coordinate.Y += -1;
            return coordinate;
        }
    }
}