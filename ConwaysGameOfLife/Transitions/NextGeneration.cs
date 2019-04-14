using System.Collections.Generic;
using ConwaysGameOfLife.CellNeighboursGeneration;
using ConwaysGameOfLife.GamePlayHelpers;

namespace ConwaysGameOfLife.GamePlay
{
    public class NextGeneration
    {
        private readonly CellNeighboursGenerator _cellNeighboursGenerator;
        private readonly Transitions _transitions;

        public NextGeneration()
        {
            _cellNeighboursGenerator = new CellNeighboursGenerator();
            _transitions = new Transitions();
        }

        public void GetNextGeneration(GameGrid gameGrid)
        {
            var liveCells = new List<Coordinate>();
            var deadCells = new List<Coordinate>();
            for (var i = 0; i < gameGrid.CurrentGameGrid.GetLength(0); i++)
            {
                for (var j = 0; j < gameGrid.CurrentGameGrid.GetLength(1); j++)
                {
                    var neighbours = _cellNeighboursGenerator.GenerateCellNeighbours(gameGrid.CurrentGameGrid,
                        new Coordinate() {XCoordinate = i, YCoordinate = j});


                    if (_transitions.IsCellLive(neighbours))
                    {
                        liveCells.Add(new Coordinate() {XCoordinate = i, YCoordinate = j});
                    }
                    else
                    {
                        deadCells.Add(new Coordinate() {XCoordinate = i, YCoordinate = j});
                    }
                }
            }

            gameGrid.UpdateGameGridCells(liveCells, CellType.Live);
            gameGrid.UpdateGameGridCells(deadCells, CellType.Dead);
        }
    }
}