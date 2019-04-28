using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLifeTests.Stubs
{
    public class GameOutput : IGameOutput
    {
        public string OutputMessage { get; set; }

        public void Output(string gameOutput)
        {
            OutputMessage += gameOutput + "\n";
        }
    }
}