using System;
using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTests
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
            var heightOfGrid = 12;
            var widthOfGrid = 10;

            _gameGrid.GenerateInitialGrid(heightOfGrid, widthOfGrid);

            var expectedGrid = GenerateInitialTestGrid(heightOfGrid, widthOfGrid);
            
            Assert.Equal(expectedGrid, _gameGrid.CurrentGameGrid);
        }
        
        [Fact]
        public void Update_Game_Grid_With_Specified_Live_Cells()
        {
            var heightOfGrid = 6;
            var widthOfGrid = 6;

            _gameGrid.GenerateInitialGrid(heightOfGrid, widthOfGrid);

            var liveCellCoordinates = new List<Coordinate>
            {
                new Coordinate {XCoordinate = 3, YCoordinate = 1},
                new Coordinate {XCoordinate = 3, YCoordinate = 2},
                new Coordinate {XCoordinate = 3, YCoordinate = 3},
                new Coordinate {XCoordinate = 2, YCoordinate = 2},
                new Coordinate {XCoordinate = 2, YCoordinate = 3},
                new Coordinate {XCoordinate = 2, YCoordinate = 4}
            };
            _gameGrid.UpdateGameGridCells(liveCellCoordinates, CellType.Live);

            var expectedGrid = new[,] {
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead},
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead},
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live, (char) CellType.Live, (char) CellType.Live, (char) CellType.Dead},
                {(char) CellType.Dead, (char) CellType.Live, (char) CellType.Live, (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead},
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead},
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead},
            };
            
            Assert.Equal(expectedGrid, _gameGrid.CurrentGameGrid);
        }
        
        [Fact]
        public void Update_Game_Grid_With_Specified_Dead_Cells()
        {
            var heightOfGrid = 6;
            var widthOfGrid = 6;

            _gameGrid.GenerateInitialGrid(heightOfGrid, widthOfGrid);

            var liveCellCoordinates = new List<Coordinate>
            {
                new Coordinate {XCoordinate = 3, YCoordinate = 1},
                new Coordinate {XCoordinate = 3, YCoordinate = 2},
                new Coordinate {XCoordinate = 3, YCoordinate = 3},
                new Coordinate {XCoordinate = 2, YCoordinate = 2},
                new Coordinate {XCoordinate = 2, YCoordinate = 3},
                new Coordinate {XCoordinate = 2, YCoordinate = 4}
            };
            _gameGrid.UpdateGameGridCells(liveCellCoordinates, CellType.Live);
            
            var deadCellCoordinates = new List<Coordinate>
            {
                new Coordinate {XCoordinate = 3, YCoordinate = 2},
                new Coordinate {XCoordinate = 3, YCoordinate = 3},
                new Coordinate {XCoordinate = 2, YCoordinate = 2},
                new Coordinate {XCoordinate = 2, YCoordinate = 3}
            };
            _gameGrid.UpdateGameGridCells(deadCellCoordinates, CellType.Dead);

            var expectedGrid = new[,] {
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead},
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead},
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead},
                {(char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead},
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead},
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead},
            };
            
            Assert.Equal(expectedGrid, _gameGrid.CurrentGameGrid);
        }

        private char[,] GenerateInitialTestGrid(int heightOfGrid, int widthOfGrid)
        {
            var expectedGrid = new char[heightOfGrid, widthOfGrid];
            for (var i = 0; i < expectedGrid.GetLength(0); i++)
            {
                for (var j = 0; j < expectedGrid.GetLength(1); j++)
                {
                    expectedGrid[i, j] = (char) CellType.Dead;
                }
            }

            return expectedGrid;
        }
    }
}