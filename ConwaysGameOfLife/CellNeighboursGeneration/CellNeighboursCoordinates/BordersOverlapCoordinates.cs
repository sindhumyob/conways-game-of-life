using ConwaysGameOfLife.GamePlayHelpers;

namespace ConwaysGameOfLife.CellNeighboursGeneration.CellNeighboursCoordinates
{
    public class BordersOverlapCoordinates
    {
        public Coordinate[] GetGridTopOverlapCoordinates(int maxRowCoord, int rowCoord, int colCoord)
        {
            return new[]
            {
                new Coordinate {XCoordinate = maxRowCoord, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = maxRowCoord, YCoordinate = colCoord},
                new Coordinate {XCoordinate = maxRowCoord, YCoordinate = colCoord + 1},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord + 1},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = colCoord + 1}
            };
        }

        public Coordinate[] GetGridBottomOverlapCoordinates(int rowCoord, int colCoord)
        {
            return new[]
            {
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = colCoord + 1},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord + 1},
                new Coordinate {XCoordinate = 0, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = 0, YCoordinate = colCoord},
                new Coordinate {XCoordinate = 0, YCoordinate = colCoord + 1}
            };
        }

        public Coordinate[] GetGridLeftOverlapCoordinates(int maxColumnCoord, int rowCoord, int colCoord)
        {
            return new[]
            {
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = maxColumnCoord},
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = colCoord + 1},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = maxColumnCoord},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord + 1},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = maxColumnCoord},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = colCoord + 1}
            };
        }

        public Coordinate[] GetGridRightOverlapCoordinates(int rowCoord, int colCoord)
        {
            return new[]
            {
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = 0},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = 0},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = 0}
            };
        }
    }
}