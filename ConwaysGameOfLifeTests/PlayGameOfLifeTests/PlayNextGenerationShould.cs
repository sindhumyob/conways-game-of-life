using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.PlayGameOfLife;
using ConwaysGameOfLifeTests.Stubs;
using Xunit;

namespace ConwaysGameOfLifeTests.PlayGameOfLifeTests
{
    public class PlayNextGenerationShould
    {
        private readonly GameInput _gameInput;
        private readonly GameOutput _gameOutput;
        private readonly GameGrid _gameGrid;
        private readonly PlayNextGeneration _playNextGeneration;

        public PlayNextGenerationShould()
        {
            _gameInput = new GameInput();
            _gameOutput = new GameOutput();
            _gameGrid = new GameGrid();
            _playNextGeneration = new PlayNextGeneration(_gameInput, _gameOutput);
        }

        [Fact]
        public void Generate_Output_For_Next_Generation_According_To_Player_Input()
        {
            _gameGrid.CurrentGameGrid = new[,]
            {
                {
                    CellType.Dead, CellType.Dead, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Live, CellType.Dead
                },
                {
                    CellType.Dead, CellType.Dead, CellType.Dead
                }
            };
            _gameInput.PlayerInputs = new List<string> {"n"};

            _playNextGeneration.IsSeeGenerationInterrupted(_gameGrid);
            var output = _gameOutput.OutputMessage;

            Assert.Equal("Here's the next generation:\n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n\n" +
                         "Would you like to see the next generation? 'y' or quit the game with 'n' or 'q': \n", output);
        }
    }
}