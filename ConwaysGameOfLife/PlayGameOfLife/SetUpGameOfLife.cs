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
        private readonly PlayerInput _playerInput;
        private readonly IGameOutput _gameOutput;
        private readonly GameGrid _gameGrid;
        private int _gridHeight;
        private int _gridWidth;

        public SetUpGameOfLife(IGameInput gameInput, IGameOutput gameOutput, GameGrid gameGrid)
        {
            _playerInput = new PlayerInput(gameInput, gameOutput);
            _gameOutput = gameOutput;
            _gameGrid = gameGrid;
        }

        public bool GridGenerationGameStatus()
        {
            var gridHeight = _playerInput.GetPlayerGridSetUpInput(OutputMessages.EnterGridHeight,
                OutputMessages.InvalidGridSize, GridInputConstants.MinGridSize, GridInputConstants.MaxGridSize);
            if (gridHeight == ContinueGameInputConstants.QuitInput) return true;

            var gridWidth = _playerInput.GetPlayerGridSetUpInput(OutputMessages.EnterGridWidth,
                OutputMessages.InvalidGridSize, GridInputConstants.MinGridSize, GridInputConstants.MaxGridSize);
            if (gridWidth == ContinueGameInputConstants.QuitInput) return true;

            _gridHeight = int.Parse(gridHeight);
            _gridWidth = int.Parse(gridWidth);

            GenerateInitialGrid(_gridHeight, _gridWidth);
            _gameOutput.OutputGame(OutputMessages.AddInitialSeed);

            return false;
        }

        public bool SeedGenerationGameStatus()
        {
            var xCoordinate = _playerInput.GetPlayerGridSetUpInput(
                OutputMessages.EnterXCoordinateOfCell,
                OutputMessages.InvalidCoordinate, GridInputConstants.MinCoordinateInputValue,
                _gridHeight);
            if (xCoordinate == ContinueGameInputConstants.QuitInput) return true;

            var yCoordinate = _playerInput.GetPlayerGridSetUpInput(
                OutputMessages.EnterYCoordinateOfCell,
                OutputMessages.InvalidCoordinate, GridInputConstants.MinCoordinateInputValue,
                _gridWidth);
            if (yCoordinate == ContinueGameInputConstants.QuitInput) return true;

            UpdateGrid(new Coordinate {X = int.Parse(xCoordinate), Y = int.Parse(yCoordinate)});
            return false;
        }

        private void GenerateInitialGrid(int gridHeight, int gridWidth)
        {
            _gameGrid.GenerateInitialGrid(gridHeight, gridWidth);
            _gameOutput.OutputGame(OutputMessages.PrintGrid + _gameGrid.ConvertGridToOutput());
        }

        private void UpdateGrid(Coordinate inputCoordinate)
        {
            var coordinate = _gameGrid.ConvertInputCoordinateToGridCoordinate(inputCoordinate);
            _gameGrid.UpdateGameGridCells(
                new List<Coordinate>()
                {
                    coordinate
                }, CellType.Live);
            _gameOutput.OutputGame(OutputMessages.PrintGrid + _gameGrid.ConvertGridToOutput());
        }
    }
}