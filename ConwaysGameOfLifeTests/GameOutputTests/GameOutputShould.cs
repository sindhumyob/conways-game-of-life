using System.Collections.Generic;
using ConwaysGameOfLife;
using ConwaysGameOfLife.GameOutput;
using ConwaysGameOfLife.GamePlayHelpers;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class GameOutputShould
    {
        private readonly GameOutputMessages _gameOutputMessages;

        public GameOutputShould()
        {
            _gameOutputMessages = new GameOutputMessages();
        }

        [Fact]
        public void Return_Game_Welcome_Message()
        {
            Assert.Equal("Welcome to Conway's Game of Life!\n", _gameOutputMessages.WelcomeMessage());
        }

        [Fact]
        public void Return_Enter_Grid_Height_Message()
        {
            Assert.Equal("Please enter the height of your game grid or quit the game with 'q': ",
                _gameOutputMessages.EnterGridHeightMessage());
        }

        [Fact]
        public void Return_Enter_Grid_Width_Message()
        {
            Assert.Equal("Please enter the width of your game grid or quit the game with 'q': ",
                _gameOutputMessages.EnterGridWidthMessage());
        }

        [Fact]
        public void Return_Invalid_Grid_Size_Message()
        {
            Assert.Equal("Please enter a valid grid size input consisting of a single positive whole number\n",
                _gameOutputMessages.InvalidGridSizeMessage());
        }

        [Fact]
        public void Return_Current_Grid_During_Player_Input_Message()
        {
            var initialGrid = new[,]
            {
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
            };

            var expectedMessage = "Perfect, here is the grid:\n" +
                                  (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                                  " \n" +
                                  (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                                  " \n" +
                                  (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                                  " \n";
            Assert.Equal(expectedMessage, _gameOutputMessages.PrintGridMessage(initialGrid));
        }

        [Fact]
        public void Return_Adding_Initial_Seed_Message()
        {
            Assert.Equal("It's now time to add the seed of the system:\n", _gameOutputMessages.AddInitialSeedMessage());
        }

        [Fact]
        public void Return_Enter_X_Coordinate_Of_Cell_In_Seed_Message()
        {
            var maxSizeOfCoordinate = 15;
            Assert.Equal(
                "Please enter the x coordinate between 1-15 of the cell in the seed or quit the game with 'q': ",
                _gameOutputMessages.EnterXCoordinateOfCellMessage(maxSizeOfCoordinate));
        }

        [Fact]
        public void Return_Enter_Y_Coordinate_Of_Cell_In_Seed_Message()
        {
            var maxSizeOfCoordinate = 20;
            Assert.Equal(
                "Please enter the y coordinate between 1-20 of the cell in the seed or quit the game with 'q': ",
                _gameOutputMessages.EnterYCoordinateOfCellMessage(maxSizeOfCoordinate));
        }

        [Fact]
        public void Return_Invalid_Coordinate_Message()
        {
            var heightOfBoard = 20;
            Assert.Equal(
                "Please enter valid coordinate inputs\n",
                _gameOutputMessages.InvalidCoordinateMessage());
        }

        [Fact]
        public void Return_Add_More_Live_Cells_Message()
        {
            Assert.Equal(
                "Would you like to add more live cells? (y/n) or quit the game with 'q': ",
                _gameOutputMessages.AddMoreLiveCellsMessage());
        }

        [Fact]
        public void Return_Invalid_Add_More_Live_Cells_Message()
        {
            Assert.Equal(
                "Please enter a valid input consisting of either 'y' for adding more cells or 'n' for starting game or 'q' for quitting\n",
                _gameOutputMessages.InvalidAddMoreLiveCellsMessage());
        }

        [Fact]
        public void Return_Starting_Game_Of_Life_Message()
        {
            Assert.Equal(
                "It's now time to start the game of life!\n",
                _gameOutputMessages.StartingGameOfLifeMessage());
        }

        [Fact]
        public void Return_Invalid_See_More_Generations_Message()
        {
            Assert.Equal(
                "Please enter a valid input consisting of either 'y' for seeing more generations or 'n' or 'q' for quitting\n",
                _gameOutputMessages.InvalidSeeMoreGenerationsMessage());
        }

        [Fact]
        public void Return_End_Game_Message()
        {
            Assert.Equal(
                "Thanks for Playing!",
                _gameOutputMessages.PrintEndGameMessage());
        }

        [Fact]
        public void Return_See_Next_Generations_Message()
        {
            Assert.Equal(
                "Would you like to see the next generation? (y/n) or quit the game with 'q': ",
                _gameOutputMessages.PrintSeeNextGenerationMessage());
        }

        [Fact]
        public void Return_Next_Generation_Grid_Message()
        {
            var grid = new[,]
            {
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live
                },
                {
                    (char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead
                },
            };

            var expectedMessage = "Here's the next generation:\n" +
                                  (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                                  " \n" +
                                  (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Live +
                                  " \n" +
                                  (char) CellType.Dead + " " + (char) CellType.Live + " " + (char) CellType.Dead +
                                  " \n";
            Assert.Equal(expectedMessage, _gameOutputMessages.PrintNextGenerationGridMessage(grid));
        }
    }
}