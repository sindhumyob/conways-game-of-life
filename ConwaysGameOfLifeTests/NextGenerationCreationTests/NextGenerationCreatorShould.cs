using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.NextGenerationCreation;
using ConwaysGameOfLife.PlayGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTests.NextGenerationsCreationTests
{
    public class NextGenerationCreatorShould
    {
        private readonly NextGeneration _nextGeneration;
        private readonly GameGrid _gameGrid;

        public NextGenerationCreatorShould()
        {
            _gameGrid = new GameGrid();
            _nextGeneration = new NextGeneration();
        }

        [Fact]
        public void Create_The_Next_Generation_When_Live_Cells_In_Seed_Are_In_Middle_Of_Grid_With_No_Overlap()
        {
            var testGameGrid = new[,]
            {
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Live, CellType.Live,
                    CellType.Live, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Live, CellType.Live,
                    CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead, CellType.Dead
                },
            };

            _gameGrid.CurrentGameGrid = testGameGrid;

            _nextGeneration.CreateGeneration(_gameGrid);

            var expectedGameGrid = new[,]
            {
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Live,
                    CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead,
                    CellType.Live, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead,
                    CellType.Live, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Live, CellType.Dead,
                    CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead, CellType.Dead
                },
            };

            Assert.Equal(expectedGameGrid, _gameGrid.CurrentGameGrid);
        }

        [Fact]
        public void Create_The_Next_Generation_When_Live_Cells_In_Seed_Have_Grid_Overlap()
        {
            var testGameGrid = new[,]
            {
                {
                    CellType.Live, CellType.Live, CellType.Dead, CellType.Dead,
                    CellType.Dead, CellType.Live, CellType.Live
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Live, CellType.Dead, CellType.Dead, CellType.Live,
                    CellType.Live, CellType.Live, CellType.Live
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Live, CellType.Live,
                    CellType.Live, CellType.Dead, CellType.Live
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Live, CellType.Live, CellType.Dead, CellType.Dead,
                    CellType.Dead, CellType.Live, CellType.Live
                },
            };
            _gameGrid.CurrentGameGrid = testGameGrid;

            _nextGeneration.CreateGeneration(_gameGrid);

            var expectedGameGrid = new[,]
            {
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead,
                    CellType.Dead, CellType.Live, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead,
                    CellType.Dead, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Live, CellType.Dead, CellType.Live, CellType.Dead,
                    CellType.Dead, CellType.Dead, CellType.Live
                },
                {
                    CellType.Live, CellType.Dead, CellType.Live, CellType.Dead,
                    CellType.Dead, CellType.Dead, CellType.Live
                },
                {
                    CellType.Dead, CellType.Live, CellType.Live, CellType.Live,
                    CellType.Live, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead,
                    CellType.Dead, CellType.Live, CellType.Dead
                },
            };

            Assert.Equal(expectedGameGrid, _gameGrid.CurrentGameGrid);
        }

        [Fact]
        public void Create_The_Next_Generation_For_Smallest_Grid_Size()
        {
            var gameGrid = new[,]
            {
                {
                    CellType.Live, CellType.Live, CellType.Live
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Live, CellType.Dead, CellType.Dead
                }
            };
            _gameGrid.CurrentGameGrid = gameGrid;

            _nextGeneration.CreateGeneration(_gameGrid);

            var expectedGameGrid = new[,]
            {
                {
                    CellType.Live, CellType.Live, CellType.Live
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Live, CellType.Dead, CellType.Dead
                }
            };

            Assert.Equal(expectedGameGrid, _gameGrid.CurrentGameGrid);
        }
    }
}