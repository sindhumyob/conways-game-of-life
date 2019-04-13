using ConwaysGameOfLife.GameInput;
using Xunit;

namespace ConwaysGameOfLifeTests
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
        public void Return_True_When_Grid_Size_Response_Is_Valid(string input)
        {
            var returned = _inputValidator.IsGridSizeResponseValid(input);
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
            var returned = _inputValidator.IsGridSizeResponseValid(input);
            Assert.False(returned);
        }
        
        [Theory]
        [InlineData("3")]
        [InlineData("1")]
        [InlineData("15")]
        [InlineData("q")]
        public void Return_True_When_Input_Coordinate_For_Cell_Is_Valid(string input)
        {
            var maxGridInputSize = 15;
            var returned = _inputValidator.IsCoordinateResponseValid(input, maxGridInputSize);
            Assert.True(returned);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("-15")]
        [InlineData("16")]
        [InlineData("0")]
        [InlineData("quit")]
        [InlineData("$%#$#")]
        public void Return_False_When_Input_Coordinate_For_Cell_Is_Not_Valid(string input)
        {
            var maxGridInputSize = 15;
            var returned = _inputValidator.IsCoordinateResponseValid(input, maxGridInputSize);
            Assert.False(returned);
        }
        
        [Theory]
        [InlineData("y")]
        [InlineData("n")]
        [InlineData("Y")]
        [InlineData("N")]
        [InlineData("q")]
        [InlineData("Q")]
        public void Return_True_When_Adding_More_Live_Cells_Input_Is_Valid(string input)
        {
            var returned = _inputValidator.IsContinueGameResponseValid(input);
            Assert.True(returned);
        }
        
        [Theory]
        [InlineData("")]
        [InlineData("Yes")]
        [InlineData("no")]
        [InlineData("quit")]
        [InlineData("$%#$#")]
        [InlineData("3")]
        public void Return_False_When_Adding_More_Live_Cells_Input_Is_Not_Valid(string input)
        {
            var returned = _inputValidator.IsContinueGameResponseValid(input);
            Assert.False(returned);
        }
    }
}