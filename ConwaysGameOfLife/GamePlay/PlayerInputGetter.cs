using System;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;

namespace ConwaysGameOfLife.GamePlay
{
    public class PlayerInputGetter
    {
        
        private readonly IGameInput _gameInput;
        private readonly IGameOutput _gameOutput;
        
        public PlayerInputGetter(IGameInput gameInput, IGameOutput gameOutput)
        {

            _gameInput = gameInput;
            _gameOutput = gameOutput;

        }
        public string GetPlayerInput(string inputPromptMessage, string invalidInputMessage,
            Func<string, bool> validationFunction)
        {
            while (true)
            {
                _gameOutput.GameOutput(inputPromptMessage);
                var playerInput = _gameInput.GetPlayerInput();
                if (validationFunction(playerInput))
                {
                    return playerInput;
                }

                _gameOutput.GameOutput(invalidInputMessage);
            }
        }

        public string GetPlayerCoordinateInput(string inputPromptMessage, string invalidInputMessage,
            int maxCoordinateValue,
            Func<string, int, bool> validationFunction)
        {
            while (true)
            {
                _gameOutput.GameOutput(inputPromptMessage);
                var playerInput = _gameInput.GetPlayerInput();
                if (validationFunction(playerInput, maxCoordinateValue))
                {
                    return playerInput;
                }

                _gameOutput.GameOutput(invalidInputMessage);
            }
        }
    }
}