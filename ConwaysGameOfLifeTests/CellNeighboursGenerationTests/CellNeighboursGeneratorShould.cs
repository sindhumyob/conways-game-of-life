using ConwaysGameOfLife.CellNeighboursGeneration;
using ConwaysGameOfLife.GamePlayHelpers;
using Xunit;

namespace ConwaysGameOfLifeTests.CellNeighboursGenerationTests
{
    public class CellNeighboursGeneratorShould
    {
        private readonly CellNeighboursGenerator _cellNeighboursGenerator;
        private readonly char[,] _testGameGrid;

        public CellNeighboursGeneratorShould()
        {
            _cellNeighboursGenerator = new CellNeighboursGenerator();
            _testGameGrid = new[,]
            {
                {
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Live, (char) CellType.Live
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
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Live, (char) CellType.Live
                },
            };
        }

        [Fact]
        public void Return_Neighbours_Of_Selected_Cell_When_There_Is_No_Overlap()
        {
            var returnedCellAndNeighbours = GetCellNeighbours(new Coordinate {XCoordinate = 3, YCoordinate = 2});

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

        [Fact]
        public void Return_Neighbours_Of_Selected_Cell_For_Top_Overlap()
        {
            var returnedCellAndNeighbours = GetCellNeighbours(new Coordinate {XCoordinate = 0, YCoordinate = 1});

            var expectedCellAndNeighbours = new[,]
            {
                {
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Dead
                },
                {
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                }
            };

            Assert.Equal(expectedCellAndNeighbours, returnedCellAndNeighbours);
        }

        [Fact]
        public void Return_Neighbours_Of_Selected_Cell_For_Bottom_Overlap()
        {
            var returnedCellAndNeighbours = GetCellNeighbours(new Coordinate {XCoordinate = 5, YCoordinate = 2});

            var expectedCellAndNeighbours = new[,]
            {
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead
                }
            };

            Assert.Equal(expectedCellAndNeighbours, returnedCellAndNeighbours);
        }

        [Fact]
        public void Return_Neighbours_Of_Selected_Cell_For_Left_Overlap()
        {
            var returnedCellAndNeighbours = GetCellNeighbours(new Coordinate {XCoordinate = 2, YCoordinate = 0});

            var expectedCellAndNeighbours = new[,]
            {
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live
                }
            };

            Assert.Equal(expectedCellAndNeighbours, returnedCellAndNeighbours);
        }

        [Fact]
        public void Return_Neighbours_Of_Selected_Cell_For_Right_Overlap()
        {
            var returnedCellAndNeighbours = GetCellNeighbours(new Coordinate {XCoordinate = 2, YCoordinate = 5});

            var expectedCellAndNeighbours = new[,]
            {
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                }
            };

            Assert.Equal(expectedCellAndNeighbours, returnedCellAndNeighbours);
        }

        [Fact]
        public void Return_Neighbours_Of_Selected_Cell_For_Top_Left_Cell_Overlap()
        {
            var returnedCellAndNeighbours = GetCellNeighbours(new Coordinate {XCoordinate = 0, YCoordinate = 0});

            var expectedCellAndNeighbours = new[,]
            {
                {
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Live
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

        [Fact]
        public void Return_Neighbours_Of_Selected_Cell_For_Bottom_Left_Cell_Overlap()
        {
            var returnedCellAndNeighbours = GetCellNeighbours(new Coordinate {XCoordinate = 5, YCoordinate = 0});

            var expectedCellAndNeighbours = new[,]
            {
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Live
                },
                {
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Live
                }
            };

            Assert.Equal(expectedCellAndNeighbours, returnedCellAndNeighbours);
        }

        [Fact]
        public void Return_Neighbours_Of_Selected_Cell_For_Top_Right_Cell_Overlap()
        {
            var returnedCellAndNeighbours = GetCellNeighbours(new Coordinate {XCoordinate = 0, YCoordinate = 5});

            var expectedCellAndNeighbours = new[,]
            {
                {
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Live
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


        [Fact]
        public void Return_Neighbours_Of_Selected_Cell_For_Bottom_Right_Cell_Overlap()
        {
            var returnedCellAndNeighbours = GetCellNeighbours(new Coordinate {XCoordinate = 5, YCoordinate = 5});

            var expectedCellAndNeighbours = new[,]
            {
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Live
                },
                {
                    (char) CellType.Live, (char) CellType.Live, (char) CellType.Live
                }
            };

            Assert.Equal(expectedCellAndNeighbours, returnedCellAndNeighbours);
        }

        private char[,] GetCellNeighbours(Coordinate selectedCellCoordinates)
        {
            return _cellNeighboursGenerator.GenerateCellNeighbours(_testGameGrid, selectedCellCoordinates);
        }
    }
}