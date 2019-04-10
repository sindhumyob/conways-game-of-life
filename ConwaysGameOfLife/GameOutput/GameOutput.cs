using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class GameOutput
    {
        public string WelcomeMessage()
        {
            return "Welcome to Conway's Game of Life!\n";
        }

        public string EnterGridHeightMessage()
        {
            return "Please enter the height of your game grid or quit the game with 'q': ";
        }

        public string EnterGridWidthMessage()
        {
            return "Please enter the width of your game grid or quit the game with 'q': ";
        }

        public string InvalidGridSizeMessage()
        {
            return "Please enter a valid grid size input consisting of a single positive whole number\n";
        }

        public string PrintGridMessage(char[,] grid)
        {
            return "Perfect, here is the grid:\n" + PrintGrid(grid);
        }

        public string InvalidCoordinateMessage(int maxSizeOfCoordinate)
        {
            return "Please enter a valid coordinate input consisting of a number between 1 and " + maxSizeOfCoordinate +
                   "\n";
        }

        public string AddInitialSeedMessage()
        {
            return "It's now time to add the seed of the system:\n";
        }

        public string EnterXCoordinateOfCellMessage(int maxSizeOfCoordinate)
        {
            return "Please enter the x coordinate between 1-" + maxSizeOfCoordinate + " of the cell in the seed or quit the game with 'q': ";
        }

        public string EnterYCoordinateOfCellMessage(int maxSizeOfCoordinate)
        {
            return "Please enter the y coordinate between 1-" + maxSizeOfCoordinate + " of the cell in the seed or quit the game with 'q': ";
        }

        public string AddMoreLiveCellsMessage()
        {
            return "Would you like to add more live cells? (y/n) or quit the game with 'q': ";
        }

        public string InvalidAddMoreLiveCellsMessage()
        {
            return
                "Please enter a valid input consisting of either 'y' for adding more cells or 'n' for starting game or 'q' for quitting\n";
        }

        public string StartingGameOfLifeMessage()
        {
            return "It's now time to start the game of life!\n";
        }

        public string PrintNextGenerationGridMessage(char[,] grid)
        {
            return "Here's the next generation:\n" + PrintGrid(grid);
        }

        private string PrintGrid(char[,] initialGrid)
        {
            var output = new List<string>();
            var line = string.Empty;
            for (var i = 0; i < initialGrid.GetLength(0); i++)
            {
                for (var j = 0; j < initialGrid.GetLength(1); j++)
                {
                    line += initialGrid[i, j] + " ";
                }

                output.Add(line);
                line = string.Empty;
            }

            return string.Join("\n", output) + "\n";
        }
    }
}