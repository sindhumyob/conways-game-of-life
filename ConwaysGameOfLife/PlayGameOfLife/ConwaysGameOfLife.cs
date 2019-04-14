namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class ConwaysGameOfLife
    {
        private static GamePlay.PlayGameOfLife _playGameOfLife;

        static void Main(string[] args)
        {
            var gameInput = new GameInput.GameInput();
            var gameOutput = new GameOutput.GameOutput();
            _playGameOfLife = new GamePlay.PlayGameOfLife(gameInput, gameOutput);

            _playGameOfLife.StartGame();
        }
    }
}