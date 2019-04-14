namespace ConwaysGameOfLife.GameInput
{
    public class InputValidator
    {
        private const int MinGridSize = 3;
        private const int MaxGridSize = 100;

        public bool IsGridSizeResponseValid(string input)
        {
            if (input.ToLower() == "q")
            {
                return true;
            }

            if (!int.TryParse(input, out var n)) return false;

            return int.Parse(input) >= MinGridSize && int.Parse(input) <= MaxGridSize;
        }

        public bool IsCoordinateResponseValid(string input, int maxCoordinateValue)
        {
            if (input.ToLower() == "q")
            {
                return true;
            }

            if (!int.TryParse(input, out var n)) return false;

            return int.Parse(input) > 0 && int.Parse(input) <= maxCoordinateValue;
        }

        public bool IsContinueGameResponseValid(string input)
        {
            return input.ToLower() == "q" || input.ToLower() == "y" || input.ToLower() == "n";
        }
    }
}