using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLifeTests.Stubs
{
    public class GameOutput : IGameOutput
    {
        public string Message { get; set; }

        public void Output(string gameOutput)
        {
            Message += gameOutput + "\n";
        }
    }
}