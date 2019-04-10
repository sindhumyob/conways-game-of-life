using System.Linq;

namespace ConwaysGameOfLife.GameInput
{
    public class InputValidator
    {
        public bool IsGridSizeResponseValid(string input)
        {
            if (input.ToLower() == "q")
            {
                return true;
            }

            if (!int.TryParse(input, out var n)) return false;

            return int.Parse(input) > 0;
        }

        public bool IsCoordinateResponseValid(string input, int maxGridInputSize)
        {
            if (input.ToLower() == "q")
            {
                return true;
            }

            if (!int.TryParse(input, out var n)) return false;

            return int.Parse(input) >= 0 && int.Parse(input) <= maxGridInputSize;
        }

        public bool IsAddMoreLiveCellsResponseValid(string input)
        {
            return input.ToLower() == "q" || input.ToLower() == "y" ||input.ToLower() == "n";
        }
    }
}