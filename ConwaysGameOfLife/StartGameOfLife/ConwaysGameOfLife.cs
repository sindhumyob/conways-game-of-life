using ConwaysGameOfLife.GameOutput;

namespace ConwaysGameOfLife.GamePlay
{
    public class ConwaysGameOfLife
    {
        private static StartGameOfLife _startGameOfLife;
        static void Main(string[] args)
        {
            var gameInput = new GameInput.GameInput();
            var gameOutput = new GameOutputter();
            _startGameOfLife = new StartGameOfLife(gameInput, gameOutput);

            _startGameOfLife.StartGame();
        }
    }
}