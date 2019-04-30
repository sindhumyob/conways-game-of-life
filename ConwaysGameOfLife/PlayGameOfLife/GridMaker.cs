using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GameHelpers.GameConstants.InputConstants;
using ConwaysGameOfLife.GameHelpers.GameConstants.OutputConstants;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class GridMaker
    {
        private readonly PlayerInput _playerInput;
        private readonly GameGrid _gameGrid;

        public GridMaker(IGameInput gameInput, IGameOutput gameOutput, GameGrid gameGrid)
        {
            _playerInput = new PlayerInput(gameInput, gameOutput);
            _gameGrid = gameGrid;
        }

        public bool IsGenerationInterrupted()
        {
            var height = _playerInput.GridSetup(Messages.EnterGridHeight,
                Messages.InvalidGridSize, GridConstants.MinGridSize, GridConstants.MaxGridSize);

            if (height == ContinueGameConstants.Quit) return true;

            var width = _playerInput.GridSetup(Messages.EnterGridWidth,
                Messages.InvalidGridSize, GridConstants.MinGridSize, GridConstants.MaxGridSize);

            if (width == ContinueGameConstants.Quit) return true;

            _gameGrid.Generate(new GridDimensions {Height = int.Parse(height), Width = int.Parse(width)});

            return false;
        }

        public bool IsAddLiveCellInterrupted()
        {
            var maxInputValues = _gameGrid.GetSize();

            var xCoordinate = _playerInput.GridSetup(Messages.EnterXCoordinate,
                Messages.InvalidCoordinate, GridConstants.MinCoordinateValue, maxInputValues.Height);

            if (xCoordinate == ContinueGameConstants.Quit) return true;

            var yCoordinate = _playerInput.GridSetup(Messages.EnterYCoordinate,
                Messages.InvalidCoordinate, GridConstants.MinCoordinateValue, maxInputValues.Width);

            if (yCoordinate == ContinueGameConstants.Quit) return true;

            var cellCoordinate = _gameGrid.GetGridCoordinate(new Coordinate
                {X = int.Parse(xCoordinate), Y = int.Parse(yCoordinate)});

            _gameGrid.Update(new List<Coordinate> {cellCoordinate}, CellType.Live);

            return false;
        }

        public SeedingStatus SeedGenerationStatus()
        {
            var gameEnd = false;
            var endOfSeeding = false;
            var addLiveCell = _playerInput.ContinueGame(Messages.AddAnotherLiveCell,
                Messages.InvalidAddAnotherLiveCell);

            if (addLiveCell == ContinueGameConstants.Quit)
            {
                gameEnd = true;
            }
            else if (addLiveCell == ContinueGameConstants.No)
            {
                endOfSeeding = true;
            }

            return new SeedingStatus {GameEnd = gameEnd, EndOfSeeding = endOfSeeding};
        }
    }
}