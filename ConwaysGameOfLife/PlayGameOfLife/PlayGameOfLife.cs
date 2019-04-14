using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;

namespace ConwaysGameOfLife.GamePlay
{
    public class PlayGameOfLife
    {
        private readonly NextGeneration _nextGeneration;

        private readonly GameGrid _gameGrid;

        private readonly IGameOutput _gameOutput;
        private readonly GameOutputMessages _gameOutputMessages;
        private readonly PlayerInputGetter _playerInputGetter;
        private readonly InputValidator _inputValidator;
        private readonly SetUpGameOfLife _setUpGameOfLife;
        private bool _gameEnd;
        private bool _endOfSeedInput;

        public PlayGameOfLife(IGameInput gameInput, IGameOutput gameOutput)
        {
            _nextGeneration = new NextGeneration();
            _gameGrid = new GameGrid();
            _gameOutput = gameOutput;
            _gameOutputMessages = new GameOutputMessages();
            _playerInputGetter = new PlayerInputGetter(gameInput, gameOutput);
            _inputValidator = new InputValidator();
            _setUpGameOfLife = new SetUpGameOfLife(gameInput, gameOutput, _gameGrid);
        }

        private void AddMoreSeeds()
        {
            var addMoreSeedsInput =
                _playerInputGetter.GetPlayerInput(_gameOutputMessages.AddMoreLiveCellsMessage(),
                    _gameOutputMessages.InvalidAddMoreLiveCellsMessage(),
                    _inputValidator.IsContinueGameResponseValid);
            if (addMoreSeedsInput == "q")
            {
                _gameEnd = true;
            }
            else if (addMoreSeedsInput == "n")
            {
                _gameOutput.GameOutput(_gameOutputMessages.StartingGameOfLifeMessage());
                _endOfSeedInput = true;
            }
        }

        private void PlayGame()
        {
            _nextGeneration.GetNextGeneration(_gameGrid);
            _gameOutput.GameOutput(_gameOutputMessages.PrintNextGenerationGridMessage(_gameGrid.CurrentGameGrid));

            var seeMoreTransitions =
                _playerInputGetter.GetPlayerInput(_gameOutputMessages.PrintSeeNextGenerationMessage(),
                    _gameOutputMessages.InvalidSeeMoreGenerationsMessage(),
                    _inputValidator.IsContinueGameResponseValid);
            if (seeMoreTransitions == "q" || seeMoreTransitions == "n")
            {
                _gameEnd = true;
            }
        }

        public void StartGame()
        {
            _gameOutput.GameOutput(_gameOutputMessages.WelcomeMessage());
            if (!_gameEnd)
            {
                _gameEnd = _setUpGameOfLife.SetUpInitialGame();
            }

            while (!_endOfSeedInput && !_gameEnd)
            {
                _gameEnd = _setUpGameOfLife.SetUpInitialSeed();
                if (!_gameEnd)
                {
                    AddMoreSeeds();
                }
            }

            while (!_gameEnd && _endOfSeedInput)
            {
                PlayGame();
            }

            _gameOutput.GameOutput(_gameOutputMessages.PrintEndGameMessage());
        }
    }
}