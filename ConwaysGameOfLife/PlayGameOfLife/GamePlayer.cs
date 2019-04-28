using ConwaysGameOfLife.GameHelpers.GameConstants;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput.Interfaces;
using ConwaysGameOfLife.NextGenerationCreation;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class GamePlayer
    {
        public readonly GameGrid GameGrid;
        private readonly GridMaker _gridMaker;
        private readonly SeeNextGeneration _seeNextGeneration;
        private readonly IGameOutput _gameOutput;
        private readonly NextGeneration _nextGeneration;
        private bool _gameEnd;


        public GamePlayer(IGameInput gameInput, IGameOutput gameOutput)
        {
            GameGrid = new GameGrid();
            _gridMaker = new GridMaker(gameInput, gameOutput, GameGrid);
            _seeNextGeneration = new SeeNextGeneration(gameInput, gameOutput);
            _gameOutput = gameOutput;
            _nextGeneration = new NextGeneration();
        }

        public void Play()
        {
            _gameOutput.Output(OutputMessages.Welcome);

            GenerateGrid();
            GenerateSeed();
            PlayNextGeneration();

            _gameOutput.Output(OutputMessages.PrintGameEnd);
        }

        public void GenerateGrid()
        {
            _gameEnd = _gridMaker.IsGenerationInterrupted();

            if (_gameEnd) return;
            _gameOutput.Output(OutputMessages.PrintGrid + GameGrid.ConvertGridToOutput());
            _gameOutput.Output(OutputMessages.AddInitialSeed);
        }

        public void GenerateSeed()
        {
            var endOfSeedInput = false;
            while (!endOfSeedInput && !_gameEnd)
            {
                _gameEnd = _gridMaker.IsAddLiveCellInterrupted();
                if (_gameEnd) return;
                _gameOutput.Output(OutputMessages.PrintGrid + GameGrid.ConvertGridToOutput());

                (_gameEnd, endOfSeedInput) = _gridMaker.SeedGenerationStatus();
            }
        }

        public void PlayNextGeneration()
        {
            while (!_gameEnd)
            {
                _nextGeneration.CreateGeneration(GameGrid);
                _gameOutput.Output(OutputMessages.PrintNextGeneration + GameGrid.ConvertGridToOutput());
                _gameEnd = _seeNextGeneration.IsSeeGenerationInterrupted();
            }
        }
    }
}