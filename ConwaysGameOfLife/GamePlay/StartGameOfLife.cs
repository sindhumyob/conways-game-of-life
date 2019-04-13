using System;
using System.Collections.Generic;
using System.Threading;
using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GamePlayHelpers;

namespace ConwaysGameOfLife
{
    public class StartGameOfLife
    {
        private readonly GameOutput _gameOutput;
        private readonly InputValidator _inputValidator;
        private readonly GameGrid _gameGrid;
        private readonly IGameInput _gameInput;
        private readonly PlayGameOfLife _playGameOfLife;
        private bool _validInput;
        private bool _endOfSeedInput;
        private bool _gameQuit;
        private bool _gameEnd;

        public StartGameOfLife(IGameInput gameInput)
        {
            _gameOutput = new GameOutput();
            _gameGrid = new GameGrid();
            _playGameOfLife = new PlayGameOfLife();
            _inputValidator = new InputValidator();
            _gameInput = gameInput;
        }


        public void StartGame()
        {
            Console.Write(_gameOutput.WelcomeMessage());

            while (!_validInput)
            {
                Console.Write(_gameOutput.EnterGridHeightMessage());
                var gridHeightInput = _gameInput.GetPlayerInput();
                if (gridHeightInput == "q")
                {
                    _gameQuit = true;
                    break;
                }

                Console.Write(_gameOutput.EnterGridWidthMessage());
                var gridWidthInput = _gameInput.GetPlayerInput();
                if (gridWidthInput == "q")
                {
                    _gameQuit = true;
                    break;
                }

                Console.Write(GenerateInitialGrid(gridHeightInput, gridWidthInput));
            }

            if (!_gameQuit)
            {
                Console.Write(_gameOutput.AddInitialSeedMessage());
                while (!_endOfSeedInput && !_gameQuit)
                {
                    Console.Write(
                        _gameOutput.EnterXCoordinateOfCellMessage(_gameGrid.CurrentGameGrid.GetLength(0) - 1));
                    var xCoordinateInput = _gameInput.GetPlayerInput();
                    if (xCoordinateInput == "q")
                    {
                        _gameQuit = true;
                        break;
                    }

                    Console.Write(
                        _gameOutput.EnterYCoordinateOfCellMessage(_gameGrid.CurrentGameGrid.GetLength(1) - 1));
                    var yCoordinateInput = _gameInput.GetPlayerInput();
                    if (yCoordinateInput == "q")
                    {
                        _gameQuit = true;
                        break;
                    }

                    ObtainSeedCoordinates(xCoordinateInput, yCoordinateInput);
                }

                if (!_gameQuit && !_gameEnd)
                {
                    Console.Write(_gameOutput.StartingGameOfLifeMessage());

                    while (!_gameEnd)
                    {
                        Console.Write(_playGameOfLife.PlayGame(_gameGrid));

                        while (true)
                        {
                            Console.Write(_gameOutput.PrintSeeNextTransitionMessage());
                            var seeNextTransitionPlayerInput = _gameInput.GetPlayerInput();
                            if (_inputValidator.IsContinueGameResponseValid(seeNextTransitionPlayerInput))
                            {
                                if (seeNextTransitionPlayerInput != "n" && seeNextTransitionPlayerInput != "q") break;
                                _gameEnd = true;
                                break;
                            }

                            Console.Write(_gameOutput.InvalidSeeMoreTransitionsMessage());
                        }
                    }
                }
            }

            Console.Write(_gameOutput.PrintEndGameMessage());
        }

        private void ObtainSeedCoordinates(string xCoordinateInput, string yCoordinateInput)
        {
            if (_inputValidator.IsCoordinateResponseValid(xCoordinateInput,
                    _gameGrid.CurrentGameGrid.GetLength(0) - 1) &&
                _inputValidator.IsCoordinateResponseValid(yCoordinateInput, _gameGrid.CurrentGameGrid.GetLength(1) - 1))
            {
                _gameGrid.UpdateGameGridCells(
                    new List<Coordinate>()
                    {
                        new Coordinate()
                        {
                            XCoordinate = int.Parse(xCoordinateInput) - 1, YCoordinate = int.Parse(yCoordinateInput) - 1
                        }
                    }, CellType.Live);
                Console.WriteLine(_gameOutput.PrintGridMessage(_gameGrid.CurrentGameGrid));


                while (true)
                {
                    Console.Write(_gameOutput.AddMoreLiveCellsMessage());
                    var addMoreCellsInput = _gameInput.GetPlayerInput();

                    if (addMoreCellsInput == "q")
                    {
                        _gameQuit = true;
                        return;
                    }

                    if (!_inputValidator.IsContinueGameResponseValid(addMoreCellsInput))
                    {
                        Console.Write(_gameOutput.InvalidAddMoreLiveCellsMessage());
                        continue;
                    }


                    switch (addMoreCellsInput)
                    {
                        case "n":
                            _endOfSeedInput = true;
                            return;
                        case "y":
                            return;
                    }
                }
            }

            Console.Write(_gameOutput.InvalidCoordinateMessage());
        }

        private string GenerateInitialGrid(string gridHeightInput, string gridWidthInput)
        {
            if (_inputValidator.IsGridSizeResponseValid(gridHeightInput) &&
                _inputValidator.IsGridSizeResponseValid(gridWidthInput))
            {
                _validInput = true;
                _gameGrid.GenerateInitialGrid(int.Parse(gridHeightInput), int.Parse(gridWidthInput));
                return _gameOutput.PrintGridMessage(_gameGrid.CurrentGameGrid);
            }

            return _gameOutput.InvalidGridSizeMessage();
        }
    }
}