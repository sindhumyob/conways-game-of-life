using ConwaysGameOfLife.GameHelpers.GameConstants.InputConstants;
using ConwaysGameOfLife.GameHelpers.GameConstants.OutputConstants;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput.Interfaces;
using ConwaysGameOfLife.NextGenerationCreation;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class GamePlayer
    {
        public readonly GameGrid GameGrid;
        private readonly GridMaker _gridMaker;
        private readonly PlayerInput _playerInput;
        private readonly IGameOutput _gameOutput;
        private readonly NextGeneration _nextGeneration;
        private bool _gameEnd;


        public GamePlayer(IGameInput gameInput, IGameOutput gameOutput)
        {
            GameGrid = new GameGrid();
            _gridMaker = new GridMaker(gameInput, gameOutput, GameGrid);
            _playerInput = new PlayerInput(gameInput, gameOutput);
            _gameOutput = gameOutput;
            _nextGeneration = new NextGeneration();
        }

        public void Play()
        {
            _gameOutput.Output(Messages.Welcome);

            GenerateGrid();
            GenerateSeed();
            PlayNextGeneration();

            _gameOutput.Output(Messages.GameEnd);
        }

        public void GenerateGrid()
        {
            _gameEnd = _gridMaker.IsGenerationInterrupted();

            if (_gameEnd) return;
            _gameOutput.Output(Messages.SeeGrid + GameGrid.ConvertGridToOutput());
            _gameOutput.Output(Messages.AddInitialSeed);
        }

        public void GenerateSeed()
        {
            var endOfSeedInput = false;
            while (!endOfSeedInput && !_gameEnd)
            {
                _gameEnd = _gridMaker.IsAddLiveCellInterrupted();
                if (_gameEnd) return;

                _gameOutput.Output(Messages.SeeGrid + GameGrid.ConvertGridToOutput());

                var seedingStatus = _gridMaker.SeedGenerationStatus();
                _gameEnd = seedingStatus.GameEnd;
                endOfSeedInput = seedingStatus.EndOfSeedInput;
            }
        }

        public void PlayNextGeneration()
        {
            while (!_gameEnd)
            {
                _nextGeneration.CreateGeneration(GameGrid);
                _gameOutput.Output(Messages.NextGeneration + GameGrid.ConvertGridToOutput());

                var seeNextGeneration = _playerInput.ContinueGame(Messages.SeeNextGeneration,
                    Messages.InvalidSeeNextGeneration);

                if (seeNextGeneration == ContinueGameConstants.Quit || seeNextGeneration == ContinueGameConstants.No)
                {
                    _gameEnd = true;
                }
            }
        }
    }
}