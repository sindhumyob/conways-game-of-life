namespace ConwaysGameOfLife.GameHelpers.GameConstants
{
    public static class OutputMessages
    {
        public static string Welcome => "Welcome to Conway's Game of Life!\n";

        public static string EnterGridHeight => "Please enter the height of your game grid or quit the game with 'q': ";

        public static string EnterGridWidth => "Please enter the width of your game grid or quit the game with 'q': ";

        public static string InvalidGridSize =>
            "Please enter a valid grid size input consisting of a single positive whole number\n";

        public static string InvalidCoordinate => "Please enter a valid coordinate input\n";

        public static string AddInitialSeed => "It's now time to add the seed of the system:\n";

        public static string AddMoreLiveCells =>
            "Would you like to add more live cells? (y/n) or quit the game with 'q': ";

        public static string InvalidAddMoreLiveCells =>
            "Please enter a valid input consisting of either 'y' for adding more cells or 'n' for starting game or 'q' for quitting\n";

        public static string InvalidSeeMoreGenerations =>
            "Please enter a valid input consisting of either 'y' for seeing more generations or 'n' or 'q' for quitting\n";

        public static string StartingGameOfLife => "It's now time to start the game of life!\n";

        public static string PrintGameEnd => "Thanks for Playing!";

        public static string PrintSeeNextGeneration =>
            "Would you like to see the next generation? 'y' or quit the game with 'n' or 'q': ";

        public static string PrintNextGeneration => "Here's the next generation:\n";


        public static string PrintGrid => "Perfect, here is the grid:\n";

        public static string EnterXCoordinateOfCell =>
            "Please enter the X coordinate of the cell in the seed between 1 and max grid height or quit the game with 'q': ";

        public static string EnterYCoordinateOfCell =>
            "Please enter the Y coordinate of the cell in the seed between 1 and max grid width or quit the game with 'q': ";
    }
}