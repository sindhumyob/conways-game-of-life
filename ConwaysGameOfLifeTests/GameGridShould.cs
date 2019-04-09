using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class GameGridShould
    {
        private readonly GameGrid _gameGrid;

        public GameGridShould()
        {
            _gameGrid = new GameGrid();
        }

        [Fact]
        public void Generate_Game_Grid_With_Dimensions_That_Resembles_Input_Grid_Size()
        {
            var heightOfGrid = 10;
            var widthOfGrid = 10;

            _gameGrid.GenerateGrid(heightOfGrid, widthOfGrid);
            
            var expectedGrid = new[,] {
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-', '-', '-', '-', '-', '-'},
            };
            
            Assert.Equal(expectedGrid, _gameGrid.CurrentGameGrid);
        }
    }
}