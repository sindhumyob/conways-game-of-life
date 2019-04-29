using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GameHelpers.GameConstants;
using ConwaysGameOfLife.GameHelpers.GameConstants.InputConstants;
using ConwaysGameOfLife.GameInput;
using Xunit;

namespace ConwaysGameOfLifeTests.GameInputTests
{
    public class InputValidatorShould
    {
        private readonly InputValidator _inputValidator;

        public InputValidatorShould()
        {
            _inputValidator = new InputValidator();
        }

        [Theory]
        [InlineData("100")]
        [InlineData("8")]
        [InlineData("3")]
        [InlineData("q")]
        [InlineData("Q")]
        public void Return_True_When_GridSizeResponse_Is_Valid(string input)
        {
            var returned =
                _inputValidator.IsGridSetUpInputValid(input, GridConstants.MinGridSize, GridConstants.MaxGridSize);
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
        public void Return_False_When_GridSizeResponse_Is_NotValid(string input)
        {
            var returned =
                _inputValidator.IsGridSetUpInputValid(input, GridConstants.MinGridSize, GridConstants.MaxGridSize);
            Assert.False(returned);
        }

        [Theory]
        [InlineData("3")]
        [InlineData("1")]
        [InlineData("15")]
        [InlineData("q")]
        public void Return_True_When_InputCoordinate_For_LiveCell_Is_Valid(string input)
        {
            var maxCoordinateValue = 15;
            var returned =
                _inputValidator.IsGridSetUpInputValid(input, GridConstants.MinCoordinateValue, maxCoordinateValue);
            Assert.True(returned);
        }

        [Theory]
        [InlineData("")]
        [InlineData("-15")]
        [InlineData("16")]
        [InlineData("0")]
        [InlineData("quit")]
        [InlineData("$%#$#")]
        public void Return_False_When_InputCoordinate_For_LiveCell_Is_NotValid(string input)
        {
            var maxCoordinateValue = 15;
            var returned =
                _inputValidator.IsGridSetUpInputValid(input, GridConstants.MinCoordinateValue, maxCoordinateValue);
            Assert.False(returned);
        }

        [Theory]
        [InlineData("y")]
        [InlineData("n")]
        [InlineData("Y")]
        [InlineData("N")]
        [InlineData("q")]
        [InlineData("Q")]
        public void Return_True_When_ContinueGameInput_Is_Valid(string input)
        {
            var returned = _inputValidator.IsContinueGameInputValid(input);
            Assert.True(returned);
        }

        [Theory]
        [InlineData("")]
        [InlineData("Yes")]
        [InlineData("no")]
        [InlineData("quit")]
        [InlineData("$%#$#")]
        [InlineData("3")]
        public void Return_False_When_ContinueGameInput_Is_NotValid(string input)
        {
            var returned = _inputValidator.IsContinueGameInputValid(input);
            Assert.False(returned);
        }
    }
}