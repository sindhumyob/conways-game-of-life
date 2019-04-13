using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class PlayGameOfLife
    {
        private readonly GameOutput _gameOutput;
        private readonly CellNeighboursGenerator _cellNeighboursGenerator;
        private readonly Transitions _transitions;

        public PlayGameOfLife()
        {
            _gameOutput = new GameOutput();
            _cellNeighboursGenerator = new CellNeighboursGenerator();
            _transitions = new Transitions();
        }

        public string PlayGame(Universe universe)
        {
            GetNextTransition(universe);
            return _gameOutput.PrintNextGenerationGridMessage(universe.CurrentGameGrid);
        }

        public void GetNextTransition(Universe universe)
        {
            var liveCells = new List<Coordinate>();
            var deadCells = new List<Coordinate>();
            for (var i = 0; i < universe.CurrentGameGrid.GetLength(0); i++)
            {
                for (var j = 0; j < universe.CurrentGameGrid.GetLength(1); j++)
                {
                    var neighbours = _cellNeighboursGenerator.GenerateCellNeighbours(universe.CurrentGameGrid,
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

            universe.UpdateGameGridCells(liveCells, CellType.Live);
            universe.UpdateGameGridCells(deadCells, CellType.Dead);
        }
    }
}