using System;

namespace ConwaysGameOfLife.GameOutput
{
    public class GameOutputter : IGameOutput
    {
        public void GameOutput(string outputString)
        {
            Console.Write(outputString);
        }
    }
}