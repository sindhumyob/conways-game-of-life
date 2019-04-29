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
        public void Generate_And_Update_GameGrid_With_Specified_LiveCells_And_DeadCells()
        {
            var gridDimensions = new GridDimensions {Height = 6, Width = 6};

            _gameGrid.Generate(gridDimensions);

            var liveCellCoordinates = new List<Coordinate>
            {
                new Coordinate {X = 3, Y = 1},
                new Coordinate {X = 3, Y = 2},
                new Coordinate {X = 3, Y = 3},
                new Coordinate {X = 2, Y = 2},
                new Coordinate {X = 2, Y = 3},
                new Coordinate {X = 2, Y = 4}
            };
            _gameGrid.Update(liveCellCoordinates, CellType.Live);

            var deadCellCoordinates = new List<Coordinate>
            {
                new Coordinate {X = 3, Y = 2},
                new Coordinate {X = 3, Y = 3},
                new Coordinate {X = 2, Y = 2},
                new Coordinate {X = 2, Y = 3}
            };
            _gameGrid.Update(deadCellCoordinates, CellType.Dead);

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

            Assert.Equal(expectedGrid, _gameGrid.CurrentGrid);
        }
    }
}