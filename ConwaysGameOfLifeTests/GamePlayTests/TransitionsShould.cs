using ConwaysGameOfLife;
using ConwaysGameOfLife.GamePlayHelpers;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class TransitionsShould
    {
        private readonly Transitions _transitions;

        public TransitionsShould()
        {
            _transitions = new Transitions();
        }

        [Fact]
        public void Return_True_When_The_Conditions_For_Living_For_Next_Transition_Are_Met_For_A_Live_Cell_With_Two_Live_Neighbours()
        {
            var cellAndNeighbours = new[,]
            {
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live},
                {(char) CellType.Dead, (char) CellType.Live, (char) CellType.Live},
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead}
            };
            
            Assert.True(_transitions.IsCellLive(cellAndNeighbours));
        }
        
        [Fact]
        public void Return_True_When_The_Conditions_For_Living_For_Next_Transition_Are_Met_For_A_Live_Cell_With_Three_Live_Neighbours()
        {
            var cellAndNeighbours = new[,]
            {
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live},
                {(char) CellType.Dead, (char) CellType.Live, (char) CellType.Live},
                {(char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead}
            };
            
            Assert.True(_transitions.IsCellLive(cellAndNeighbours));
        }
        
        [Fact]
        public void Return_True_When_The_Conditions_For_Living_For_Next_Transition_Are_Met_For_A_Dead_Cell_With_Three_Live_Neighbours()
        {
            var cellAndNeighbours = new[,]
            {
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live},
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live},
                {(char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead}
            };
            
            Assert.True(_transitions.IsCellLive(cellAndNeighbours));
        }
        
        [Fact]
        public void Return_False_Stating_That_Cell_Will_Be_Dead_In_Next_Transition_When_Conditions_For_Overpopulation_Exist_For_Live_Cell()
        {
            var cellAndNeighbours = new[,]
            {
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live},
                {(char) CellType.Dead, (char) CellType.Live, (char) CellType.Live},
                {(char) CellType.Live, (char) CellType.Live, (char) CellType.Dead}
            };
            
            Assert.False(_transitions.IsCellLive(cellAndNeighbours));
        }
        
        [Fact]
        public void Return_False_Stating_That_Cell_Will_Be_Dead_In_Next_Transition_When_Conditions_For_Underpopulation_Exist_For_Live_Cell()
        {
            var cellAndNeighbours = new[,]
            {
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead},
                {(char) CellType.Dead, (char) CellType.Live, (char) CellType.Dead},
                {(char) CellType.Live, (char) CellType.Dead, (char) CellType.Dead}
            };
            
            Assert.False(_transitions.IsCellLive(cellAndNeighbours));
        }
        
        [Fact]
        public void Return_False_When_The_Conditions_For_Living_For_Next_Transition_Are_Not_Met_For_A_Dead_Cell_With_Less_Than_Three_Live_Neighbours()
        {
            var cellAndNeighbours = new[,]
            {
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live},
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live},
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Dead}
            };
            
            Assert.False(_transitions.IsCellLive(cellAndNeighbours));
        }
        
        [Fact]
        public void Return_False_When_The_Conditions_For_Living_For_Next_Transition_Are_Not_Met_For_A_Dead_Cell_With_More_Than_Three_Live_Neighbours()
        {
            var cellAndNeighbours = new[,]
            {
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live},
                {(char) CellType.Dead, (char) CellType.Dead, (char) CellType.Live},
                {(char) CellType.Live, (char) CellType.Live, (char) CellType.Dead}
            };
            
            Assert.False(_transitions.IsCellLive(cellAndNeighbours));
        }
    }
}