using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GameHelpers.GameConstants;
using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;
using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class PlayGameOfLife
    {
        private readonly GameGrid _gameGrid;
        private readonly PlayerInput _playerInput;
        private readonly SetUpGameOfLife _setUpGameOfLife;
        private readonly PlayNextGeneration _playNextGeneration;
        private readonly IGameOutput _gameOutput;
        private bool _gameEnd;
        private bool _endOfSeedInput;

        public PlayGameOfLife(IGameInput gameInput, IGameOutput gameOutput)
        {
            _gameGrid = new GameGrid();
            _playerInput = new PlayerInput(gameInput, gameOutput);
            _setUpGameOfLife = new SetUpGameOfLife(gameInput, gameOutput, _gameGrid);
            _playNextGeneration = new PlayNextGeneration(gameInput, gameOutput);
            _gameOutput = gameOutput;
        }

        private void AddMoreSeeds()
        {
            var addMoreSeedsInput =
                _playerInput.GetPlayerContinueGameInput(OutputMessages.AddMoreLiveCells,
                    OutputMessages.InvalidAddMoreLiveCells);
            if (addMoreSeedsInput == ContinueGameInputConstants.QuitInput)
            {
                _gameEnd = true;
            }
            else if (addMoreSeedsInput == ContinueGameInputConstants.NoInput)
            {
                _gameOutput.OutputGame(OutputMessages.StartingGameOfLife);
                _endOfSeedInput = true;
            }
        }

        public void PlayGame()
        {
            _gameOutput.OutputGame(OutputMessages.Welcome);

            _gameEnd = _setUpGameOfLife.SetUpInitialGrid();

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
                _gameEnd = _playNextGeneration.NextGeneration(_gameGrid);
            }

            _gameOutput.OutputGame(OutputMessages.PrintGameEnd);
        }
    }
}