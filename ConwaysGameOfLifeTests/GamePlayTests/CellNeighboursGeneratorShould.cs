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
        
        [Fact]
        public void Return_Neighbours_Of_Selected_Cell_For_Top_Overlap()
        {
            
            var selectedCellCoordinates = new Coordinate{XCoordinate = 0, YCoordinate = 1};

            var returnedCellAndNeighbours = _cellNeighboursGenerator.GenerateCellNeighbours(_gameGrid, selectedCellCoordinates);
            
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
            
            var selectedCellCoordinates = new Coordinate{XCoordinate = 5, YCoordinate = 2};

            var returnedCellAndNeighbours = _cellNeighboursGenerator.GenerateCellNeighbours(_gameGrid, selectedCellCoordinates);
            
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
            
            var selectedCellCoordinates = new Coordinate{XCoordinate = 2, YCoordinate = 0};

            var returnedCellAndNeighbours = _cellNeighboursGenerator.GenerateCellNeighbours(_gameGrid, selectedCellCoordinates);
            
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
            
            var selectedCellCoordinates = new Coordinate{XCoordinate = 2, YCoordinate = 5};

            var returnedCellAndNeighbours = _cellNeighboursGenerator.GenerateCellNeighbours(_gameGrid, selectedCellCoordinates);
            
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
            
            var selectedCellCoordinates = new Coordinate{XCoordinate = 0, YCoordinate = 0};

            var returnedCellAndNeighbours = _cellNeighboursGenerator.GenerateCellNeighbours(_gameGrid, selectedCellCoordinates);
            
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
            
            var selectedCellCoordinates = new Coordinate{XCoordinate = 5, YCoordinate = 0};

            var returnedCellAndNeighbours = _cellNeighboursGenerator.GenerateCellNeighbours(_gameGrid, selectedCellCoordinates);
            
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
            
            var selectedCellCoordinates = new Coordinate{XCoordinate = 0, YCoordinate = 5};

            var returnedCellAndNeighbours = _cellNeighboursGenerator.GenerateCellNeighbours(_gameGrid, selectedCellCoordinates);
            
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
            
            var selectedCellCoordinates = new Coordinate{XCoordinate = 5, YCoordinate = 5};

            var returnedCellAndNeighbours = _cellNeighboursGenerator.GenerateCellNeighbours(_gameGrid, selectedCellCoordinates);
            
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
    }
}