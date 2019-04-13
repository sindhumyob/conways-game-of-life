using System;
using ConwaysGameOfLife.GameInput.Interfaces;

namespace ConwaysGameOfLife.GameInput
{
    public class GameInput : IGameInput
    {
        public string GetPlayerInput()
        {
            return Console.ReadLine();
        }
    }
}