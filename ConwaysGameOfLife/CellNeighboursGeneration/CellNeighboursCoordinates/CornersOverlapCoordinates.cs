using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.CellNeighboursGeneration.CellNeighboursCoordinates
{
    public class CornersOverlapCoordinates
    {
        public Coordinate[] GetGridTopLeftCornerOverlapCoordinates(int maxRowCoord, int maxColumnCoord, int rowCoord,
            int colCoord)
        {
            return new[]
            {
                new Coordinate {XCoordinate = maxRowCoord, YCoordinate = maxColumnCoord},
                new Coordinate {XCoordinate = maxRowCoord, YCoordinate = colCoord},
                new Coordinate {XCoordinate = maxRowCoord, YCoordinate = colCoord + 1},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = maxColumnCoord},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord + 1},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = maxColumnCoord},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = colCoord + 1}
            };
        }


        public Coordinate[] GetGridTopRightCornerOverlapCoordinates(int maxRowCoord, int maxColumnCoord, int rowCoord,
            int colCoord)
        {
            return new[]
            {
                new Coordinate {XCoordinate = maxRowCoord, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = maxRowCoord, YCoordinate = colCoord},
                new Coordinate {XCoordinate = maxRowCoord, YCoordinate = 0},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = maxColumnCoord},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord + 1, YCoordinate = 0}
            };
        }

        public Coordinate[] GetGridBottomLeftCornerOverlapCoordinates(int maxColumnCoord, int rowCoord, int colCoord)
        {
            return new[]
            {
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = maxColumnCoord},
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = colCoord + 1},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = maxColumnCoord},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord + 1},
                new Coordinate {XCoordinate = 0, YCoordinate = maxColumnCoord},
                new Coordinate {XCoordinate = 0, YCoordinate = colCoord},
                new Coordinate {XCoordinate = 0, YCoordinate = colCoord + 1}
            };
        }

        public Coordinate[] GetGridBottomRightCornerOverlapCoordinates(int rowCoord, int colCoord)
        {
            return new[]
            {
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord - 1, YCoordinate = 0},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = colCoord},
                new Coordinate {XCoordinate = rowCoord, YCoordinate = 0},
                new Coordinate {XCoordinate = 0, YCoordinate = colCoord - 1},
                new Coordinate {XCoordinate = 0, YCoordinate = colCoord},
                new Coordinate {XCoordinate = 0, YCoordinate = 0}
            };
        }
    }
}