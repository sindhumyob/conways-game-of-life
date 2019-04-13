namespace ConwaysGameOfLife
{
    public class CellNeighboursCoordinatesGenerator
    {
        public int[,] GetGridTopLeftCornerOverlapCoordinates(int maxRowCoord, int maxColumnCoord, int rowCoord, int colCoord)
        {
            return new [,]
            {
                {maxRowCoord, maxColumnCoord}, {maxRowCoord, colCoord},
                {maxRowCoord, colCoord + 1}, {rowCoord, maxColumnCoord}, {rowCoord, colCoord},
                {rowCoord, colCoord + 1}, {rowCoord + 1, maxColumnCoord}, {rowCoord + 1, colCoord}, {rowCoord + 1, colCoord + 1}
            };
        }
        
        public int[,] GetGridTopRightCornerOverlapCoordinates(int maxRowCoord, int maxColumnCoord, int rowCoord, int colCoord)
        {
            return new [,]
            {
                {maxRowCoord, colCoord - 1}, {maxRowCoord, colCoord},
                {maxRowCoord, 0}, {rowCoord, colCoord - 1}, {rowCoord, colCoord},
                {rowCoord, maxColumnCoord}, {rowCoord + 1, colCoord - 1}, {rowCoord + 1, colCoord}, {rowCoord + 1, 0}
            };
        }
        
        public int[,] GetGridBottomLeftCornerOverlapCoordinates(int maxColumnCoord, int rowCoord, int colCoord)
        {
            return new [,]
            {
                {rowCoord - 1, maxColumnCoord}, {rowCoord - 1, colCoord}, {rowCoord - 1, colCoord + 1},
                {rowCoord, maxColumnCoord}, {rowCoord, colCoord},
                {rowCoord, colCoord + 1}, {0, maxColumnCoord}, {0, colCoord}, {0, colCoord + 1}
            };
        }
        
        public int[,] GetGridBottomRightCornerOverlapCoordinates(int rowCoord, int colCoord)
        {
            return new [,]
            {
                {rowCoord - 1, colCoord - 1}, {rowCoord - 1, colCoord}, {rowCoord - 1, 0}, {rowCoord, colCoord - 1}, {rowCoord, colCoord},
                {rowCoord, 0}, {0, colCoord - 1}, {0, colCoord}, {0, 0}
            };
        }
        public int[,] GetGridTopOverlapCoordinates(int maxRowCoord, int rowCoord, int colCoord)
        {
            return new [,]
            {
                {maxRowCoord, colCoord - 1}, {maxRowCoord, colCoord},
                {maxRowCoord, colCoord + 1}, {rowCoord, colCoord - 1}, {rowCoord, colCoord},
                {rowCoord, colCoord + 1}, {rowCoord + 1, colCoord - 1}, {rowCoord + 1, colCoord}, {rowCoord + 1, colCoord + 1}
            };
        }
        
        public int[,] GetGridBottomOverlapCoordinates(int rowCoord, int colCoord)
        {
            return new [,]
            {
                {rowCoord - 1, colCoord - 1}, {rowCoord - 1, colCoord}, {rowCoord - 1, colCoord + 1}, {rowCoord, colCoord - 1}, {rowCoord, colCoord},
                {rowCoord, colCoord + 1}, {0, colCoord - 1}, {0, colCoord}, {0, colCoord + 1}
            };
        }
        
        public int[,] GetGridLeftOverlapCoordinates(int maxColumnCoord, int rowCoord, int colCoord)
        {
            return new [,]
            {
                {rowCoord - 1, maxColumnCoord}, {rowCoord - 1, colCoord}, {rowCoord - 1, colCoord + 1},
                {rowCoord, maxColumnCoord}, {rowCoord, colCoord},
                {rowCoord, colCoord + 1}, {rowCoord + 1, maxColumnCoord}, {rowCoord + 1, colCoord}, {rowCoord + 1, colCoord + 1}
            };
        }
        
        public int[,] GetGridRightOverlapCoordinates(int rowCoord, int colCoord)
        {
            return new [,]
            {
                {rowCoord - 1, colCoord - 1}, {rowCoord - 1, colCoord}, {rowCoord - 1, 0}, {rowCoord, colCoord - 1}, {rowCoord, colCoord},
                {rowCoord, 0}, {rowCoord + 1, colCoord - 1}, {rowCoord + 1, colCoord}, {rowCoord + 1, 0}
            };
        }
        
        public int[,] GetGridNoOverlapCoordinates(int rowCoord, int colCoord)
        {
            return new [,]
            {
                {rowCoord - 1, colCoord - 1}, {rowCoord - 1, colCoord}, {rowCoord - 1, colCoord + 1}, {rowCoord, colCoord - 1}, {rowCoord, colCoord},
                {rowCoord, colCoord + 1}, {rowCoord + 1, colCoord - 1}, {rowCoord + 1, colCoord}, {rowCoord + 1, colCoord + 1}
            };
        }
        
        
    }
}