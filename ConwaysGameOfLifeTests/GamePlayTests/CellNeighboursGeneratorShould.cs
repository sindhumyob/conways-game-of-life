using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class CellNeighboursGeneratorShould
    {
        private readonly CellNeighboursGenerator _cellNeighboursGenerator;
        private char[,] _gameGrid;

        public CellNeighboursGeneratorShould()
        {
            _cellNeighboursGenerator = new CellNeighboursGenerator();
            _gameGrid = new[,]
            {
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live, (char) CellType.Live,
                    (char) CellType.Live, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Live, (char) CellType.Live, (char) CellType.Live,
                    (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Dead
                },
            };
        }

        [Fact]
        public void Return_Neighbours_Of_Selected_Cell_When_There_Is_No_Overlap()
        {
            
            var selectedCellCoordinates = new Coordinate{XCoordinate = 3, YCoordinate = 2};

            var returnedCellAndNeighbours = _cellNeighboursGenerator.GenerateCellNeighbours(_gameGrid, selectedCellCoordinates);
            
            var expectedCellAndNeighbours = new[,]
            {
                {
                    (char) CellType.Dead, (char) CellType.Live, (char) CellType.Live
                },
                {
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Live
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                }
            };
            
            Assert.Equal(expectedCellAndNeighbours, returnedCellAndNeighbours);
        }
    }
}