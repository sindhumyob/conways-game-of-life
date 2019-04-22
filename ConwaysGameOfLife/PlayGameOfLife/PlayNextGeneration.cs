using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GameHelpers.GameConstants;
using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;
using ConwaysGameOfLife.GameOutput.Interfaces;
using ConwaysGameOfLife.NextGenerationsCreation;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class PlayNextGeneration
    {
        private readonly NextGenerationCreator _nextGenerationCreator;
        private readonly PlayerInput _playerInput;
        private readonly IGameOutput _gameOutput;

        public PlayNextGeneration(IGameInput gameInput, IGameOutput gameOutput)
        {
            _nextGenerationCreator = new NextGenerationCreator();
            _playerInput = new PlayerInput(gameInput, gameOutput);
            _gameOutput = gameOutput;
        }

        public bool NextGenerationGameStatus(GameGrid gameGrid)
        {
            _nextGenerationCreator.CreateNextGeneration(gameGrid);
            _gameOutput.OutputGame(OutputMessages.PrintNextGeneration + gameGrid.ConvertGridToOutput());

            var seeMoreTransitions =
                _playerInput.GetPlayerContinueGameInput(OutputMessages.PrintSeeNextGeneration,
                    OutputMessages.InvalidSeeMoreGenerations);
            return seeMoreTransitions == ContinueGameInputConstants.QuitInput || seeMoreTransitions == ContinueGameInputConstants.NoInput;
        }
    }
}