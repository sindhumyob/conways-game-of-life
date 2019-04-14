using System;
using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLife.GameOutput
{
    public class GameOutput : IGameOutput
    {
        public void OutputGame(string gameOutput)
        {
            Console.Write(gameOutput);
        }
    }
}