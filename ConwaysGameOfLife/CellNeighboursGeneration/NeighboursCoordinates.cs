using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.CellNeighboursGeneration
{
    public class NeighboursCoordinates
    {
        public List<Coordinate> GetCoordinates(Coordinate cellCoordinates, GridDimensions gridDimensions)
        {
            var neighboursCoordinates = new List<Coordinate> { };

            var gridNeighboursCoordinatesToGenerate = new List<Coordinate>
            {
                new Coordinate {X = cellCoordinates.X - 1, Y = cellCoordinates.Y - 1},
                new Coordinate {X = cellCoordinates.X - 1, Y = cellCoordinates.Y},
                new Coordinate {X = cellCoordinates.X - 1, Y = cellCoordinates.Y + 1},
                new Coordinate {X = cellCoordinates.X, Y = cellCoordinates.Y - 1},
                new Coordinate {X = cellCoordinates.X, Y = cellCoordinates.Y},
                new Coordinate {X = cellCoordinates.X, Y = cellCoordinates.Y + 1},
                new Coordinate {X = cellCoordinates.X + 1, Y = cellCoordinates.Y - 1},
                new Coordinate {X = cellCoordinates.X + 1, Y = cellCoordinates.Y},
                new Coordinate {X = cellCoordinates.X + 1, Y = cellCoordinates.Y + 1}
            };

            foreach (var coordinate in gridNeighboursCoordinatesToGenerate)
            {
                neighboursCoordinates.Add(GetGridCoordinate(coordinate, gridDimensions));
            }

            return neighboursCoordinates;
        }

        private Coordinate GetGridCoordinate(Coordinate coordinate, GridDimensions gridDimensions)
        {
            return new Coordinate
            {
                X = (coordinate.X + gridDimensions.Height) % gridDimensions.Height,
                Y = (coordinate.Y + gridDimensions.Width) % gridDimensions.Width
            };
        }
    }
}