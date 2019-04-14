using System.Collections.Generic;
using Xunit;
using GameInput = ConwaysGameOfLifeTests.Stubs.GameInput;

namespace ConwaysGameOfLifeTests.GameInputTests
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
            _gameInput.ListOfPlayerInputs = new List<string>{"10"};

            var returnedPlayerInput = _gameInput.GetPlayerInput();

            Assert.Equal("10", returnedPlayerInput);
        }
    }
}