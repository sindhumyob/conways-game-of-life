using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;
using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLife.GamePlay
{
    public class PlayGameOfLife
    {
        private readonly GameGrid _gameGrid;
        private readonly PlayNextGeneration _playNextGeneration;
        private readonly IGameOutput _gameOutput;
        private readonly GameOutputMessages _gameOutputMessages;
        private readonly PlayerInputGetter _playerInputGetter;
        private readonly InputValidator _inputValidator;
        private readonly SetUpGameOfLife _setUpGameOfLife;
        private bool _gameEnd;
        private bool _endOfSeedInput;

        public PlayGameOfLife(IGameInput gameInput, IGameOutput gameOutput)
        {
            
            _gameGrid = new GameGrid();
            _gameOutput = gameOutput;
            _gameOutputMessages = new GameOutputMessages();
            _playerInputGetter = new PlayerInputGetter(gameInput, gameOutput);
            _inputValidator = new InputValidator();
            _setUpGameOfLife = new SetUpGameOfLife(gameInput, gameOutput, _gameGrid);
            _playNextGeneration = new PlayNextGeneration(gameInput,gameOutput);
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
                _gameOutput.OutputGame(_gameOutputMessages.StartingGameOfLifeMessage());
                _endOfSeedInput = true;
            }
        }

        public void StartGame()
        {
            _gameOutput.OutputGame(_gameOutputMessages.WelcomeMessage());
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
                _gameEnd = _playNextGeneration.PlayGame(_gameGrid);
            }

            _gameOutput.OutputGame(_gameOutputMessages.PrintGameEndMessage());
        }
    }
}