using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.CellNeighboursGeneration.CellNeighboursCoordinates
{
    public class NoOverlapCoordinates
    {
        public Coordinate[] GetGridNoOverlapCoordinates(int rowCoord, int colCoord)
        {
            return new[]
            {
                new Coordinate {X = rowCoord - 1, Y = colCoord - 1},
                new Coordinate {X = rowCoord - 1, Y = colCoord},
                new Coordinate {X = rowCoord - 1, Y = colCoord + 1},
                new Coordinate {X = rowCoord, Y = colCoord - 1},
                new Coordinate {X = rowCoord, Y = colCoord},
                new Coordinate {X = rowCoord, Y = colCoord + 1},
                new Coordinate {X = rowCoord + 1, Y = colCoord - 1},
                new Coordinate {X = rowCoord + 1, Y = colCoord},
                new Coordinate {X = rowCoord + 1, Y = colCoord + 1}
            };
        }
    }
}