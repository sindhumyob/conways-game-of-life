using ConwaysGameOfLife.CellNeighboursGeneration;
using ConwaysGameOfLife.GameHelpers;
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
        public void Return_Neighbours_Of_Selected_Cell_For_Top_Border_Overlap()
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
        public void Return_Neighbours_Of_Selected_Cell_For_Bottom_Border_Overlap()
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
        public void Return_Neighbours_Of_Selected_Cell_For_Left_Border_Overlap()
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
        public void Return_Neighbours_Of_Selected_Cell_For_Right_Border_Overlap()
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
        public void Return_Neighbours_Of_Selected_Cell_For_Top_Left_Corner_Overlap()
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
        public void Return_Neighbours_Of_Selected_Cell_For_Bottom_Left_Corner_Overlap()
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
        public void Return_Neighbours_Of_Selected_Cell_For_Top_Right_Corner_Overlap()
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
        public void Return_Neighbours_Of_Selected_Cell_For_Bottom_Right_Corner_Overlap()
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