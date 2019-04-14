using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GamePlay;
using ConwaysGameOfLifeTests.Stubs;
using Xunit;

namespace ConwaysGameOfLifeTests.PlayGameOfLifeTests
{
    public class PlayNextGenerationShould
    {
        private readonly PlayNextGeneration _playNextGeneration;
        private readonly GameInput _gameInput;
        private readonly GameOutputter _gameOutputter;
        private readonly GameGrid _gameGrid;

        public PlayNextGenerationShould()
        {
            _gameInput = new GameInput();
            _gameOutputter = new GameOutputter();
            _gameGrid = new GameGrid();
            _playNextGeneration = new PlayNextGeneration(_gameInput, _gameOutputter);
        }


        [Fact]
        public void Generate_Output_For_Next_Generation_According_To_Player_Input()
        {
            _gameGrid.CurrentGameGrid = new[,]
            {
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead
                },
                {
                    (char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead
                }
            };
            _gameInput.PlayerInputs = new List<string> {"n"};

            _playNextGeneration.PlayGame(_gameGrid);
            var output = _gameOutputter.Output;

            Assert.Equal("Here's the next generation:\n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n" +
                         (char) CellType.Dead + " " + (char) CellType.Dead + " " + (char) CellType.Dead +
                         " \n\n" +
                         "Would you like to see the next generation? (y/n) or quit the game with 'q': \n", output);
        }

    }
}