using System.Collections.Generic;
using ConwaysGameOfLife.CellNeighboursGeneration;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.PlayGameOfLife;

namespace ConwaysGameOfLife.NextGenerationCreation
{
    public class NextGeneration
    {
        private readonly CellNeighbours _cellNeighbours;
        private readonly CellTransition _cellTransition;

        public NextGeneration()
        {
            _cellNeighbours = new CellNeighbours();
            _cellTransition = new CellTransition();
        }

        public void CreateGeneration(GameGrid gameGrid)
        {
            var liveCellCoordinates = new List<Coordinate>();
            var deadCellCoordinates = new List<Coordinate>();
            for (var i = 0; i < gameGrid.CurrentGameGrid.GetLength(0); i++)
            {
                for (var j = 0; j < gameGrid.CurrentGameGrid.GetLength(1); j++)
                {
                    var currentCellCoordinates = new Coordinate {X = i, Y = j};
                    var cellAndNeighbours = _cellNeighbours.GetNeighbours(gameGrid, currentCellCoordinates);

                    if (_cellTransition.IsCellLive(cellAndNeighbours))
                    {
                        liveCellCoordinates.Add(currentCellCoordinates);
                    }
                    else
                    {
                        deadCellCoordinates.Add(currentCellCoordinates);
                    }
                }
            }

            gameGrid.UpdateGrid(liveCellCoordinates, CellType.Live);
            gameGrid.UpdateGrid(deadCellCoordinates, CellType.Dead);
        }
    }
}