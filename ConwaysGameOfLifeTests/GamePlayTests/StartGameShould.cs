using System;
using System.Collections.Generic;
using ConwaysGameOfLife.GamePlay;
using ConwaysGameOfLife.GamePlayHelpers;
using ConwaysGameOfLifeTests.Stubs;
using Xunit;

namespace ConwaysGameOfLifeTests.GamePlayTests
{
    public class StartGameShould
    {
        private readonly StartGameOfLife _startGameOfLife;
        private readonly GameInput _gameInput;
        private readonly GameOutputter _gameOutputter;

        public StartGameShould()
        {
            _gameInput = new GameInput();
            _gameOutputter = new GameOutputter();
            _startGameOfLife = new StartGameOfLife(_gameInput, _gameOutputter);
        }

        [Fact]
        public void Generate_Ouput_For_Initial_Grid_Generation_According_To_Player_Input()
        {
            _gameInput.PlayerInput = new List<string> {"3", "3"};
            _startGameOfLife.InputForInitialGrid();
            var output = _gameOutputter.Output;

            Assert.Equal("Please enter the height of your game grid or quit the game with 'q': \n" +
                         "Please enter the width of your game grid or quit the game with 'q': \n" +
                         "Perfect, here is the grid:\n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n\n" +
                         "It's now time to add the seed of the system:\n\n", output);
        }

        [Fact]
        public void Generate_Ouput_For_Initial_Seed_Creation_According_To_Player_Input()
        {
            _gameInput.PlayerInput = new List<string> {"3", "3", "3", "3"};
            _startGameOfLife.InputForInitialGrid();
            _gameOutputter.Output = String.Empty;

            _startGameOfLife.InputForInitialSeed();
            var output = _gameOutputter.Output;

            Assert.Equal(
                "Please enter the x coordinate between 1-3 of the cell in the seed or quit the game with 'q': \n" +
                "Please enter the y coordinate between 1-3 of the cell in the seed or quit the game with 'q': \n" +
                "Perfect, here is the grid:\n" +
                (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                " \n" +
                (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                " \n" +
                (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Live +
                " \n\n", output);
        }

        [Fact]
        public void Generate_Output_When_More_Cells_Are_Added_To_Initial_Seed_According_To_Player_Input()
        {
            _gameInput.PlayerInput = new List<string> {"3", "3", "3", "3", "y", "2", "2", "n"};
            _startGameOfLife.InputForInitialGrid();
            _startGameOfLife.InputForInitialSeed();
            _gameOutputter.Output = String.Empty;


            _startGameOfLife.InputForAddMoreSeeds();
            _startGameOfLife.InputForInitialSeed();
            _startGameOfLife.InputForAddMoreSeeds();
            var output = _gameOutputter.Output;

            Assert.Equal("Would you like to add more live cells? (y/n) or quit the game with 'q': \n" +
                         "Please enter the x coordinate between 1-3 of the cell in the seed or quit the game with 'q': \n" +
                         "Please enter the y coordinate between 1-3 of the cell in the seed or quit the game with 'q': \n" +
                         "Perfect, here is the grid:\n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Live + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Live +
                         " \n\n" +
                         "Would you like to add more live cells? (y/n) or quit the game with 'q': \n", output);
        }

        [Fact]
        public void Generate_Ouput_For_Play_Game_According_To_Player_Input()
        {
            _gameInput.PlayerInput = new List<string> {"3", "3", "2", "3", "n"};
            _startGameOfLife.InputForInitialGrid();
            _startGameOfLife.InputForInitialSeed();

            _gameOutputter.Output = String.Empty;
            _startGameOfLife.PlayGame();

            var output = _gameOutputter.Output;

            Assert.Equal("Here's the next generation:\n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n\n" +
                         "Would you like to see the next generation? (y/n) or quit the game with 'q': \n" +
                         "Thanks for Playing!\n", output);
        }
    }
}