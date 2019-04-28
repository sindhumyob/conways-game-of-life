using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GameHelpers.GameConstants;
using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;
using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class PlayGame
    {
        private readonly GameGrid _gameGrid;
        private readonly PlayerInput _playerInput;
        private readonly SetUpGame _setUpGame;
        private readonly PlayNextGeneration _playNextGeneration;
        private readonly IGameOutput _gameOutput;

        public PlayGame(IGameInput gameInput, IGameOutput gameOutput)
        {
            _gameGrid = new GameGrid();
            _playerInput = new PlayerInput(gameInput, gameOutput);
            _setUpGame = new SetUpGame(gameInput, gameOutput, _gameGrid);
            _playNextGeneration = new PlayNextGeneration(gameInput, gameOutput);
            _gameOutput = gameOutput;
        }

        private (bool, bool) SeedGenerationStatus()
        {
            var gameEnd = false;
            var endOfSeedInput = false;
            var addMoreSeedsInput =
                _playerInput.GetContinueGameInput(OutputMessages.AddMoreLiveCells,
                    OutputMessages.InvalidAddMoreLiveCells);

            if (addMoreSeedsInput == ContinueGameInputConstants.Quit)
            {
                gameEnd = true;
            }
            else if (addMoreSeedsInput == ContinueGameInputConstants.No)
            {
                _gameOutput.Output(OutputMessages.StartingGameOfLife);
                endOfSeedInput = true;
            }

            return (gameEnd, endOfSeedInput);
        }

        public void Play()
        {
            var endOfSeedInput = false;
            _gameOutput.Output(OutputMessages.Welcome);

            var gameEnd = _setUpGame.IsGridGenerationInterrupted();

            while (!endOfSeedInput && !gameEnd)
            {
                gameEnd = _setUpGame.IsAddLiveCellInterrupted();
                if (gameEnd) break;

                (gameEnd, endOfSeedInput) = SeedGenerationStatus();
            }

            while (!gameEnd)
            {
                gameEnd = _playNextGeneration.IsSeeGenerationInterrupted(_gameGrid);
            }

            _gameOutput.Output(OutputMessages.PrintGameEnd);
        }
    }
}