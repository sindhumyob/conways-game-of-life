namespace ConwaysGameOfLife.GameInput
{
    public class GameInputValidator
    {
        private const int MinGridSize = 3;
        private const int MaxGridSize = 100;
        private const string QuitInput = "q";
        private const string YesInput = "y";
        private const string NoInput = "n";

        public bool IsGridSizeResponseValid(string input)
        {
            if (input.ToLower() == QuitInput)
            {
                return true;
            }

            if (!int.TryParse(input, out var n)) return false;

            return int.Parse(input) >= MinGridSize && int.Parse(input) <= MaxGridSize;
        }

        public bool IsCoordinateResponseValid(string input, int maxCoordinateValue)
        {
            if (input.ToLower() == QuitInput)
            {
                return true;
            }

            if (!int.TryParse(input, out var n)) return false;

            return int.Parse(input) > 0 && int.Parse(input) <= maxCoordinateValue;
        }

        public bool IsContinueGameResponseValid(string input)
        {
            return input.ToLower() == QuitInput || input.ToLower() == YesInput || input.ToLower() == NoInput;
        }
    }
}