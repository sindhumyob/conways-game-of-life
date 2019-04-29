using ConwaysGameOfLife.GameHelpers.GameConstants.InputConstants;
using ConwaysGameOfLife.GameHelpers.GameConstants.OutputConstants;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput.Interfaces;

namespace ConwaysGameOfLife.PlayGameOfLife
{
    public class SeeNextGeneration
    {
        private readonly PlayerInput _playerInput;

        public SeeNextGeneration(IGameInput gameInput, IGameOutput gameOutput)
        {
            _playerInput = new PlayerInput(gameInput, gameOutput);
        }

        public bool IsSeeGenerationInterrupted()
        {
            var seeNextGenerations =
                _playerInput.ContinueGame(Messages.SeeNextGeneration,
                    Messages.InvalidSeeNextGeneration);

            return seeNextGenerations == ContinueGameConstants.Quit ||
                   seeNextGenerations == ContinueGameConstants.No;
        }
    }
}