using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GameHelpers.GameConstants;
using ConwaysGameOfLife.GameInput;
using ConwaysGameOfLife.GameInput.Interfaces;
using ConwaysGameOfLife.GameOutput;
using ConwaysGameOfLife.GameOutput.Interfaces;
using ConwaysGameOfLife.NextGenerationCreation;

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
            var seeMoreGenerations =
                _playerInput.ContinueGame(OutputMessages.PrintSeeNextGeneration,
                    OutputMessages.InvalidSeeMoreGenerations);

            return seeMoreGenerations == ContinueGameInputConstants.Quit ||
                   seeMoreGenerations == ContinueGameInputConstants.No;
        }
    }
}