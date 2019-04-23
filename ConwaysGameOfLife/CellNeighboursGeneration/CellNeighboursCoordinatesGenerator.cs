using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.CellNeighboursGeneration
{
    public class CellNeighboursCoordinatesGenerator
    {
        public List<Coordinate> GetNeighboursCoordinates(Coordinate cellCoordinates, int gridHeight,
            int gridWidth)
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
                neighboursCoordinates.Add(GetGridNeighbourCoordinate(coordinate, gridHeight, gridWidth));
            }

            return neighboursCoordinates;
        }

        private Coordinate GetGridNeighbourCoordinate(Coordinate coordinate, int gridHeight, int gridWidth)
        {
            return new Coordinate
            {
                X = (coordinate.X + gridHeight) % gridHeight, Y = (coordinate.Y + gridWidth) % gridWidth
            };
        }
    }
}