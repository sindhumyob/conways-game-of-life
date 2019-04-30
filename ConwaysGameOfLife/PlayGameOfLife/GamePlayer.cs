using ConwaysGameOfLife.GameHelpers.GameConstants.InputConstants;
using ConwaysGameOfLife.GameHelpers.GameConstants.OutputConstants;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput.Interfaces;
using ConwaysGameOfLife.NextGenerationCreation;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class GamePlayer
    {
        private readonly GameGrid _gameGrid;
        private readonly GridMaker _gridMaker;
        private readonly PlayerInput _playerInput;
        private readonly IGameOutput _gameOutput;
        private readonly NextGeneration _nextGeneration;
        private bool _gameEnd;


        public GamePlayer(IGameInput gameInput, IGameOutput gameOutput)
        {
            _gameGrid = new GameGrid();
            _gridMaker = new GridMaker(gameInput, gameOutput, _gameGrid);
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
            _gameOutput.Output(Messages.SeeGrid + _gameGrid.ConvertGridToOutput());
            _gameOutput.Output(Messages.AddInitialSeed);
        }

        public void GenerateSeed()
        {
            var endOfSeeding = false;
            while (!endOfSeeding && !_gameEnd)
            {
                _gameEnd = _gridMaker.IsAddLiveCellInterrupted();
                if (_gameEnd) return;

                _gameOutput.Output(Messages.SeeGrid + _gameGrid.ConvertGridToOutput());

                var seedingStatus = _gridMaker.SeedGenerationStatus();
                _gameEnd = seedingStatus.GameEnd;
                endOfSeeding = seedingStatus.EndOfSeeding;
            }
        }

        public void PlayNextGeneration()
        {
            while (!_gameEnd)
            {
                _nextGeneration.CreateGeneration(_gameGrid);
                _gameOutput.Output(Messages.NextGeneration + _gameGrid.ConvertGridToOutput());

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