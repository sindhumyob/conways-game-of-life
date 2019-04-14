using ConwaysGameOfLife.GameOutput;

namespace ConwaysGameOfLifeTests.Stubs
{
    public class GameOutputter : IGameOutput
    {
        public string Output { get; set; }
        
        public void GameOutput(string outputString)
        {
            Output = outputString;
        }
    }
}