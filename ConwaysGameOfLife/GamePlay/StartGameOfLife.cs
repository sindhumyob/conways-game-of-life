using System;
using System.Collections.Generic;
using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;
using ConwaysGameOfLife.GamePlayHelpers;

namespace ConwaysGameOfLife.GamePlay
{
    public class StartGameOfLife
    {
        private readonly GameOutputMessages _gameOutputMessages;
        private readonly InputValidator _inputValidator;
        private readonly GameGrid _gameGrid;
        private readonly IGameOutput _gameOutput;
        private readonly PlayGameOfLife _playGameOfLife;
        private readonly PlayerInputGetter _playerInputGetter;
        private bool _gameEnd;
        private int _gridHeight;
        private int _gridWidth;
        private bool _endOfSeedInput;

        public StartGameOfLife(IGameInput gameInput, IGameOutput gameOutput)
        {
            _gameOutputMessages = new GameOutputMessages();
            _gameGrid = new GameGrid();
            _playGameOfLife = new PlayGameOfLife();
            _inputValidator = new InputValidator();
            _playerInputGetter = new PlayerInputGetter(gameInput, gameOutput);
            _gameOutput = gameOutput;
        }


        public void InputForInitialGrid()
        {
            var gridHeight = _playerInputGetter.GetPlayerInput(_gameOutputMessages.EnterGridHeightMessage(),
                _gameOutputMessages.InvalidGridSizeMessage(), _inputValidator.IsGridSizeResponseValid);
            if (gridHeight == "q")
            {
                GameEnd();
                return;
            }

            _gridHeight = int.Parse(gridHeight);

            var gridWidth = _playerInputGetter.GetPlayerInput(_gameOutputMessages.EnterGridWidthMessage(),
                _gameOutputMessages.InvalidGridSizeMessage(), _inputValidator.IsGridSizeResponseValid);
            if (gridWidth == "q")
            {
                GameEnd();
                return;
            }

            _gridWidth = int.Parse(gridWidth);

            GenerateInitialGrid(int.Parse(gridHeight), int.Parse(gridWidth));
            _gameOutput.GameOutput(_gameOutputMessages.AddInitialSeedMessage());
        }

        public void InputForInitialSeed()
        {
            var xCoordinate = _playerInputGetter.GetPlayerCoordinateInput(
                _gameOutputMessages.EnterXCoordinateOfCellMessage(_gridHeight),
                _gameOutputMessages.InvalidCoordinateMessage(), _gridHeight,
                _inputValidator.IsCoordinateResponseValid);
            if (xCoordinate == "q")
            {
                GameEnd();
            }

            var yCoordinate = _playerInputGetter.GetPlayerCoordinateInput(
                _gameOutputMessages.EnterYCoordinateOfCellMessage(_gridWidth),
                _gameOutputMessages.InvalidCoordinateMessage(), _gridWidth,
                _inputValidator.IsCoordinateResponseValid);
            if (yCoordinate == "q")
            {
                GameEnd();
            }

            GenerateUpdatedGrid(int.Parse(xCoordinate), int.Parse(yCoordinate));
        }

        public void InputForAddMoreSeeds()
        {
            var addMoreSeedsInput =
                _playerInputGetter.GetPlayerInput(_gameOutputMessages.AddMoreLiveCellsMessage(),
                    _gameOutputMessages.InvalidSeeMoreGenerationsMessage(),
                    _inputValidator.IsContinueGameResponseValid);
            if (addMoreSeedsInput == "q")
            {
                _endOfSeedInput = true;
                GameEnd();
            }

            if (addMoreSeedsInput == "n")
            {
                _endOfSeedInput = true;
            }
        }

        public void PlayGame()
        {
            

            _playGameOfLife.GetNextGeneration(_gameGrid);
            _gameOutput.GameOutput(_gameOutputMessages.PrintNextGenerationGridMessage(_gameGrid.CurrentGameGrid));

            var seeMoreTransitions =
                _playerInputGetter.GetPlayerInput(_gameOutputMessages.PrintSeeNextGenerationMessage(),
                    _gameOutputMessages.InvalidSeeMoreGenerationsMessage(),
                    _inputValidator.IsContinueGameResponseValid);
            if (seeMoreTransitions == "q" || seeMoreTransitions == "n")
            {
                GameEnd();
            }
        }

        public void StartGame()
        {
            _gameOutput.GameOutput(_gameOutputMessages.WelcomeMessage());
            if (!_gameEnd)
            {
                InputForInitialGrid();
            }

            if (!_gameEnd)
            {
                while (!_endOfSeedInput)
                {
                    InputForInitialSeed();
                    InputForAddMoreSeeds();
                }
            }
            _gameOutput.GameOutput(_gameOutputMessages.StartingGameOfLifeMessage());
            while (!_gameEnd)
            {
                PlayGame();
            }
        }

        private void GameEnd()
        {
            _gameEnd = true;
            _gameOutput.GameOutput(_gameOutputMessages.PrintEndGameMessage());
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