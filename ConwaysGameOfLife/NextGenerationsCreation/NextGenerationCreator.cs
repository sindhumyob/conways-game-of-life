using System.Collections.Generic;
using ConwaysGameOfLife.CellNeighboursGeneration;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.PlayGameOfLife;

namespace ConwaysGameOfLife.NextGenerationsCreation
{
    public class NextGenerationCreator
    {
        private readonly CellNeighboursGenerator _cellNeighboursGenerator;
        private readonly CellTransitionChecker _cellTransitionChecker;

        public NextGenerationCreator()
        {
            _cellNeighboursGenerator = new CellNeighboursGenerator();
            _cellTransitionChecker = new CellTransitionChecker();
        }

        public void CreateNextGeneration(GameGrid gameGrid)
        {
            var liveCellCoordinates = new List<Coordinate>();
            var deadCellCoordinates = new List<Coordinate>();
            for (var i = 0; i < gameGrid.CurrentGameGrid.GetLength(0); i++)
            {
                for (var j = 0; j < gameGrid.CurrentGameGrid.GetLength(1); j++)
                {
                    var currentCellCoordinates = new Coordinate {X = i, Y = j};
                    var cellAndNeighbours = _cellNeighboursGenerator.GetCellNeighbours(gameGrid, currentCellCoordinates);

                    if (_cellTransitionChecker.IsCellLive(cellAndNeighbours))
                    {
                        liveCellCoordinates.Add(currentCellCoordinates);
                    }
                    else
                    {
                        deadCellCoordinates.Add(currentCellCoordinates);
                    }
                }
            }

            gameGrid.UpdateGameGridCells(liveCellCoordinates, CellType.Live);
            gameGrid.UpdateGameGridCells(deadCellCoordinates, CellType.Dead);
        }
    }
}