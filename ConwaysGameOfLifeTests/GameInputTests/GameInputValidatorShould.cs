using ConwaysGameOfLife.GameInput;
using Xunit;

namespace ConwaysGameOfLifeTests.GameInputTests
{
    public class GameInputValidatorShould
    {
        private readonly GameInputValidator _gameInputValidator;

        public GameInputValidatorShould()
        {
            _gameInputValidator = new GameInputValidator();
        }

        [Theory]
        [InlineData("100")]
        [InlineData("8")]
        [InlineData("3")]
        [InlineData("q")]
        [InlineData("Q")]
        public void Return_True_When_Grid_Size_Response_Is_Valid(string input)
        {
            var returned = _gameInputValidator.IsGridSizeResponseValid(input);
            Assert.True(returned);
        }

        [Theory]
        [InlineData("")]
        [InlineData("-50")]
        [InlineData("0")]
        [InlineData("2")]
        [InlineData("101")]
        [InlineData("quit")]
        [InlineData("$%#$#")]
        public void Return_False_When_Grid_Size_Response_Is_Not_Valid(string input)
        {
            var returned = _gameInputValidator.IsGridSizeResponseValid(input);
            Assert.False(returned);
        }

        [Theory]
        [InlineData("3")]
        [InlineData("1")]
        [InlineData("15")]
        [InlineData("q")]
        public void Return_True_When_Input_Coordinate_For_Cell_In_Seed_Is_Valid(string input)
        {
            var maxCoordinateValue = 15;
            var returned = _gameInputValidator.IsCoordinateResponseValid(input, maxCoordinateValue);
            Assert.True(returned);
        }

        [Theory]
        [InlineData("")]
        [InlineData("-15")]
        [InlineData("16")]
        [InlineData("0")]
        [InlineData("quit")]
        [InlineData("$%#$#")]
        public void Return_False_When_Input_Coordinate_For_Cell_In_Seed_Is_Not_Valid(string input)
        {
            var maxCoordinateValue = 15;
            var returned = _gameInputValidator.IsCoordinateResponseValid(input, maxCoordinateValue);
            Assert.False(returned);
        }

        [Theory]
        [InlineData("y")]
        [InlineData("n")]
        [InlineData("Y")]
        [InlineData("N")]
        [InlineData("q")]
        [InlineData("Q")]
        public void Return_True_When_Continue_Game_Input_Is_Valid(string input)
        {
            var returned = _gameInputValidator.IsContinueGameResponseValid(input);
            Assert.True(returned);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Yes")]
        [InlineData("no")]
        [InlineData("quit")]
        [InlineData("$%#$#")]
        [InlineData("3")]
        public void Return_False_When_Continue_Game_Input_Is_Not_Valid(string input)
        {
            var returned = _gameInputValidator.IsContinueGameResponseValid(input);
            Assert.False(returned);
        }
    }
}