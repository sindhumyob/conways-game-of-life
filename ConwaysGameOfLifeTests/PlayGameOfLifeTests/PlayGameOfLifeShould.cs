using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GamePlay;
using ConwaysGameOfLifeTests.Stubs;
using Xunit;

namespace ConwaysGameOfLifeTests.PlayGameOfLifeTests
{
    public class PlayGameOfLifeShould
    {
        private readonly GameInput _gameInput;
        private readonly GameOutput _gameOutput;
        private readonly PlayGameOfLife _playGameOfLife;

        public PlayGameOfLifeShould()
        {
            _gameInput = new GameInput();
            _gameOutput = new GameOutput();
            _playGameOfLife = new PlayGameOfLife(_gameInput,_gameOutput);
        }
        [Fact]
        public void Generate_Output_For_Entire_Start_Game()
        {
            _gameInput.PlayerInputs = new List<string> {"3", "3", "2", "3", "y", "3", "3", "n", "y", "n"};
            _playGameOfLife.StartGame();
            var output = _gameOutput.Output;

            Assert.Equal("Welcome to Conway's Game of Life!\n\n" +
                         "Please enter the height of your game grid or quit the game with 'q': \n" +
                         "Please enter the width of your game grid or quit the game with 'q': \n" +
                         "Perfect, here is the grid:\n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n\n" +
                         "It's now time to add the seed of the system:\n\n" +
                         "Please enter the x coordinate between 1-3 of the cell in the seed or quit the game with 'q': \n" +
                         "Please enter the y coordinate between 1-3 of the cell in the seed or quit the game with 'q': \n" +
                         "Perfect, here is the grid:\n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Live +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n\n" +
                         "Would you like to add more live cells? (y/n) or quit the game with 'q': \n" +
                         "Please enter the x coordinate between 1-3 of the cell in the seed or quit the game with 'q': \n" +
                         "Please enter the y coordinate between 1-3 of the cell in the seed or quit the game with 'q': \n" +
                         "Perfect, here is the grid:\n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Live +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Live +
                         " \n\n" +
                         "Would you like to add more live cells? (y/n) or quit the game with 'q': \n" +
                         "It's now time to start the game of life!\n\n" +
                         "Here's the next generation:\n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n\n" +
                         "Would you like to see the next generation? 'y' or quit the game with 'n' or 'q': \n" +
                         "Here's the next generation:\n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n\n" +
                         "Would you like to see the next generation? 'y' or quit the game with 'n' or 'q': \n" +
                         "Thanks for Playing!\n", output);
        }
    }
}