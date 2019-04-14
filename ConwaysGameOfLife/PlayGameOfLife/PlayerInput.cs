using System;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class PlayerInput
    {
        private readonly IGameInput _gameInput;
        private readonly IGameOutput _gameOutput;

        public PlayerInput(IGameInput gameInput, IGameOutput gameOutput)
        {
            _gameInput = gameInput;
            _gameOutput = gameOutput;
        }

        public string GetPlayerInput(string inputPromptMessage, string invalidInputMessage,
            Func<string, bool> validationFunction)
        {
            while (true)
            {
                _gameOutput.OutputGame(inputPromptMessage);
                var playerInput = _gameInput.GetPlayerInput();
                if (validationFunction(playerInput))
                {
                    return playerInput;
                }

                _gameOutput.OutputGame(invalidInputMessage);
            }
        }

        public string GetPlayerCoordinateInput(string inputPromptMessage, string invalidInputMessage,
            int maxCoordinateValue,
            Func<string, int, bool> validationFunction)
        {
            while (true)
            {
                _gameOutput.OutputGame(inputPromptMessage);
                var playerInput = _gameInput.GetPlayerInput();
                if (validationFunction(playerInput, maxCoordinateValue))
                {
                    return playerInput;
                }

                _gameOutput.OutputGame(invalidInputMessage);
            }
        }
    }
}