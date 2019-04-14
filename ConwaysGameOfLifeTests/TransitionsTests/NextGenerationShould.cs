using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GamePlay;
using Xunit;

namespace ConwaysGameOfLifeTests.GamePlayTests
{
    public class NextGenerationShould
    {
        private readonly NextGeneration _nextGeneration;
        private readonly GameGrid _gameGrid;

        public NextGenerationShould()
        {
            _gameGrid = new GameGrid();
            _nextGeneration = new NextGeneration();
        }

        [Fact]
        public void Generate_The_Next_Generation_When_Live_Cells_In_Seed_Are_In_Middle_Of_Board()
        {
            var testGameGrid = new[,]
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

            _gameGrid.CurrentGameGrid = testGameGrid;

            _nextGeneration.GetNextGeneration(_gameGrid);

            var expectedGameGrid = new[,]
            {
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live,
                    (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Live, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Live, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Dead
                },
            };

            Assert.Equal(expectedGameGrid, _gameGrid.CurrentGameGrid);
        }

        [Fact]
        public void Generate_The_Next_Generation_When_Live_Cells_In_Seed_Have_Overlap()
        {
            var testGameGrid = new[,]
            {
                {
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Live, (char) CellType.Live
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live,
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Live
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live, (char) CellType.Live,
                    (char) CellType.Live, (char) CellType.Dead, (char) CellType.Live
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Live, (char) CellType.Live
                },
            };
            _gameGrid.CurrentGameGrid = testGameGrid;

            _nextGeneration.GetNextGeneration(_gameGrid);

            var expectedGameGrid = new[,]
            {
                {
                    (char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Live, (char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live
                },
                {
                    (char) CellType.Live, (char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live
                },
                {
                    (char) CellType.Dead, (char) CellType.Live, (char) CellType.Live, (char) CellType.Live,
                    (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead
                },
            };

            Assert.Equal(expectedGameGrid, _gameGrid.CurrentGameGrid);
        }

        [Fact]
        public void Generate_The_Next_Generation_For_Smallest_Grid_Size()
        {
            var gameGrid = new[,]
            {
                {
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Live
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead
                }
            };
            _gameGrid.CurrentGameGrid = gameGrid;

            _nextGeneration.GetNextGeneration(_gameGrid);

            var expectedGameGrid = new[,]
            {
                {
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Live
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead
                }
            };

            Assert.Equal(expectedGameGrid, _gameGrid.CurrentGameGrid);
        }
    }
}