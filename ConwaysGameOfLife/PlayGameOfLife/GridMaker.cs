using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GameHelpers.GameConstants;
using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;
using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class GridMaker
    {
        private readonly PlayerInput _playerInput;
        private readonly GameGrid _gameGrid;
        private GridDimensions _dimensions;

        public GridMaker(IGameInput gameInput, IGameOutput gameOutput, GameGrid gameGrid)
        {
            _playerInput = new PlayerInput(gameInput, gameOutput);
            _gameGrid = gameGrid;
        }

        public bool IsGenerationInterrupted()
        {
            var height = _playerInput.GridSetup(OutputMessages.EnterGridHeight,
                OutputMessages.InvalidGridSize, GridInputConstants.MinGridSize, GridInputConstants.MaxGridSize);

            if (height == ContinueGameInputConstants.Quit) return true;

            var width = _playerInput.GridSetup(OutputMessages.EnterGridWidth,
                OutputMessages.InvalidGridSize, GridInputConstants.MinGridSize, GridInputConstants.MaxGridSize);

            if (width == ContinueGameInputConstants.Quit) return true;

            _dimensions = new GridDimensions {Height = int.Parse(height), Width = int.Parse(width)};

            _gameGrid.Generate(_dimensions);

            return false;
        }

        public bool IsAddLiveCellInterrupted()
        {
            var xCoordinate = _playerInput.GridSetup(OutputMessages.EnterXCoordinateOfCell,
                OutputMessages.InvalidCoordinate, GridInputConstants.MinCoordinateValue, _dimensions.Height);

            if (xCoordinate == ContinueGameInputConstants.Quit) return true;

            var yCoordinate = _playerInput.GridSetup(OutputMessages.EnterYCoordinateOfCell,
                OutputMessages.InvalidCoordinate, GridInputConstants.MinCoordinateValue, _dimensions.Width);

            if (yCoordinate == ContinueGameInputConstants.Quit) return true;

            var coordinate = _gameGrid.GetGridCoordinate(new Coordinate
                {X = int.Parse(xCoordinate), Y = int.Parse(yCoordinate)});
            
            _gameGrid.Update(new List<Coordinate> {coordinate}, CellType.Live);
            
            return false;
        }

        public (bool, bool) SeedGenerationStatus()
        {
            var gameEnd = false;
            var endOfSeedInput = false;
            var addMoreLiveCells =
                _playerInput.ContinueGame(OutputMessages.AddMoreLiveCells,
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