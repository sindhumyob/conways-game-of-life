namespace ConwaysGameOfLife.GameHelpers.GameConstants.OutputConstants
{
    public static class Messages
    {
        public const string Welcome = "Welcome to Conway's Game of Life!\n";

        public const string EnterGridHeight = "Please enter the height of your game grid or quit the game with 'q': ";

        public const string EnterGridWidth = "Please enter the width of your game grid or quit the game with 'q': ";

        public const string InvalidGridSize =
            "Please enter a valid grid size input consisting of a single positive whole number\n";

        public const string InvalidCoordinate = "Please enter a valid coordinate input\n";

        public const string AddInitialSeed = "It's now time to add the seed of the system:\n";

        public const string AddAnotherLiveCell =
            "Would you like to add another live cell? 'y' or start the game with 'n' or quit the game with 'q': ";

        public const string InvalidAddAnotherLiveCell =
            "Please enter a valid input consisting of either 'y' for adding another cell or 'n' for starting game or 'q' for quitting\n";

        public const string InvalidSeeNextGeneration =
            "Please enter a valid input consisting of either 'y' for seeing next generation or 'n' or 'q' for quitting\n";

        public const string GameEnd = "Thanks for Playing!";

        public const string SeeNextGeneration =
            "Would you like to see the next generation? 'y' or quit the game with 'n' or 'q': ";

        public const string NextGeneration = "Here's the next generation:\n";


        public const string SeeGrid = "Perfect, here is the grid:\n";

        public const string EnterXCoordinate =
            "Please enter the X coordinate of the cell in the seed between 1 and max grid height or quit the game with 'q': ";

        public const string EnterYCoordinate =
            "Please enter the Y coordinate of the cell in the seed between 1 and max grid width or quit the game with 'q': ";
    }
}