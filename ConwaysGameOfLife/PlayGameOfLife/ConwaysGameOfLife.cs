namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class ConwaysGameOfLife
    {
        private static GamePlayer _gamePlayer;

        static void Main(string[] args)
        {
            var gameInput = new GameInput.GameInput();
            var gameOutput = new GameOutput.GameOutput();
            _gamePlayer = new GamePlayer(gameInput, gameOutput);

            _gamePlayer.Play();
        }
    }
}