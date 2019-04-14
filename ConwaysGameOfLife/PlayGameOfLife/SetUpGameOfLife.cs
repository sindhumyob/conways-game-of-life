using System;
using System.Collections.Generic;
using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;
using ConwaysGameOfLife.GamePlayHelpers;

namespace ConwaysGameOfLife.GamePlay
{
    public class SetUpGameOfLife
    {
        private readonly GameOutputMessages _gameOutputMessages;
        private readonly InputValidator _inputValidator;
        private readonly GameGrid _gameGrid;
        private readonly IGameOutput _gameOutput;
        private readonly PlayerInputGetter _playerInputGetter;
        private int _gridHeight;
        private int _gridWidth;

        public SetUpGameOfLife(IGameInput gameInput, IGameOutput gameOutput, GameGrid gameGrid)
        {
            _gameOutputMessages = new GameOutputMessages();
            _gameGrid = gameGrid;
            _inputValidator = new InputValidator();
            _playerInputGetter = new PlayerInputGetter(gameInput, gameOutput);
            _gameOutput = gameOutput;
        }

        public bool SetUpInitialGame()
        {
            var gridHeight = _playerInputGetter.GetPlayerInput(_gameOutputMessages.EnterGridHeightMessage(),
                _gameOutputMessages.InvalidGridSizeMessage(), _inputValidator.IsGridSizeResponseValid);
            if (gridHeight == "q")
            {
                return true;
            }

            _gridHeight = int.Parse(gridHeight);

            var gridWidth = _playerInputGetter.GetPlayerInput(_gameOutputMessages.EnterGridWidthMessage(),
                _gameOutputMessages.InvalidGridSizeMessage(), _inputValidator.IsGridSizeResponseValid);
            if (gridWidth == "q")
            {
                return true;
            }

            _gridWidth = int.Parse(gridWidth);

            GenerateInitialGrid(int.Parse(gridHeight), int.Parse(gridWidth));
            _gameOutput.GameOutput(_gameOutputMessages.AddInitialSeedMessage());
            return false;
        }

        public bool SetUpInitialSeed()
        {
            var xCoordinate = _playerInputGetter.GetPlayerCoordinateInput(
                _gameOutputMessages.EnterXCoordinateOfCellMessage(_gridHeight),
                _gameOutputMessages.InvalidCoordinateMessage(), _gridHeight,
                _inputValidator.IsCoordinateResponseValid);
            if (xCoordinate == "q")
            {
                return true;
            }

            var yCoordinate = _playerInputGetter.GetPlayerCoordinateInput(
                _gameOutputMessages.EnterYCoordinateOfCellMessage(_gridWidth),
                _gameOutputMessages.InvalidCoordinateMessage(), _gridWidth,
                _inputValidator.IsCoordinateResponseValid);
            if (yCoordinate == "q")
            {
                return true;
            }

            GenerateUpdatedGrid(int.Parse(xCoordinate), int.Parse(yCoordinate));
            return false;
        }

        private void GenerateInitialGrid(int gridHeight, int gridWidth)
        {
            _gameGrid.GenerateInitialGrid(gridHeight, gridWidth);
            _gameOutput.GameOutput(_gameOutputMessages.PrintGridMessage(_gameGrid.CurrentGameGrid));
        }

        private void GenerateUpdatedGrid(int xCoordinateInput, int yCoordinateInput)
        {
            _gameGrid.UpdateGameGridCells(
                new List<Coordinate>()
                {
                    new Coordinate()
                    {
                        XCoordinate = xCoordinateInput - 1, YCoordinate = yCoordinateInput - 1
                    }
                }, CellType.Live);
            _gameOutput.GameOutput(_gameOutputMessages.PrintGridMessage(_gameGrid.CurrentGameGrid));
        }
    }
}