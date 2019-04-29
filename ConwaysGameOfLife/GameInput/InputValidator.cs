using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GameHelpers.GameConstants;
using ConwaysGameOfLife.GameHelpers.GameConstants.InputConstants;

namespace ConwaysGameOfLife.GameInput
{
    public class InputValidator
    {
        public bool IsGridSetUpInputValid(string input, int minValue, int maxValue)
        {
            if (input.ToLower() == ContinueGameConstants.Quit) return true;

            if (!int.TryParse(input, out var n)) return false;

            return n >= minValue && n <= maxValue;
        }

        public bool IsContinueGameInputValid(string input)
        {
            return input.ToLower() == ContinueGameConstants.Quit || input.ToLower() == ContinueGameConstants.Yes ||
                   input.ToLower() == ContinueGameConstants.No;
        }
    }
}