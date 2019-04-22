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

        public PlayGameOfLife(IGameInput gameInput, IGameOutput gameOutput)
        {
            _gameGrid = new GameGrid();
            _playerInput = new PlayerInput(gameInput, gameOutput);
            _setUpGameOfLife = new SetUpGameOfLife(gameInput, gameOutput, _gameGrid);
            _playNextGeneration = new PlayNextGeneration(gameInput, gameOutput);
            _gameOutput = gameOutput;
        }

        private (bool,bool) AddMoreLiveCellsGameStatus()
        {
            var gameEnd = false;
            var endOfSeedInput = false;
            var addMoreSeedsInput =
                _playerInput.GetPlayerContinueGameInput(OutputMessages.AddMoreLiveCells,
                    OutputMessages.InvalidAddMoreLiveCells);
            
            if (addMoreSeedsInput == ContinueGameInputConstants.QuitInput)
            {
                gameEnd = true;
            }
            else if (addMoreSeedsInput == ContinueGameInputConstants.NoInput)
            {
                _gameOutput.OutputGame(OutputMessages.StartingGameOfLife);
                endOfSeedInput = true;
            }

            return (gameEnd, endOfSeedInput);
        }

        public void PlayGame()
        {
            var endOfSeedInput = false;
            _gameOutput.OutputGame(OutputMessages.Welcome);

            var gameEnd = _setUpGameOfLife.SetUpInitialGridGameStatus();

            while (!endOfSeedInput && !gameEnd)
            {
                gameEnd = _setUpGameOfLife.SetUpInitialSeedGameStatus();
                if (gameEnd) continue;

                (gameEnd, endOfSeedInput) = AddMoreLiveCellsGameStatus();
            }

            while (!gameEnd)
            {
                gameEnd = _playNextGeneration.NextGenerationGameStatus(_gameGrid);
            }

            _gameOutput.OutputGame(OutputMessages.PrintGameEnd);
        }
    }
}