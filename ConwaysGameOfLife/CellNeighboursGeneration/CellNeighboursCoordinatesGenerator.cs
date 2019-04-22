using ConwaysGameOfLife.CellNeighboursGeneration.CellNeighboursCoordinates;
using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.CellNeighboursGeneration
{
    public class CellNeighboursCoordinatesGenerator
    {
        private readonly BordersOverlapCoordinates _bordersOverlapCoordinates;
        private readonly CornersOverlapCoordinates _cornersOverlapCoordinates;
        private readonly NoOverlapCoordinates _noOverlapCoordinates;

        public CellNeighboursCoordinatesGenerator()
        {
            _bordersOverlapCoordinates = new BordersOverlapCoordinates();
            _cornersOverlapCoordinates = new CornersOverlapCoordinates();
            _noOverlapCoordinates = new NoOverlapCoordinates();
        }

        public Coordinate[] GenerateCornerOverlapCoordinates(Coordinate cellCoordinates,
            Coordinate maxGridSizeCoordinates)
        {
            var neighboursCoordinates = new Coordinate[] { };
            if (cellCoordinates.X == 0 && cellCoordinates.Y == 0)
            {
                neighboursCoordinates =
                    _cornersOverlapCoordinates.GetGridTopLeftCornerOverlapCoordinates(cellCoordinates,
                        maxGridSizeCoordinates);
            }
            else if (cellCoordinates.X == 0 && cellCoordinates.Y == maxGridSizeCoordinates.Y)
            {
                neighboursCoordinates = _cornersOverlapCoordinates.GetGridTopRightCornerOverlapCoordinates(
                    cellCoordinates, maxGridSizeCoordinates);
            }
            else if (cellCoordinates.X == maxGridSizeCoordinates.X && cellCoordinates.Y == 0)
            {
                neighboursCoordinates = _cornersOverlapCoordinates.GetGridBottomLeftCornerOverlapCoordinates(
                    cellCoordinates, maxGridSizeCoordinates);
            }
            else if (cellCoordinates.X == maxGridSizeCoordinates.X && cellCoordinates.Y == maxGridSizeCoordinates.Y)
            {
                neighboursCoordinates =
                    _cornersOverlapCoordinates.GetGridBottomRightCornerOverlapCoordinates(cellCoordinates);
            }

            return neighboursCoordinates;
        }

        public Coordinate[] GenerateBordersOverlapCoordinates(Coordinate cellCoordinates,
            Coordinate maxGridSizeCoordinates)
        {
            var neighboursCoordinates = new Coordinate[] { };
            if (cellCoordinates.X == 0)
            {
                neighboursCoordinates =
                    _bordersOverlapCoordinates.GetGridTopOverlapCoordinates(cellCoordinates, maxGridSizeCoordinates);
            }
            else if (cellCoordinates.X == maxGridSizeCoordinates.X)
            {
                neighboursCoordinates = _bordersOverlapCoordinates.GetGridBottomOverlapCoordinates(cellCoordinates);
            }
            else if (cellCoordinates.Y == 0)
            {
                neighboursCoordinates =
                    _bordersOverlapCoordinates.GetGridLeftOverlapCoordinates(cellCoordinates, maxGridSizeCoordinates);
            }
            else if (cellCoordinates.Y == maxGridSizeCoordinates.Y)
            {
                neighboursCoordinates = _bordersOverlapCoordinates.GetGridRightOverlapCoordinates(cellCoordinates);
            }

            return neighboursCoordinates;
        }

        public Coordinate[] GenerateNoOverlapCoordinates(Coordinate cellCoordinates)
        {
            return _noOverlapCoordinates.GetGridNoOverlapCoordinates(cellCoordinates);
        }
    }
}