using System.Collections.Generic;
using ConwaysGameOfLife.GameInput.Interfaces;

namespace ConwaysGameOfLifeTests.Stubs
{
    public class GameInput : IGameInput
    {
        public List<string> PlayerInputs { get; set; }

        public string GetPlayerInput()
        {
            var input = PlayerInputs[0];
            PlayerInputs.RemoveAt(0);
            return input;
        }
    }
}