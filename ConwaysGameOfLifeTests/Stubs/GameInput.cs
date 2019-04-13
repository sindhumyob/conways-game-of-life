using ConwaysGameOfLife.GameInput.Interfaces;

namespace ConwaysGameOfLifeTests.Stubs
{
    public class GameInput : IGameInput
    {
        public string PlayerInput { get; set; }

        public string GetPlayerInput()
        {
            return PlayerInput;
        }
    }
}