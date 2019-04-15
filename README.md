# Conway's Game of Life - Quorum Review

From the original Conway's Game of Life kata written by Mark (https://github.com/MYOB-Technology/General_Developer/blob/master/katas/kata-conways-game-of-life/kata-conways-game-of-life.md):

The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970.

The "game" is a zero-player game, meaning that its evolution is determined by its initial state, requiring no further input. One interacts with the Game of Life by creating an initial configuration and observing how it evolves.

# Rules

The universe of the Game of Life is a two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, live or dead. Every cell interacts with its eight neighbors, which are the cells that are directly horizontally, vertically, or diagonally adjacent.

If the cell is on the fringe of the grid it laps over to the other side:



At each step in time, the following transitions occur:

* Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
* Any live cell with more than three live neighbours dies, as if by overcrowding.
* Any live cell with two or three live neighbours lives on to the next generation.
* Any dead cell with exactly three live neighbours becomes a live cell.

The initial pattern constitutes the seed of the system. The first generation is created by applying the above rules simultaneously to every cell in the seed. Births and deaths happen simultaneously, and the discrete moment at which this happens is sometimes called a tick. The rules continue to be applied repeatedly to create further generations.

# Task
* Visualize the game (you can decide in what medium)
* Be able to define how big the world/grid is (10x10, 50x80, etc.)
* Be able to set the inital state of the world

# My Requirements
* It is a console version of the game
* The minimum grid height and width is 3 and the maximum grid height and width is 100. (ie. minimum grid size is 3x3 and maximum grid size is 100x100)
