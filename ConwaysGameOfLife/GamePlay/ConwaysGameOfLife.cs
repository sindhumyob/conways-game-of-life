

namespace ConwaysGameOfLife
{
    public class ConwaysGameOfLife
    {
        private static StartGameOfLife _startGameOfLife;
        static void Main(string[] args)
        {
            var gameInput = new GameInput.GameInput();
            _startGameOfLife = new StartGameOfLife(gameInput);

            _startGameOfLife.StartGame();
        }
    }
}