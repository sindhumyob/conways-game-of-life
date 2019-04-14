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

        public Coordinate[] GenerateCornerOverlapCoordinates(int rowCoord, int colCoord, int maxRowCoord,
            int maxColumnCoord)
        {
            var neighboursCoordinates = new Coordinate[] { };
            if (rowCoord == 0 && colCoord == 0)
            {
                neighboursCoordinates = _cornersOverlapCoordinates.GetGridTopLeftCornerOverlapCoordinates(maxRowCoord,
                    maxColumnCoord, rowCoord, colCoord);
            }
            else if (rowCoord == 0 && colCoord == maxColumnCoord)
            {
                neighboursCoordinates = _cornersOverlapCoordinates.GetGridTopRightCornerOverlapCoordinates(
                    maxRowCoord, maxColumnCoord, rowCoord, colCoord);
            }
            else if (rowCoord == maxRowCoord && colCoord == 0)
            {
                neighboursCoordinates = _cornersOverlapCoordinates.GetGridBottomLeftCornerOverlapCoordinates(
                    maxColumnCoord, rowCoord, colCoord);
            }
            else if (rowCoord == maxRowCoord && colCoord == maxColumnCoord)
            {
                neighboursCoordinates =
                    _cornersOverlapCoordinates.GetGridBottomRightCornerOverlapCoordinates(rowCoord, colCoord);
            }

            return neighboursCoordinates;
        }

        public Coordinate[] GenerateBordersOverlapCoordinates(int rowCoord, int colCoord, int maxRowCoord,
            int maxColumnCoord)
        {
            var neighboursCoordinates = new Coordinate[] { };
            if (rowCoord == 0)
            {
                neighboursCoordinates = _bordersOverlapCoordinates.GetGridTopOverlapCoordinates(maxRowCoord, rowCoord,
                    colCoord);
            }
            else if (rowCoord == maxRowCoord)
            {
                neighboursCoordinates = _bordersOverlapCoordinates.GetGridBottomOverlapCoordinates(rowCoord, colCoord);
            }
            else if (colCoord == 0)
            {
                neighboursCoordinates = _bordersOverlapCoordinates.GetGridLeftOverlapCoordinates(maxColumnCoord,
                    rowCoord, colCoord);
            }
            else if (colCoord == maxColumnCoord)
            {
                neighboursCoordinates = _bordersOverlapCoordinates.GetGridRightOverlapCoordinates(rowCoord, colCoord);
            }

            return neighboursCoordinates;
        }

        public Coordinate[] GenerateNoOverlapCoordinates(int rowCoord, int colCoord)
        {
            return _noOverlapCoordinates.GetGridNoOverlapCoordinates(rowCoord, colCoord);
        }
    }
}