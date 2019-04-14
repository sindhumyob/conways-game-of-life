using System.Collections.Generic;
using ConwaysGameOfLife.GameInput.Interfaces;

namespace ConwaysGameOfLifeTests.Stubs
{
    public class GameInput : IGameInput
    {
        public List<string> ListOfPlayerInputs { get; set; }

        public string GetPlayerInput()
        {
            var input = ListOfPlayerInputs[0];
            ListOfPlayerInputs.RemoveAt(0);
            return input;
        }
    }
}