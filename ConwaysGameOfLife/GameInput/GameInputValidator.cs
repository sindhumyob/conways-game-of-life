using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GameHelpers.GameConstants;

namespace ConwaysGameOfLife.GameInput
{
    public class GameInputValidator
    {
        public bool IsGridSetUpInputValid(string input, int minValue, int maxValue)
        {
            if (input.ToLower() == ContinueGameInputConstants.QuitInput) return true;

            if (!int.TryParse(input, out var n)) return false;

            return n >= minValue && n <= maxValue;
        }

        public bool IsContinueGameInputValid(string input)
        {
            return input.ToLower() == ContinueGameInputConstants.QuitInput || input.ToLower() == ContinueGameInputConstants.YesInput ||
                   input.ToLower() == ContinueGameInputConstants.NoInput;
        }
    }
}