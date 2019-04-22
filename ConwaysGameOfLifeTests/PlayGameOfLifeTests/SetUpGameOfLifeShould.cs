using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.PlayGameOfLife;
using ConwaysGameOfLifeTests.Stubs;
using Xunit;

namespace ConwaysGameOfLifeTests.PlayGameOfLifeTests
{
    public class SetUpGameOfLifeShould
    {
        private readonly GameInput _gameInput;
        private readonly GameOutput _gameOutput;
        private readonly SetUpGameOfLife _setUpGameOfLife;

        public SetUpGameOfLifeShould()
        {
            _gameInput = new GameInput();
            _gameOutput = new GameOutput();
            var gameGrid = new GameGrid();
            _setUpGameOfLife = new SetUpGameOfLife(_gameInput, _gameOutput, gameGrid);
        }

        [Fact]
        public void Generate_Output_For_Initial_Grid_Generation_According_To_Player_Input()
        {
            _gameInput.PlayerInputs = new List<string> {"3", "3"};
            _setUpGameOfLife.InitialGridGameStatus();
            var output = _gameOutput.Output;

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
            _gameInput.PlayerInputs = new List<string> {"3", "3", "2", "1"};
            _setUpGameOfLife.InitialGridGameStatus();
            _gameOutput.Output = string.Empty;

            _setUpGameOfLife.InitialSeedGameStatus();
            var output = _gameOutput.Output;

            Assert.Equal(
                "Please enter the X coordinate of the cell in the seed between 1 and max grid height or quit the game with 'q': \n" +
                "Please enter the Y coordinate of the cell in the seed between 1 and max grid width or quit the game with 'q': \n" +
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