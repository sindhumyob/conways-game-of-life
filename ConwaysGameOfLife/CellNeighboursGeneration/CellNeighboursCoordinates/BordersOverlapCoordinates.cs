using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.CellNeighboursGeneration.CellNeighboursCoordinates
{
    public class BordersOverlapCoordinates
    {
        public Coordinate[] GetGridTopOverlapCoordinates(int maxRowCoord, int rowCoord, int colCoord)
        {
            return new[]
            {
                new Coordinate {X = maxRowCoord, Y = colCoord - 1},
                new Coordinate {X = maxRowCoord, Y = colCoord},
                new Coordinate {X = maxRowCoord, Y = colCoord + 1},
                new Coordinate {X = rowCoord, Y = colCoord - 1},
                new Coordinate {X = rowCoord, Y = colCoord},
                new Coordinate {X = rowCoord, Y = colCoord + 1},
                new Coordinate {X = rowCoord + 1, Y = colCoord - 1},
                new Coordinate {X = rowCoord + 1, Y = colCoord},
                new Coordinate {X = rowCoord + 1, Y = colCoord + 1}
            };
        }

        public Coordinate[] GetGridBottomOverlapCoordinates(int rowCoord, int colCoord)
        {
            return new[]
            {
                new Coordinate {X = rowCoord - 1, Y = colCoord - 1},
                new Coordinate {X = rowCoord - 1, Y = colCoord},
                new Coordinate {X = rowCoord - 1, Y = colCoord + 1},
                new Coordinate {X = rowCoord, Y = colCoord - 1},
                new Coordinate {X = rowCoord, Y = colCoord},
                new Coordinate {X = rowCoord, Y = colCoord + 1},
                new Coordinate {X = 0, Y = colCoord - 1},
                new Coordinate {X = 0, Y = colCoord},
                new Coordinate {X = 0, Y = colCoord + 1}
            };
        }

        public Coordinate[] GetGridLeftOverlapCoordinates(int maxColumnCoord, int rowCoord, int colCoord)
        {
            return new[]
            {
                new Coordinate {X = rowCoord - 1, Y = maxColumnCoord},
                new Coordinate {X = rowCoord - 1, Y = colCoord},
                new Coordinate {X = rowCoord - 1, Y = colCoord + 1},
                new Coordinate {X = rowCoord, Y = maxColumnCoord},
                new Coordinate {X = rowCoord, Y = colCoord},
                new Coordinate {X = rowCoord, Y = colCoord + 1},
                new Coordinate {X = rowCoord + 1, Y = maxColumnCoord},
                new Coordinate {X = rowCoord + 1, Y = colCoord},
                new Coordinate {X = rowCoord + 1, Y = colCoord + 1}
            };
        }

        public Coordinate[] GetGridRightOverlapCoordinates(int rowCoord, int colCoord)
        {
            return new[]
            {
                new Coordinate {X = rowCoord - 1, Y = colCoord - 1},
                new Coordinate {X = rowCoord - 1, Y = colCoord},
                new Coordinate {X = rowCoord - 1, Y = 0},
                new Coordinate {X = rowCoord, Y = colCoord - 1},
                new Coordinate {X = rowCoord, Y = colCoord},
                new Coordinate {X = rowCoord, Y = 0},
                new Coordinate {X = rowCoord + 1, Y = colCoord - 1},
                new Coordinate {X = rowCoord + 1, Y = colCoord},
                new Coordinate {X = rowCoord + 1, Y = 0}
            };
        }
    }
}