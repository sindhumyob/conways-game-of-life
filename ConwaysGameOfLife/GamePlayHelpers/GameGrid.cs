namespace ConwaysGameOfLife
{
    public class GameGrid
    {
        public char[,] CurrentGameGrid { get; set; }
        
        public void GenerateGrid(int heightOfGrid, int widthOfGrid)
        {
            CurrentGameGrid = new char[heightOfGrid,widthOfGrid];
            
            for (var i = 0; i < CurrentGameGrid.GetLength(0); i++)
            {
                for (var j = 0; j < CurrentGameGrid.GetLength(1); j++)
                {
                    CurrentGameGrid[i, j] = '-';
                }
            }
        }
    }
}