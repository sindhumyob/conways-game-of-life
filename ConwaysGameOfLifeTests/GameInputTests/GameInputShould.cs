using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLifeTests.Stubs;
using Xunit;
using GameInput = ConwaysGameOfLifeTests.Stubs.GameInput;

namespace ConwaysGameOfLifeTests
{
    public class GameInputShould
    {
        private readonly GameInput _gameInput;

        public GameInputShould()
        {
            
            _gameInput = new GameInput();
        }

        [Fact]
        public void Return_Player_Input()
        {
            _gameInput.PlayerInput = "10";

            var returnedPlayerInput = _gameInput.GetPlayerInput();
            
            Assert.Equal("10", returnedPlayerInput);
        }
    }
}