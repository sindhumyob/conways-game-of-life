using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.PlayGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTests.PlayGameOfLifeTests
{
    public class GameGridShould
    {
        private readonly GameGrid _gameGrid;

        public GameGridShould()
        {
            _gameGrid = new GameGrid();
        }

        [Fact]
        public void Generate_Game_Grid_With_Dimensions_That_Resembles_Input_Grid_Size()
        {
            const int heightOfGrid = 3;
            const int widthOfGrid = 3;

            _gameGrid.GenerateInitialGrid(heightOfGrid, widthOfGrid);

            var expectedGrid = new[,]
            {
                {
                    CellType.Dead, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead
                }
            };

            Assert.Equal(expectedGrid, _gameGrid.CurrentGameGrid);
        }

        [Fact]
        public void Update_Game_Grid_With_Specified_Live_Cells_And_Dead_Cells()
        {
            const int heightOfGrid = 6;
            const int widthOfGrid = 6;

            _gameGrid.GenerateInitialGrid(heightOfGrid, widthOfGrid);

            var liveCellCoordinates = new List<Coordinate>
            {
                new Coordinate {X = 3, Y = 1},
                new Coordinate {X = 3, Y = 2},
                new Coordinate {X = 3, Y = 3},
                new Coordinate {X = 2, Y = 2},
                new Coordinate {X = 2, Y = 3},
                new Coordinate {X = 2, Y = 4}
            };
            _gameGrid.UpdateGameGridCells(liveCellCoordinates, CellType.Live);

            var deadCellCoordinates = new List<Coordinate>
            {
                new Coordinate {X = 3, Y = 2},
                new Coordinate {X = 3, Y = 3},
                new Coordinate {X = 2, Y = 2},
                new Coordinate {X = 2, Y = 3}
            };
            _gameGrid.UpdateGameGridCells(deadCellCoordinates, CellType.Dead);

            var expectedGrid = new[,]
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
                    CellType.Dead, CellType.Dead, CellType.Dead, CellType.Dead,
                    CellType.Live, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead, CellType.Dead,
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

            Assert.Equal(expectedGrid, _gameGrid.CurrentGameGrid);
        }
    }
}