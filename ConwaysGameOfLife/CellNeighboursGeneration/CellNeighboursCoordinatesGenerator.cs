using ConwaysGameOfLife.CellNeighboursGeneration.CellNeighboursCoordinates;
using ConwaysGameOfLife.GameHelpers;

namespace ConwaysGameOfLife.CellNeighboursGeneration
{
    public class CellNeighboursCoordinatesGenerator
    {
        private readonly BordersOverlapCoordinates _bordersOverlapCoordinates;
        private readonly CornersOverlapCoordinates _cornersOverlapCoordinates;


        public CellNeighboursCoordinatesGenerator()
        {
            _bordersOverlapCoordinates = new BordersOverlapCoordinates();
            _cornersOverlapCoordinates = new CornersOverlapCoordinates();
        }

        public Coordinate[] GetCornerOverlapCoordinates(Coordinate cellCoordinates,
            Coordinate maxGridSizeCoordinates)
        {
            var neighboursCoordinates = new Coordinate[] { };
            if (cellCoordinates.X == 0 && cellCoordinates.Y == 0)
            {
                neighboursCoordinates =
                    _cornersOverlapCoordinates.GetTopLeftCornerOverlapCoordinates(cellCoordinates,
                        maxGridSizeCoordinates);
            }
            else if (cellCoordinates.X == 0 && cellCoordinates.Y == maxGridSizeCoordinates.Y)
            {
                neighboursCoordinates = _cornersOverlapCoordinates.GetTopRightCornerOverlapCoordinates(
                    cellCoordinates, maxGridSizeCoordinates);
            }
            else if (cellCoordinates.X == maxGridSizeCoordinates.X && cellCoordinates.Y == 0)
            {
                neighboursCoordinates = _cornersOverlapCoordinates.GetBottomLeftCornerOverlapCoordinates(
                    cellCoordinates, maxGridSizeCoordinates);
            }
            else if (cellCoordinates.X == maxGridSizeCoordinates.X && cellCoordinates.Y == maxGridSizeCoordinates.Y)
            {
                neighboursCoordinates =
                    _cornersOverlapCoordinates.GetBottomRightCornerOverlapCoordinates(cellCoordinates);
            }

            return neighboursCoordinates;
        }

        public Coordinate[] GetBordersOverlapCoordinates(Coordinate cellCoordinates,
            Coordinate maxGridSizeCoordinates)
        {
            var neighboursCoordinates = new Coordinate[] { };
            if (cellCoordinates.X == 0)
            {
                neighboursCoordinates =
                    _bordersOverlapCoordinates.GetTopOverlapCoordinates(cellCoordinates, maxGridSizeCoordinates);
            }
            else if (cellCoordinates.X == maxGridSizeCoordinates.X)
            {
                neighboursCoordinates = _bordersOverlapCoordinates.GetBottomOverlapCoordinates(cellCoordinates);
            }
            else if (cellCoordinates.Y == 0)
            {
                neighboursCoordinates =
                    _bordersOverlapCoordinates.GetLeftOverlapCoordinates(cellCoordinates, maxGridSizeCoordinates);
            }
            else if (cellCoordinates.Y == maxGridSizeCoordinates.Y)
            {
                neighboursCoordinates = _bordersOverlapCoordinates.GetRightOverlapCoordinates(cellCoordinates);
            }

            return neighboursCoordinates;
        }
    }
}