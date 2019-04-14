using ConwaysGameOfLife.GameOutput;

namespace ConwaysGameOfLife.GamePlay
{
    public class ConwaysGameOfLife
    {
        private static PlayGameOfLife _playGameOfLife;
        static void Main(string[] args)
        {
            var gameInput = new GameInput.GameInput();
            var gameOutput = new GameOutput.GameOutput();
            _playGameOfLife = new PlayGameOfLife(gameInput, gameOutput);

            _playGameOfLife.StartGame();
        }
    }
}