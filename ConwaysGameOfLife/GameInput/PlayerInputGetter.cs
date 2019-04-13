using System;
using System.Collections.Generic;
using ConwaysGameOfLife.GameInput.Interfaces;

namespace ConwaysGameOfLife.GameInput
{
    public class PlayerInputGetter
    {
        private readonly IGameInput _gameInput;
        private readonly InputValidator _inputValidator;
        public PlayerInputGetter(IGameInput gameInput)
        {
            _inputValidator = new InputValidator();
            _gameInput = gameInput;
            
        }


        public string GetPlayerInput(string enterInputMessage,string invalidInputMessage, Func<string, bool> invalidInputValidatorMethod)
        {
            Console.WriteLine(enterInputMessage);
            while (true)
            {
                var input = _gameInput.GetPlayerInput();
                if (invalidInputValidatorMethod(input))
                {
                    return input;
                }
                Console.WriteLine(invalidInputMessage);
                Console.WriteLine(enterInputMessage);
            }
        }
    }
}