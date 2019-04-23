using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.CellNeighboursGeneration
{
    public class CellNeighboursCoordinatesGenerator
    {
        public List<Coordinate> GetCellNeighboursCoordinates(Coordinate cellCoordinates, int gridHeight,
            int gridWidth)
        {
            var neighboursCoordinates = new List<Coordinate> { };

            var coordinatesToGenerate = new[]
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

            foreach (var coordinate in coordinatesToGenerate)
            {
                neighboursCoordinates.Add(GetNeighbourCoordinate(coordinate, gridHeight, gridWidth));
            }

            return neighboursCoordinates;
        }

        private Coordinate GetNeighbourCoordinate(Coordinate coordinate, int gridHeight, int gridWidth)
        {
            return new Coordinate
            {
                X = (coordinate.X + gridHeight) % gridHeight, Y = (coordinate.Y + gridWidth) % gridWidth
            };
        }
    }
}