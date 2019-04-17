using ConwaysGameOfLife.GameHelpers;
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
        private readonly GameOutputMessages _gameOutputMessages;
        private readonly PlayerInput _playerInput;
        private readonly IGameOutput _gameOutput;

        public PlayNextGeneration(IGameInput gameInput, IGameOutput gameOutput)
        {
            _nextGenerationCreator = new NextGenerationCreator();
            _gameOutputMessages = new GameOutputMessages();
            _playerInput = new PlayerInput(gameInput, gameOutput);
            _gameOutput = gameOutput;
        }

        public bool NextGeneration(GameGrid gameGrid)
        {
            _nextGenerationCreator.CreateNextGeneration(gameGrid);
            _gameOutput.OutputGame(_gameOutputMessages.PrintNextGenerationGridMessage(gameGrid.CurrentGameGrid));

            var seeMoreTransitions =
                _playerInput.GetPlayerContinueGameInput(_gameOutputMessages.PrintSeeNextGenerationMessage(),
                    _gameOutputMessages.InvalidSeeMoreGenerationsMessage());
            return seeMoreTransitions == GameConstants.QuitInput || seeMoreTransitions == GameConstants.NoInput;
        }
    }
}