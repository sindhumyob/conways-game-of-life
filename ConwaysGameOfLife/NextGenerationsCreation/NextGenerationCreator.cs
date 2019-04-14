using System.Collections.Generic;
using ConwaysGameOfLife.CellNeighboursGeneration;
using ConwaysGameOfLife.GameHelpers;
using ConwaysGameOfLife.GamePlay;
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
                    var neighbours = _cellNeighboursGenerator.GenerateCellNeighbours(gameGrid.CurrentGameGrid,
                        new Coordinate() {XCoordinate = i, YCoordinate = j});

                    if (_cellTransitionChecker.IsCellLive(neighbours))
                    {
                        liveCellCoordinates.Add(new Coordinate {XCoordinate = i, YCoordinate = j});
                    }
                    else
                    {
                        deadCellCoordinates.Add(new Coordinate {XCoordinate = i, YCoordinate = j});
                    }
                }
            }

            gameGrid.UpdateGameGridCells(liveCellCoordinates, CellType.Live);
            gameGrid.UpdateGameGridCells(deadCellCoordinates, CellType.Dead);
        }
    }
}