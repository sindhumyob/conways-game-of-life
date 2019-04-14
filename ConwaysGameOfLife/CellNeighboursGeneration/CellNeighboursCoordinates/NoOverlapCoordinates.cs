using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.CellNeighboursGeneration.CellNeighboursCoordinates
{
    public class NoOverlapCoordinates
    {
        public Coordinate[] GetGridNoOverlapCoordinates(int rowCoord, int colCoord)
        {
            return new[]
            {
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = colCoord + 1},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord + 1},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = colCoord + 1}
            };
        }
    }
}