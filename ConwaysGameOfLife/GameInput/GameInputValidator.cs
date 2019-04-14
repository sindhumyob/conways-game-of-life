using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.GameInput
{
    public class GameInputValidator
    {
        public bool IsGridSizeResponseValid(string input)
        {
            if (input.ToLower() == GameConstants.QuitInput)
            {
                return true;
            }

            if (!int.TryParse(input, out var n)) return false;

            return int.Parse(input) >= GameConstants.MinGridSize && int.Parse(input) <= GameConstants.MaxGridSize;
        }

        public bool IsCoordinateResponseValid(string input, int maxCoordinateValue)
        {
            if (input.ToLower() == GameConstants.QuitInput)
            {
                return true;
            }

            if (!int.TryParse(input, out var n)) return false;

            return int.Parse(input) > 0 && int.Parse(input) <= maxCoordinateValue;
        }

        public bool IsContinueGameResponseValid(string input)
        {
            return input.ToLower() == GameConstants.QuitInput || input.ToLower() == GameConstants.YesInput ||
                   input.ToLower() == GameConstants.NoInput;
        }
    }
}