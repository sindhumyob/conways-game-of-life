using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLifeTests.Stubs
{
    public class GameOutput : IGameOutput
    {
        public string Output { get; set; }

        public void OutputGame(string gameOutput)
        {
            Output += gameOutput + "\n";
        }
    }
}