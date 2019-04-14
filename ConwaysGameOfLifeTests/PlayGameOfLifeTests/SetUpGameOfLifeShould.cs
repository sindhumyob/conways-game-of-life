using System.Collections.Generic;
using ConwaysGameOfLife.GamePlay;
using ConwaysGameOfLife.GamePlayHelpers;
using ConwaysGameOfLifeTests.Stubs;
using Xunit;

namespace ConwaysGameOfLifeTests.GamePlayTests
{
    public class SetUpGameOfLifeShould
    {
        private readonly SetUpGameOfLife _setUpGameOfLife;
        private readonly GameInput _gameInput;
        private readonly GameOutputter _gameOutputter;

        public SetUpGameOfLifeShould()
        {
            _gameInput = new GameInput();
            _gameOutputter = new GameOutputter();
            var gameGrid = new GameGrid();
            _setUpGameOfLife = new SetUpGameOfLife(_gameInput, _gameOutputter, gameGrid);
        }

        [Fact]
        public void Generate_Output_For_Initial_Grid_Generation_According_To_Player_Input()
        {
            _gameInput.ListOfPlayerInputs = new List<string> {"3", "3"};
            _setUpGameOfLife.SetUpInitialGame();
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
        public void Generate_Output_For_Initial_Seed_Creation_According_To_Player_Input()
        {
            _gameInput.ListOfPlayerInputs = new List<string> {"3", "3", "2", "1"};
            _setUpGameOfLife.SetUpInitialGame();
            _gameOutputter.Output = string.Empty;

            _setUpGameOfLife.SetUpInitialSeed();
            var output = _gameOutputter.Output;

            Assert.Equal(
                "Please enter the x coordinate between 1-3 of the cell in the seed or quit the game with 'q': \n" +
                "Please enter the y coordinate between 1-3 of the cell in the seed or quit the game with 'q': \n" +
                "Perfect, here is the grid:\n" +
                (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                " \n" +
                (char) CellType.Live + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                " \n" +
                (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                " \n\n", output);
        }
    }
}