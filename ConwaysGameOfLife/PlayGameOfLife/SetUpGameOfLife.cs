using System.Collections.Generic;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GameHelpers.GameConstants;
using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;
using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class SetUpGameOfLife
    {
        private readonly GameOutputMessages _gameOutputMessages;
        private readonly PlayerInput _playerInput;
        private readonly IGameOutput _gameOutput;
        private readonly GameGrid _gameGrid;
        private int _gridHeight;
        private int _gridWidth;

        public SetUpGameOfLife(IGameInput gameInput, IGameOutput gameOutput, GameGrid gameGrid)
        {
            _gameOutputMessages = new GameOutputMessages();
            _playerInput = new PlayerInput(gameInput, gameOutput);
            _gameOutput = gameOutput;
            _gameGrid = gameGrid;
        }

        public bool SetUpInitialGrid()
        {
            var gridHeight = _playerInput.GetPlayerGridSetUpInput(_gameOutputMessages.EnterGridHeightMessage(),
                _gameOutputMessages.InvalidGridSizeMessage(), GridInputConstants.MinGridSize, GridInputConstants.MaxGridSize);
            if (gridHeight == ContinueGameInputConstants.QuitInput) return true;

            var gridWidth = _playerInput.GetPlayerGridSetUpInput(_gameOutputMessages.EnterGridWidthMessage(),
                _gameOutputMessages.InvalidGridSizeMessage(), GridInputConstants.MinGridSize, GridInputConstants.MaxGridSize) ;
            if (gridWidth == ContinueGameInputConstants.QuitInput) return true;

            _gridHeight = int.Parse(gridHeight);
            _gridWidth = int.Parse(gridWidth);

            GenerateInitialGrid(_gridHeight, _gridWidth);
            _gameOutput.OutputGame(_gameOutputMessages.AddInitialSeedMessage());

            return false;
        }

        public bool SetUpInitialSeed()
        {
            var xCoordinate = _playerInput.GetPlayerGridSetUpInput(
                _gameOutputMessages.EnterXCoordinateOfCellMessage(_gridHeight),
                _gameOutputMessages.InvalidCoordinateMessage(), GridInputConstants.MinCoordinateInputValue,
                _gridHeight);
            if (xCoordinate == ContinueGameInputConstants.QuitInput) return true;

            var yCoordinate = _playerInput.GetPlayerGridSetUpInput(
                _gameOutputMessages.EnterYCoordinateOfCellMessage(_gridWidth),
                _gameOutputMessages.InvalidCoordinateMessage(), GridInputConstants.MinCoordinateInputValue,
                _gridWidth);
            if (yCoordinate == ContinueGameInputConstants.QuitInput) return true;

            UpdateGrid(int.Parse(xCoordinate), int.Parse(yCoordinate));
            return false;
        }

        private void GenerateInitialGrid(int gridHeight, int gridWidth)
        {
            _gameGrid.GenerateInitialGrid(gridHeight, gridWidth);
            _gameOutput.OutputGame(_gameOutputMessages.PrintGridMessage(_gameGrid.CurrentGameGrid));
        }

        private void UpdateGrid(int xCoordinateInput, int yCoordinateInput)
        {
            _gameGrid.UpdateGameGridCells(
                new List<Coordinate>()
                {
                    new Coordinate()
                    {
                        XCoordinate = xCoordinateInput - 1, YCoordinate = yCoordinateInput - 1
                    }
                }, CellType.Live);
            _gameOutput.OutputGame(_gameOutputMessages.PrintGridMessage(_gameGrid.CurrentGameGrid));
        }
    }
}