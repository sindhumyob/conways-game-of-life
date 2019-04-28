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
        private readonly IGameOutput _gameOutput;
        private readonly GameGrid _gameGrid;
        private GridDimensions _gridDimensions;

        public SetUpGame(IGameInput gameInput, IGameOutput gameOutput, GameGrid gameGrid)
        {
            _playerInput = new PlayerInput(gameInput, gameOutput);
            _gameOutput = gameOutput;
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

            GenerateGrid();
            _gameOutput.Output(OutputMessages.AddInitialSeed);

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

            UpdateGrid(new Coordinate {X = int.Parse(xCoordinate), Y = int.Parse(yCoordinate)});
            return false;
        }

        private void GenerateGrid()
        {
            _gameGrid.GenerateGrid(_gridDimensions);
            _gameOutput.Output(OutputMessages.PrintGrid + _gameGrid.ConvertGridToOutput());
        }

        private void UpdateGrid(Coordinate inputCoordinate)
        {
            var coordinate = _gameGrid.GetGridCoordinate(inputCoordinate);
            _gameGrid.UpdateGrid(new List<Coordinate> {coordinate}, CellType.Live);
            _gameOutput.Output(OutputMessages.PrintGrid + _gameGrid.ConvertGridToOutput());
        }
    }
}