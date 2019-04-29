using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GameHelpers.GameConstants;
using ConwaysGameOfLife.GameHelpers.GameConstants.InputConstants;
using ConwaysGameOfLife.GameHelpers.GameConstants.OutputConstants;
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
                _playerInput.ContinueGame(Messages.PrintSeeNextGeneration,
                    Messages.InvalidSeeMoreGenerations);

            return seeMoreGenerations == ContinueGameConstants.Quit ||
                   seeMoreGenerations == ContinueGameConstants.No;
        }
    }
}