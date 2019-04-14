using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;
using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLife.GamePlay
{
    public class PlayNextGeneration
    {
        private readonly NextGeneration _nextGeneration;
        private readonly GameOutputMessages _gameOutputMessages;
        private readonly PlayerInputGetter _playerInputGetter;
        private readonly IGameOutput _gameOutput;
        private readonly InputValidator _inputValidator;

        public PlayNextGeneration(IGameInput gameInput, IGameOutput gameOutput)
        {
            _nextGeneration = new NextGeneration();
            _gameOutputMessages = new GameOutputMessages();
            _inputValidator = new InputValidator();
            _playerInputGetter = new PlayerInputGetter(gameInput, gameOutput);
            _gameOutput = gameOutput;

        }

        public bool PlayGame(GameGrid gameGrid)
        {
            _nextGeneration.GetNextGeneration(gameGrid);
            _gameOutput.OutputGame(_gameOutputMessages.PrintNextGenerationGridMessage(gameGrid.CurrentGameGrid));

            var seeMoreTransitions =
                _playerInputGetter.GetPlayerInput(_gameOutputMessages.PrintSeeNextGenerationMessage(),
                    _gameOutputMessages.InvalidSeeMoreGenerationsMessage(),
                    _inputValidator.IsContinueGameResponseValid);
            return seeMoreTransitions == "q" || seeMoreTransitions == "n";
        }
    }
}