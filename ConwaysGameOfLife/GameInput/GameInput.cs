using System;
using ConwaysGameOfLife.GameInput.Interfaces;

namespace ConwaysGameOfLife.GameInput
{
    public class GameInput : IGameInput
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}