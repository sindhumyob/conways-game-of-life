using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.NextGenerationCreation;
using Xunit;

namespace ConwaysGameOfLifeTests.NextGenerationCreationTests
{
    public class CellTransitionShould
    {
        private readonly CellTransition _cellTransition;

        public CellTransitionShould()
        {
            _cellTransition = new CellTransition();
        }

        [Fact]
        public void Return_True_When_ConditionsForLiving_Are_Met_For_LiveCell_With_TwoLiveNeighbours()
        {
            var cellAndNeighbours = new[,]
            {
                {CellType.Dead, CellType.Dead, CellType.Live},
                {CellType.Dead, CellType.Live, CellType.Live},
                {CellType.Dead, CellType.Dead, CellType.Dead}
            };

            Assert.True(_cellTransition.IsCellLive(cellAndNeighbours));
        }

        [Fact]
        public void Return_True_When_ConditionsForLiving_Are_Met_For_LiveCell_With_ThreeLiveNeighbours()
        {
            var cellAndNeighbours = new[,]
            {
                {CellType.Dead, CellType.Dead, CellType.Live},
                {CellType.Dead, CellType.Live, CellType.Live},
                {CellType.Dead, CellType.Live, CellType.Dead}
            };

            Assert.True(_cellTransition.IsCellLive(cellAndNeighbours));
        }

        [Fact]
        public void Return_True_When_ConditionsForLiving_Are_Met_For_DeadCell_With_ThreeLiveNeighbours()
        {
            var cellAndNeighbours = new[,]
            {
                {CellType.Dead, CellType.Dead, CellType.Live},
                {CellType.Dead, CellType.Dead, CellType.Live},
                {CellType.Dead, CellType.Live, CellType.Dead}
            };

            Assert.True(_cellTransition.IsCellLive(cellAndNeighbours));
        }

        [Fact]
        public void Return_False_When_ConditionsForOverpopulation_Are_Met_For_LiveCell()
        {
            var cellAndNeighbours = new[,]
            {
                {CellType.Dead, CellType.Dead, CellType.Live},
                {CellType.Dead, CellType.Live, CellType.Live},
                {CellType.Live, CellType.Live, CellType.Dead}
            };

            Assert.False(_cellTransition.IsCellLive(cellAndNeighbours));
        }

        [Fact]
        public void Return_False_When_ConditionsForUnderpopulation_Are_Met_For_LiveCell()
        {
            var cellAndNeighbours = new[,]
            {
                {CellType.Dead, CellType.Dead, CellType.Dead},
                {CellType.Dead, CellType.Live, CellType.Dead},
                {CellType.Live, CellType.Dead, CellType.Dead}
            };

            Assert.False(_cellTransition.IsCellLive(cellAndNeighbours));
        }

        [Fact]
        public void Return_False_When_ConditionsForLiving_Are_Not_Met_For_DeadCell_With_LessThanThree_LiveNeighbours()
        {
            var cellAndNeighbours = new[,]
            {
                {CellType.Dead, CellType.Dead, CellType.Live},
                {CellType.Dead, CellType.Dead, CellType.Live},
                {CellType.Dead, CellType.Dead, CellType.Dead}
            };

            Assert.False(_cellTransition.IsCellLive(cellAndNeighbours));
        }

        [Fact]
        public void Return_False_When_ConditionsForLiving_Are_Not_Met_For_DeadCell_With_MoreThanThree_LiveNeighbours()
        {
            var cellAndNeighbours = new[,]
            {
                {CellType.Dead, CellType.Dead, CellType.Live},
                {CellType.Dead, CellType.Dead, CellType.Live},
                {CellType.Live, CellType.Live, CellType.Dead}
            };

            Assert.False(_cellTransition.IsCellLive(cellAndNeighbours));
        }
    }
}