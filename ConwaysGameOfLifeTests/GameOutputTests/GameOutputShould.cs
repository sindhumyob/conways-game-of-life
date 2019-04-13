using System.Collections.Generic;
using ConwaysGameOfLife;
using ConwaysGameOfLife.GamePlayHelpers;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class GameOutputShould
    {
        private readonly GameOutput _gameOutput;

        public GameOutputShould()
        {
            _gameOutput = new GameOutput();
        }

        [Fact]
        public void Return_Game_Welcome_Message()
        {
            Assert.Equal("Welcome to Conway's Game of Life!\n", _gameOutput.WelcomeMessage());
        }

        [Fact]
        public void Return_Enter_Grid_Height_Message()
        {
            Assert.Equal("Please enter the height of your game grid or quit the game with 'q': ",
                _gameOutput.EnterGridHeightMessage());
        }

        [Fact]
        public void Return_Enter_Grid_Width_Message()
        {
            Assert.Equal("Please enter the width of your game grid or quit the game with 'q': ",
                _gameOutput.EnterGridWidthMessage());
        }

        [Fact]
        public void Return_Invalid_Grid_Size_Message()
        {
            Assert.Equal("Please enter a valid grid size input consisting of a single positive whole number\n",
                _gameOutput.InvalidGridSizeMessage());
        }

        [Fact]
        public void Return_Current_Grid_During_Player_Input_Message()
        {
            var initialGrid = new[,]
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
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead,
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
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead,
                    (char) CellType.Dead, (char) CellType.Dead
                },
            };

            var expectedMessage = "Perfect, here is the grid:\n" + PrintGrid(initialGrid);
            Assert.Equal(expectedMessage, _gameOutput.PrintGridMessage(initialGrid));
        }

        [Fact]
        public void Return_Adding_Initial_Seed_Message()
        {
            Assert.Equal("It's now time to add the seed of the system:\n", _gameOutput.AddInitialSeedMessage());
        }

        [Fact]
        public void Return_Enter_X_Coordinate_Of_Cell_In_Seed_Message()
        {
            var maxSizeOfCoordinate = 15;
            Assert.Equal("Please enter the x coordinate between 1-15 of the cell in the seed or quit the game with 'q': ",
                _gameOutput.EnterXCoordinateOfCellMessage(maxSizeOfCoordinate));
        }

        [Fact]
        public void Return_Enter_Y_Coordinate_Of_Cell_In_Seed_Message()
        {
            var maxSizeOfCoordinate = 20;
            Assert.Equal("Please enter the y coordinate between 1-20 of the cell in the seed or quit the game with 'q': ",
                _gameOutput.EnterYCoordinateOfCellMessage(maxSizeOfCoordinate));
        }

        [Fact]
        public void Return_Invalid_Coordinate_Message()
        {
            var heightOfBoard = 20;
            Assert.Equal(
                "Please enter valid coordinate inputs\n",
                _gameOutput.InvalidCoordinateMessage());
        }

        [Fact]
        public void Return_Add_More_Live_Cells_Message()
        {
            Assert.Equal(
                "Would you like to add more live cells? (y/n) or quit the game with 'q': ",
                _gameOutput.AddMoreLiveCellsMessage());
        }

        [Fact]
        public void Return_Invalid_Add_More_Live_Cells_Message()
        {
            Assert.Equal(
                "Please enter a valid input consisting of either 'y' for adding more cells or 'n' for starting game or 'q' for quitting\n",
                _gameOutput.InvalidAddMoreLiveCellsMessage());
        }
        
        [Fact]
        public void Return_Starting_Game_Of_Life_Message()
        {
            Assert.Equal(
                "It's now time to start the game of life!\n",
                _gameOutput.StartingGameOfLifeMessage());
        }
        
        [Fact]
        public void Return_Next_Generation_Grid_Message()
        {
            var grid = new[,]
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

            var expectedMessage = "Here's the next generation:\n" + PrintGrid(grid);
            Assert.Equal(expectedMessage, _gameOutput.PrintNextGenerationGridMessage(grid));
        }

        private string PrintGrid(char[,] initialGrid)
        {
            var output = new List<string>();
            var line = string.Empty;
            for (var i = 0; i < initialGrid.GetLength(0); i++)
            {
                for (var j = 0; j < initialGrid.GetLength(1); j++)
                {
                    line += initialGrid[i, j] + " ";
                }

                output.Add(line);
                line = string.Empty;
            }

            return string.Join("\n", output) + "\n";
        }
    }
}