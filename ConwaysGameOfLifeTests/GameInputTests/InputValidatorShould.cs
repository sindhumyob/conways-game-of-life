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
        [InlineData("10")]
        [InlineData("8")]
        [InlineData("q")]
        public void Return_True_When_Grid_Size_Response_Is_Valid(string input)
        {
            var returned = _inputValidator.IsGridSizeResponseValid(input);
            Assert.True(returned);
        }
    }
}