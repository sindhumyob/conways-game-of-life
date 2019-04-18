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
                    var neighbours = _cellNeighboursGenerator.GenerateCellNeighbours(gameGrid,
                        new Coordinate() {X = i, Y = j});

                    if (_cellTransitionChecker.IsCellLive(neighbours))
                    {
                        liveCellCoordinates.Add(new Coordinate {X = i, Y = j});
                    }
                    else
                    {
                        deadCellCoordinates.Add(new Coordinate {X = i, Y = j});
                    }
                }
            }

            gameGrid.UpdateGameGridCells(liveCellCoordinates, CellType.Live);
            gameGrid.UpdateGameGridCells(deadCellCoordinates, CellType.Dead);
        }
    }
}