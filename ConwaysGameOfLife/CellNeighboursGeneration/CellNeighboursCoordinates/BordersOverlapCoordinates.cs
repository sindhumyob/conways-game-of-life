using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.CellNeighboursGeneration.CellNeighboursCoordinates
{
    public class BordersOverlapCoordinates
    {
        public Coordinate[] GetTopOverlapCoordinates(Coordinate cellCoordinates, Coordinate maxGridSizeCoordinates)
        {
            return new[]
            {
                new Coordinate {X = maxGridSizeCoordinates.X, Y = cellCoordinates.Y - 1},
                new Coordinate {X = maxGridSizeCoordinates.X, Y = cellCoordinates.Y},
                new Coordinate {X = maxGridSizeCoordinates.X, Y = cellCoordinates.Y + 1},
                new Coordinate {X = cellCoordinates.X, Y = cellCoordinates.Y - 1},
                new Coordinate {X = cellCoordinates.X, Y = cellCoordinates.Y},
                new Coordinate {X = cellCoordinates.X, Y = cellCoordinates.Y + 1},
                new Coordinate {X = cellCoordinates.X + 1, Y = cellCoordinates.Y - 1},
                new Coordinate {X = cellCoordinates.X + 1, Y = cellCoordinates.Y},
                new Coordinate {X = cellCoordinates.X + 1, Y = cellCoordinates.Y + 1}
            };
        }

        public Coordinate[] GetBottomOverlapCoordinates(Coordinate cellCoordinates)
        {
            return new[]
            {
                new Coordinate {X = cellCoordinates.X - 1, Y = cellCoordinates.Y - 1},
                new Coordinate {X = cellCoordinates.X - 1, Y = cellCoordinates.Y},
                new Coordinate {X = cellCoordinates.X - 1, Y = cellCoordinates.Y + 1},
                new Coordinate {X = cellCoordinates.X, Y = cellCoordinates.Y - 1},
                new Coordinate {X = cellCoordinates.X, Y = cellCoordinates.Y},
                new Coordinate {X = cellCoordinates.X, Y = cellCoordinates.Y + 1},
                new Coordinate {X = 0, Y = cellCoordinates.Y - 1},
                new Coordinate {X = 0, Y = cellCoordinates.Y},
                new Coordinate {X = 0, Y = cellCoordinates.Y + 1}
            };
        }

        public Coordinate[] GetLeftOverlapCoordinates(Coordinate cellCoordinates, Coordinate maxGridSizeCoordinates)
        {
            return new[]
            {
                new Coordinate {X = cellCoordinates.X - 1, Y = maxGridSizeCoordinates.Y},
                new Coordinate {X = cellCoordinates.X - 1, Y = cellCoordinates.Y},
                new Coordinate {X = cellCoordinates.X - 1, Y = cellCoordinates.Y + 1},
                new Coordinate {X = cellCoordinates.X, Y = maxGridSizeCoordinates.Y},
                new Coordinate {X = cellCoordinates.X, Y = cellCoordinates.Y},
                new Coordinate {X = cellCoordinates.X, Y = cellCoordinates.Y + 1},
                new Coordinate {X = cellCoordinates.X + 1, Y = maxGridSizeCoordinates.Y},
                new Coordinate {X = cellCoordinates.X + 1, Y = cellCoordinates.Y},
                new Coordinate {X = cellCoordinates.X + 1, Y = cellCoordinates.Y + 1}
            };
        }

        public Coordinate[] GetRightOverlapCoordinates(Coordinate cellCoordinates)
        {
            return new[]
            {
                new Coordinate {X = cellCoordinates.X - 1, Y = cellCoordinates.Y - 1},
                new Coordinate {X = cellCoordinates.X - 1, Y = cellCoordinates.Y},
                new Coordinate {X = cellCoordinates.X - 1, Y = 0},
                new Coordinate {X = cellCoordinates.X, Y = cellCoordinates.Y - 1},
                new Coordinate {X = cellCoordinates.X, Y = cellCoordinates.Y},
                new Coordinate {X = cellCoordinates.X, Y = 0},
                new Coordinate {X = cellCoordinates.X + 1, Y = cellCoordinates.Y - 1},
                new Coordinate {X = cellCoordinates.X + 1, Y = cellCoordinates.Y},
                new Coordinate {X = cellCoordinates.X + 1, Y = 0}
            };
        }
    }
}