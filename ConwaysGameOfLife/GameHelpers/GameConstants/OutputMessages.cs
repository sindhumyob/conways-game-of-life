namespace ConwaysGameOfLife.GameHelpers.GameConstants
{
    public static class OutputMessages
    {
        public const string Welcome = "Welcome to Conway's Game of Life!\n";

        public const string EnterGridHeight = "Please enter the height of your game grid or quit the game with 'q': ";

        public const string EnterGridWidth = "Please enter the width of your game grid or quit the game with 'q': ";

        public const string InvalidGridSize =
            "Please enter a valid grid size input consisting of a single positive whole number\n";

        public const string InvalidCoordinate = "Please enter a valid coordinate input\n";

        public const string AddInitialSeed = "It's now time to add the seed of the system:\n";

        public const string AddMoreLiveCells =
            "Would you like to add more live cells? 'y' or start the game with 'n' or quit the game with 'q': ";

        public const string InvalidAddMoreLiveCells =
            "Please enter a valid input consisting of either 'y' for adding more cells or 'n' for starting game or 'q' for quitting\n";

        public const string InvalidSeeMoreGenerations =
            "Please enter a valid input consisting of either 'y' for seeing more generations or 'n' or 'q' for quitting\n";

        public const string PrintGameEnd = "Thanks for Playing!";

        public const string PrintSeeNextGeneration =
            "Would you like to see the next generation? 'y' or quit the game with 'n' or 'q': ";

        public const string PrintNextGeneration = "Here's the next generation:\n";


        public const string PrintGrid = "Perfect, here is the grid:\n";

        public const string EnterXCoordinateOfCell =
            "Please enter the X coordinate of the cell in the seed between 1 and max grid height or quit the game with 'q': ";

        public const string EnterYCoordinateOfCell =
            "Please enter the Y coordinate of the cell in the seed between 1 and max grid width or quit the game with 'q': ";
    }
}