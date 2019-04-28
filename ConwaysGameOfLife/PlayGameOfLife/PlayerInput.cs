using System;
using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class PlayerInput
    {
        private readonly IGameInput _gameInput;
        private readonly IGameOutput _gameOutput;
        private readonly InputValidator _inputValidator;

        public PlayerInput(IGameInput gameInput, IGameOutput gameOutput)
        {
            _gameInput = gameInput;
            _gameOutput = gameOutput;
            _inputValidator = new InputValidator();
        }

        public string GetContinueGameInput(string inputPromptMessage, string invalidInputMessage)
        {
            while (true)
            {
                _gameOutput.Output(inputPromptMessage);
                var playerInput = _gameInput.Input();

                if (_inputValidator.IsContinueGameInputValid(playerInput))
                {
                    return playerInput;
                }

                _gameOutput.Output(invalidInputMessage);
            }
        }

        public string GetGridSetUpInput(string inputPromptMessage, string invalidInputMessage, int minValue,
            int maxValue)
        {
            while (true)
            {
                _gameOutput.Output(inputPromptMessage);
                var playerInput = _gameInput.Input();

                if (_inputValidator.IsGridSetUpInputValid(playerInput, minValue, maxValue))
                {
                    return playerInput;
                }

                _gameOutput.Output(invalidInputMessage);
            }
        }
    }
}