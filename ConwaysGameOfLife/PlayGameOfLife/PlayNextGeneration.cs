using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GameHelpers.GameConstants;
using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;
using ConwaysGameOfLife.GameOutput.Interfaces;
using ConwaysGameOfLife.NextGenerationCreation;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class PlayNextGeneration
    {
        private readonly NextGeneration _nextGeneration;
        private readonly PlayerInput _playerInput;
        private readonly IGameOutput _gameOutput;

        public PlayNextGeneration(IGameInput gameInput, IGameOutput gameOutput)
        {
            _nextGeneration = new NextGeneration();
            _playerInput = new PlayerInput(gameInput, gameOutput);
            _gameOutput = gameOutput;
        }

        public bool SeeGenerationStatus(GameGrid gameGrid)
        {
            _nextGeneration.CreateGeneration(gameGrid);
            _gameOutput.Output(OutputMessages.PrintNextGeneration + gameGrid.ConvertGridToOutput());

            var seeMoreGenerations =
                _playerInput.GetContinueGameInput(OutputMessages.PrintSeeNextGeneration,
                    OutputMessages.InvalidSeeMoreGenerations);

            return seeMoreGenerations == ContinueGameInputConstants.Quit ||
                   seeMoreGenerations == ContinueGameInputConstants.No;
        }
    }
}