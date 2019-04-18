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
                new Coordinate {X = maxRowCoord, Y = maxColumnCoord},
                new Coordinate {X = maxRowCoord, Y = colCoord},
                new Coordinate {X = maxRowCoord, Y = colCoord + 1},
                new Coordinate {X = rowCoord, Y = maxColumnCoord},
                new Coordinate {X = rowCoord, Y = colCoord},
                new Coordinate {X = rowCoord, Y = colCoord + 1},
                new Coordinate {X = rowCoord + 1, Y = maxColumnCoord},
                new Coordinate {X = rowCoord + 1, Y = colCoord},
                new Coordinate {X = rowCoord + 1, Y = colCoord + 1}
            };
        }


        public Coordinate[] GetGridTopRightCornerOverlapCoordinates(int maxRowCoord, int maxColumnCoord, int rowCoord,
            int colCoord)
        {
            return new[]
            {
                new Coordinate {X = maxRowCoord, Y = colCoord - 1},
                new Coordinate {X = maxRowCoord, Y = colCoord},
                new Coordinate {X = maxRowCoord, Y = 0},
                new Coordinate {X = rowCoord, Y = colCoord - 1},
                new Coordinate {X = rowCoord, Y = colCoord},
                new Coordinate {X = rowCoord, Y = maxColumnCoord},
                new Coordinate {X = rowCoord + 1, Y = colCoord - 1},
                new Coordinate {X = rowCoord + 1, Y = colCoord},
                new Coordinate {X = rowCoord + 1, Y = 0}
            };
        }

        public Coordinate[] GetGridBottomLeftCornerOverlapCoordinates(int maxColumnCoord, int rowCoord, int colCoord)
        {
            return new[]
            {
                new Coordinate {X = rowCoord - 1, Y = maxColumnCoord},
                new Coordinate {X = rowCoord - 1, Y = colCoord},
                new Coordinate {X = rowCoord - 1, Y = colCoord + 1},
                new Coordinate {X = rowCoord, Y = maxColumnCoord},
                new Coordinate {X = rowCoord, Y = colCoord},
                new Coordinate {X = rowCoord, Y = colCoord + 1},
                new Coordinate {X = 0, Y = maxColumnCoord},
                new Coordinate {X = 0, Y = colCoord},
                new Coordinate {X = 0, Y = colCoord + 1}
            };
        }

        public Coordinate[] GetGridBottomRightCornerOverlapCoordinates(int rowCoord, int colCoord)
        {
            return new[]
            {
                new Coordinate {X = rowCoord - 1, Y = colCoord - 1},
                new Coordinate {X = rowCoord - 1, Y = colCoord},
                new Coordinate {X = rowCoord - 1, Y = 0},
                new Coordinate {X = rowCoord, Y = colCoord - 1},
                new Coordinate {X = rowCoord, Y = colCoord},
                new Coordinate {X = rowCoord, Y = 0},
                new Coordinate {X = 0, Y = colCoord - 1},
                new Coordinate {X = 0, Y = colCoord},
                new Coordinate {X = 0, Y = 0}
            };
        }
    }
}