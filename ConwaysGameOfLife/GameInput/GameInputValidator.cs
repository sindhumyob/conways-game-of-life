using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.GameInput
{
    public class GameInputValidator
    {
        public bool IsGridSetUpInputValid(string input, int minValue, int maxValue)
        {
            if (input.ToLower() == GameConstants.QuitInput) return true;

            if (!int.TryParse(input, out var n)) return false;

            return n >= minValue && n <= maxValue;
        }

        public bool IsContinueGameInputValid(string input)
        {
            return input.ToLower() == GameConstants.QuitInput || input.ToLower() == GameConstants.YesInput ||
                   input.ToLower() == GameConstants.NoInput;
        }
    }
}