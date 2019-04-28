namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class ConwaysGameOfLife
    {
        private static PlayGame _playGame;

        static void Main(string[] args)
        {
            var gameInput = new GameInput.GameInput();
            var gameOutput = new GameOutput.GameOutput();
            _playGame = new PlayGame(gameInput, gameOutput);

            _playGame.Play();
        }
    }
}