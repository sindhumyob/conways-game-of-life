using System.Collections.Generic;
using ConwaysGameOfLife.PlayGameOfLife;
using ConwaysGameOfLifeTests.Stubs;
using Xunit;
using static ConwaysGameOfLife.GameHelpers.CellType;

namespace ConwaysGameOfLifeTests.PlayGameOfLifeTests
{
    public class PlayGameShould
    {
        private readonly GameInput _gameInput;
        private readonly GameOutput _gameOutput;
        private readonly PlayGame _playGame;

        public PlayGameShould()
        {
            _gameInput = new GameInput();
            _gameOutput = new GameOutput();
            _playGame = new PlayGame(_gameInput, _gameOutput);
        }

        [Fact]
        public void Generate_Output_For_Initial_Grid_Generation_According_To_Player_Input()
        {
            _gameInput.PlayerInputs = new List<string> {"3", "3"};
            _playGame.GenerateGrid();
            var output = _gameOutput.Message;

            Assert.Equal("Please enter the height of your game grid or quit the game with 'q': \n" +
                         "Please enter the width of your game grid or quit the game with 'q': \n" +
                         "Perfect, here is the grid:\n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n\n" +
                         "It's now time to add the seed of the system:\n\n", output);
        }

        [Fact]
        public void Generate_Output_For_Initial_Seed_Creation_According_To_Player_Input()
        {
            _gameInput.PlayerInputs = new List<string> {"3", "3", "2", "1", "n"};
            _playGame.GenerateGrid();
            _gameOutput.Message = string.Empty;

            _playGame.GenerateSeed();
            var output = _gameOutput.Message;

            Assert.Equal(
                "Please enter the X coordinate of the cell in the seed between 1 and max grid height or quit the game with 'q': \n" +
                "Please enter the Y coordinate of the cell in the seed between 1 and max grid width or quit the game with 'q': \n" +
                "Perfect, here is the grid:\n" +
                (char) Dead + " " + (char) Dead + " " + (char) Dead +
                " \n" +
                (char) Live + " " + (char) Dead + " " + (char) Dead +
                " \n" +
                (char) Dead + " " + (char) Dead + " " + (char) Dead +
                " \n\n" +
                "Would you like to add more live cells? (y/n) or quit the game with 'q': \n" +
                "It's now time to start the game of life!\n\n", output);
        }

        [Fact]
        public void Generate_Output_For_Next_Generation_According_To_Player_Input()
        {
            _playGame.GameGrid.CurrentGameGrid = new[,]
            {
                {
                    Dead, Dead, Dead
                },
                {
                    Dead, Live, Dead
                },
                {
                    Dead, Dead, Dead
                }
            };
            _gameInput.PlayerInputs = new List<string> {"n"};

            _playGame.PlayNextGeneration();
            var output = _gameOutput.Message;

            Assert.Equal("Here's the next generation:\n" +
                         
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n\n" +
                         "Would you like to see the next generation? 'y' or quit the game with 'n' or 'q': \n", output);
        }

        [Fact]
        public void Generate_Output_For_Entire_Play_Game_Scenario()
        {
            _gameInput.PlayerInputs = new List<string> {"3", "3", "2", "3", "y", "3", "3", "n", "y", "n"};
            _playGame.Play();
            var output = _gameOutput.Message;

            Assert.Equal("Welcome to Conway's Game of Life!\n\n" +
                         "Please enter the height of your game grid or quit the game with 'q': \n" +
                         "Please enter the width of your game grid or quit the game with 'q': \n" +
                         "Perfect, here is the grid:\n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n\n" +
                         "It's now time to add the seed of the system:\n\n" +
                         "Please enter the X coordinate of the cell in the seed between 1 and max grid height or quit the game with 'q': \n" +
                         "Please enter the Y coordinate of the cell in the seed between 1 and max grid width or quit the game with 'q': \n" +
                         "Perfect, here is the grid:\n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Live +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n\n" +
                         "Would you like to add more live cells? (y/n) or quit the game with 'q': \n" +
                         "Please enter the X coordinate of the cell in the seed between 1 and max grid height or quit the game with 'q': \n" +
                         "Please enter the Y coordinate of the cell in the seed between 1 and max grid width or quit the game with 'q': \n" +
                         "Perfect, here is the grid:\n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Live +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Live +
                         " \n\n" +
                         "Would you like to add more live cells? (y/n) or quit the game with 'q': \n" +
                         "It's now time to start the game of life!\n\n" +
                         "Here's the next generation:\n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n\n" +
                         "Would you like to see the next generation? 'y' or quit the game with 'n' or 'q': \n" +
                         "Here's the next generation:\n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n\n" +
                         "Would you like to see the next generation? 'y' or quit the game with 'n' or 'q': \n" +
                         "Thanks for Playing!\n", output);
        }
    }
}