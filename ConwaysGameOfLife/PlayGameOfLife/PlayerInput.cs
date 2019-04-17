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
        private readonly GameInputValidator _gameInputValidator;

        public PlayerInput(IGameInput gameInput, IGameOutput gameOutput)
        {
            _gameInput = gameInput;
            _gameOutput = gameOutput;
            _gameInputValidator = new GameInputValidator();
        }

        public string GetPlayerContinueGameInput(string inputPromptMessage, string invalidInputMessage)
        {
            while (true)
            {
                _gameOutput.OutputGame(inputPromptMessage);
                var playerInput = _gameInput.GetPlayerInput();

                if (_gameInputValidator.IsContinueGameInputValid(playerInput))
                {
                    return playerInput;
                }

                _gameOutput.OutputGame(invalidInputMessage);
            }
        }

        public string GetPlayerGridSetUpInput(string inputPromptMessage, string invalidInputMessage, int minValue,
            int maxValue)
        {
            while (true)
            {
                _gameOutput.OutputGame(inputPromptMessage);
                var playerInput = _gameInput.GetPlayerInput();

                if (_gameInputValidator.IsGridSetUpInputValid(playerInput, minValue, maxValue))
                {
                    return playerInput;
                }

                _gameOutput.OutputGame(invalidInputMessage);
            }
        }
    }
}