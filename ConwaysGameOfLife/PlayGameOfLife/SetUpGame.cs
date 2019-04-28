using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GameHelpers.GameConstants;
using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;
using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class SetUpGame
    {
        private readonly PlayerInput _playerInput;
        private readonly GameGrid _gameGrid;
        private GridDimensions _gridDimensions;

        public SetUpGame(IGameInput gameInput, IGameOutput gameOutput, GameGrid gameGrid)
        {
            _playerInput = new PlayerInput(gameInput, gameOutput);
            _gameGrid = gameGrid;
        }

        public bool IsGridGenerationInterrupted()
        {
            var gridHeight = _playerInput.GetGridSetUpInput(OutputMessages.EnterGridHeight,
                OutputMessages.InvalidGridSize, GridInputConstants.MinGridSize, GridInputConstants.MaxGridSize);

            if (gridHeight == ContinueGameInputConstants.Quit) return true;

            var gridWidth = _playerInput.GetGridSetUpInput(OutputMessages.EnterGridWidth,
                OutputMessages.InvalidGridSize, GridInputConstants.MinGridSize, GridInputConstants.MaxGridSize);

            if (gridWidth == ContinueGameInputConstants.Quit) return true;

            _gridDimensions = new GridDimensions {Height = int.Parse(gridHeight), Width = int.Parse(gridWidth)};

            _gameGrid.GenerateGrid(_gridDimensions);

            return false;
        }

        public bool IsAddLiveCellInterrupted()
        {
            var xCoordinate = _playerInput.GetGridSetUpInput(OutputMessages.EnterXCoordinateOfCell,
                OutputMessages.InvalidCoordinate, GridInputConstants.MinCoordinateValue, _gridDimensions.Height);

            if (xCoordinate == ContinueGameInputConstants.Quit) return true;

            var yCoordinate = _playerInput.GetGridSetUpInput(OutputMessages.EnterYCoordinateOfCell,
                OutputMessages.InvalidCoordinate, GridInputConstants.MinCoordinateValue, _gridDimensions.Width);

            if (yCoordinate == ContinueGameInputConstants.Quit) return true;

            var coordinate = _gameGrid.GetGridCoordinate(new Coordinate
                {X = int.Parse(xCoordinate), Y = int.Parse(yCoordinate)});
            
            _gameGrid.UpdateGrid(new List<Coordinate> {coordinate}, CellType.Live);
            
            return false;
        }

        public (bool, bool) SeedGenerationStatus()
        {
            var gameEnd = false;
            var endOfSeedInput = false;
            var addMoreLiveCells =
                _playerInput.GetContinueGameInput(OutputMessages.AddMoreLiveCells,
                    OutputMessages.InvalidAddMoreLiveCells);

            if (addMoreLiveCells == ContinueGameInputConstants.Quit)
            {
                gameEnd = true;
            }
            else if (addMoreLiveCells == ContinueGameInputConstants.No)
            {
                endOfSeedInput = true;
            }

            return (gameEnd, endOfSeedInput);
        }
    }
}