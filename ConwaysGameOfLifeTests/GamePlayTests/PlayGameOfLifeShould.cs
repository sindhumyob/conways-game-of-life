using ConwaysGameOfLife.GamePlay;
using ConwaysGameOfLife.GamePlayHelpers;
using Xunit;

namespace ConwaysGameOfLifeTests.GamePlayTests
{
    public class PlayGameOfLifeShould
    {
        private readonly PlayGameOfLife _playGameOfLife;
        private readonly GameGrid _gameGrid;

        public PlayGameOfLifeShould()
        {
            _gameGrid = new GameGrid();
            _playGameOfLife = new PlayGameOfLife();
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

            _playGameOfLife.GetNextGeneration(_gameGrid);

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

            _playGameOfLife.GetNextGeneration(_gameGrid);

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

            _playGameOfLife.GetNextGeneration(_gameGrid);

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