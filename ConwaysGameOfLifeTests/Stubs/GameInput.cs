using System.Collections.Generic;
using ConwaysGameOfLife.GameInput.Interfaces;

namespace ConwaysGameOfLifeTests.Stubs
{
    public class GameInput : IGameInput
    {
        public List<string> PlayerInput { get; set; }

        public string GetPlayerInput()
        {
            var input = PlayerInput[0];
            PlayerInput.RemoveAt(0);
            return input;
        }
    }
}