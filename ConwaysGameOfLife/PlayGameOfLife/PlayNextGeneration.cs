using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;
using ConwaysGameOfLife.GameOutput.Interfaces;
using ConwaysGameOfLife.NextGenerationsCreation;
using ConwaysGameOfLife.PlayGameOfLife;

namespace ConwaysGameOfLife.GamePlay
{
    public class PlayNextGeneration
    {
        private readonly NextGenerationCreator _nextGenerationCreator;
        private readonly GameOutputMessages _gameOutputMessages;
        private readonly PlayerInputGetter _playerInputGetter;
        private readonly IGameOutput _gameOutput;
        private readonly GameInputValidator _gameInputValidator;

        public PlayNextGeneration(IGameInput gameInput, IGameOutput gameOutput)
        {
            _nextGenerationCreator = new NextGenerationCreator();
            _gameOutputMessages = new GameOutputMessages();
            _gameInputValidator = new GameInputValidator();
            _playerInputGetter = new PlayerInputGetter(gameInput, gameOutput);
            _gameOutput = gameOutput;

        }

        public bool PlayGame(GameGrid gameGrid)
        {
            _nextGenerationCreator.CreateNextGeneration(gameGrid);
            _gameOutput.OutputGame(_gameOutputMessages.PrintNextGenerationGridMessage(gameGrid.CurrentGameGrid));

            var seeMoreTransitions =
                _playerInputGetter.GetPlayerInput(_gameOutputMessages.PrintSeeNextGenerationMessage(),
                    _gameOutputMessages.InvalidSeeMoreGenerationsMessage(),
                    _gameInputValidator.IsContinueGameResponseValid);
            return seeMoreTransitions == "q" || seeMoreTransitions == "n";
        }
    }
}