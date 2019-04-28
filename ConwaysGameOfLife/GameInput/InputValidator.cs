using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GameHelpers.GameConstants;

namespace ConwaysGameOfLife.GameInput
{
    public class InputValidator
    {
        public bool IsGridSetUpInputValid(string input, int minValue, int maxValue)
        {
            if (input.ToLower() == ContinueGameInputConstants.Quit) return true;

            if (!int.TryParse(input, out var n)) return false;

            return n >= minValue && n <= maxValue;
        }

        public bool IsContinueGameInputValid(string input)
        {
            return input.ToLower() == ContinueGameInputConstants.Quit || input.ToLower() == ContinueGameInputConstants.Yes ||
                   input.ToLower() == ContinueGameInputConstants.No;
        }
    }
}