using System.Collections.Generic;
using ConwaysGameOfLife.PlayGameOfLife;
using ConwaysGameOfLifeTests.Stubs;
using Xunit;
using static ConwaysGameOfLife.GameHelpers.CellType;

namespace ConwaysGameOfLifeTests.PlayGameOfLifeTests
{
    public class GamePlayerShould
    {
        private readonly GameInput _gameInput;
        private readonly GameOutput _gameOutput;
        private readonly GamePlayer _gamePlayer;

        public GamePlayerShould()
        {
            _gameInput = new GameInput();
            _gameOutput = new GameOutput();
            _gamePlayer = new GamePlayer(_gameInput, _gameOutput);
        }

        [Fact]
        public void Generate_Output_For_GridGeneration_According_To_PlayerInput()
        {
            _gameInput.PlayerInputs = new List<string> {"3", "3"};
            _gamePlayer.GenerateGrid();
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
        public void Generate_Output_For_SeedGeneration_According_To_PlayerInput()
        {
            _gameInput.PlayerInputs = new List<string> {"3", "3", "2", "1", "n"};
            _gamePlayer.GenerateGrid();
            _gameOutput.Message = string.Empty;

            _gamePlayer.GenerateSeed();
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
                "Would you like to add another live cell? 'y' or start the game with 'n' or quit the game with 'q': \n",
                output);
        }

        [Fact]
        public void Generate_Output_For_NextGeneration_According_To_PlayerInput()
        {
            _gameInput.PlayerInputs = new List<string> {"3", "3", "2", "3", "n", "n"};
            _gamePlayer.GenerateGrid();
            _gamePlayer.GenerateSeed();
            _gameOutput.Message = string.Empty;
            
            _gamePlayer.PlayNextGeneration();
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
        public void Generate_Output_For_EntirePlayGameScenario()
        {
            _gameInput.PlayerInputs = new List<string> {"3", "3", "2", "3", "y", "3", "3", "n", "y", "n"};
            _gamePlayer.Play();
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
                         "Would you like to add another live cell? 'y' or start the game with 'n' or quit the game with 'q': \n" +
                         "Please enter the X coordinate of the cell in the seed between 1 and max grid height or quit the game with 'q': \n" +
                         "Please enter the Y coordinate of the cell in the seed between 1 and max grid width or quit the game with 'q': \n" +
                         "Perfect, here is the grid:\n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Dead +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Live +
                         " \n" +
                         (char) Dead + " " + (char) Dead + " " + (char) Live +
                         " \n\n" +
                         "Would you like to add another live cell? 'y' or start the game with 'n' or quit the game with 'q': \n" +
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