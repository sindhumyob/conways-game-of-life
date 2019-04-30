using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.NextGenerationCreation;
using ConwaysGameOfLife.PlayGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTests.NextGenerationCreationTests
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
        public void Create_NextGeneration_When_LiveCells_Are_In_MiddleOfGrid_With_NoOverlap()
        {
            var initialGameGrid = new[,]
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
                }
            };

            _gameGrid.Grid = initialGameGrid;
            _nextGeneration.CreateGeneration(_gameGrid);

            var expectedGameGrid = new[,]
            {
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead, CellType.Live, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead, CellType.Live, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead
                }
            };

            Assert.Equal(expectedGameGrid, _gameGrid.Grid);
        }

        [Fact]
        public void Create_NextGeneration_When_LiveCells_Have_GridOverlap_On_Corners()
        {
            var initialGameGrid = new[,]
            {
                {
                    CellType.Live, CellType.Dead, CellType.Dead, CellType.Live
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Live, CellType.Dead
                },
                {
                    CellType.Live, CellType.Dead, CellType.Dead, CellType.Live
                }
            };
            _gameGrid.Grid = initialGameGrid;
            _nextGeneration.CreateGeneration(_gameGrid);

            var expectedGameGrid = new[,]
            {
                {
                    CellType.Dead, CellType.Live, CellType.Live, CellType.Live
                },
                {
                    CellType.Dead, CellType.Live, CellType.Live, CellType.Dead
                },
                {
                    CellType.Live, CellType.Live, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Live, CellType.Live
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead
                }
            };

            Assert.Equal(expectedGameGrid, _gameGrid.Grid);
        }

        [Fact]
        public void Create_NextGeneration_When_LiveCells_Have_GridOverlap_On_Sides()
        {
            var initialGameGrid = new[,]
            {
                {
                    CellType.Dead, CellType.Live, CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Live, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Live, CellType.Dead, CellType.Live
                },
                {
                    CellType.Live, CellType.Dead, CellType.Dead, CellType.Live, CellType.Live, CellType.Dead,
                    CellType.Dead, CellType.Live, CellType.Live
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Live, CellType.Live, CellType.Live, CellType.Dead,
                    CellType.Dead, CellType.Live, CellType.Dead
                },
                {
                    CellType.Live, CellType.Dead, CellType.Live, CellType.Live, CellType.Dead, CellType.Live,
                    CellType.Dead, CellType.Live, CellType.Dead
                },
                {
                    CellType.Live, CellType.Dead, CellType.Live, CellType.Live, CellType.Dead, CellType.Live,
                    CellType.Dead, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Live, CellType.Live, CellType.Dead, CellType.Live,
                    CellType.Dead, CellType.Dead, CellType.Dead
                }
            };
            _gameGrid.Grid = initialGameGrid;
            _nextGeneration.CreateGeneration(_gameGrid);

            var expectedGameGrid = new[,]
            {
                {
                    CellType.Live, CellType.Live, CellType.Dead, CellType.Live, CellType.Dead, CellType.Live,
                    CellType.Live, CellType.Live, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Live, CellType.Dead, CellType.Live,
                    CellType.Live, CellType.Dead, CellType.Live
                },
                {
                    CellType.Live, CellType.Live, CellType.Dead, CellType.Dead, CellType.Live, CellType.Live,
                    CellType.Live, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Live,
                    CellType.Dead, CellType.Live, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Live,
                    CellType.Dead, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Live,
                    CellType.Dead, CellType.Dead, CellType.Live
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Live,
                    CellType.Live, CellType.Dead, CellType.Dead
                }
            };

            Assert.Equal(expectedGameGrid, _gameGrid.Grid);
        }


        [Fact]
        public void Create_NextGeneration_When_LiveCells_Have_GridOverlap_On_AllSides_And_AllCorners()
        {
            var initialGameGrid = new[,]
            {
                {
                    CellType.Live, CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Live,
                    CellType.Live
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead
                },
                {
                    CellType.Live, CellType.Dead, CellType.Dead, CellType.Live, CellType.Live, CellType.Live,
                    CellType.Live
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Live, CellType.Live, CellType.Live, CellType.Dead,
                    CellType.Live
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead
                },
                {
                    CellType.Live, CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Live,
                    CellType.Live
                }
            };
            _gameGrid.Grid = initialGameGrid;
            _nextGeneration.CreateGeneration(_gameGrid);

            var expectedGameGrid = new[,]
            {
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Live,
                    CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead
                },
                {
                    CellType.Live, CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Live
                },
                {
                    CellType.Live, CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Live
                },
                {
                    CellType.Dead, CellType.Live, CellType.Live, CellType.Live, CellType.Live, CellType.Dead,
                    CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Live,
                    CellType.Dead
                }
            };

            Assert.Equal(expectedGameGrid, _gameGrid.Grid);
        }

        [Fact]
        public void Create_NextGeneration_Where_CornerDeadCells_Turn_Live()
        {
            var initialGameGrid = new[,]
            {
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Live,
                    CellType.Dead
                },
                {
                    CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Live,
                    CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Live,
                    CellType.Dead
                }
            };
            _gameGrid.Grid = initialGameGrid;
            _nextGeneration.CreateGeneration(_gameGrid);

            var expectedGameGrid = new[,]
            {
                {
                    CellType.Live, CellType.Live, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Live
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Dead
                },
                {
                    CellType.Live, CellType.Live, CellType.Live, CellType.Dead, CellType.Live, CellType.Live,
                    CellType.Live
                }
            };

            Assert.Equal(expectedGameGrid, _gameGrid.Grid);
        }

        [Fact]
        public void Create_NextGeneration_For_SmallestGrid()
        {
            var initialGameGrid = new[,]
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
            _gameGrid.Grid = initialGameGrid;
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

            Assert.Equal(expectedGameGrid, _gameGrid.Grid);
        }
    }
}