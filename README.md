
## Changes Since Last Review:
### Tests
- For feedback: Focus more on behaviour tests, rather than testing implementation
  - Removed game output messages return checking (they are now constants)
  - Removed cell neighbour generation testing since it was being tested in next generation creation
  - Added test cases to next generation creation to account for the cell neighbour generation tests being removed

### Small
- Reduced coupling between game play classes (play game, set up and play next generation) and player input and game output.
	- Moved game output logic from set up and play next generation to game player
	- Removed play next generation class and moved it’s logic into game player
	- Moved add live cell logic from game player to set up game

### Reveal intent
- For feedback: Method names that return things but no indication of them doing so
	- Renamed methods throughout the code but most significant changes are for the communication between game player and grid maker (used to be called set up game) classes. Method names reflect that they are returning a boolean for the game status
	- Created classes grid dimensions and seeding status to indicate more clearly what methods are returning
- For feedback: Renaming names so there isn’t repeating of words
	- Renaming throughout code again but within game player removed the repetition of the words ‘input’ and ‘output’ by changing method and class names

### DRY
- For feedback: -1 seen in many parts of code
	- Changed the neighbour coordinates generation logic
	- Created a method to get the grid coordinate within game grid so the -1 only exists in one location
- For feedback: Char and Enums used to represent cell
	- Removed the use of char to just be enum of cell type. Char is now only used for output

### Encapsulation
   - For feedback: Abstract concepts away so we don’t have to know about the data types that are used within concepts
	   - Added methods get grid coordinate and get grid size to the game grid class so that details about these data types are abstracted away



# Conway's Game of Life - Quorum Review

From the original Conway's Game of Life kata written by Mark (https://github.com/MYOB-Technology/General_Developer/blob/master/katas/kata-conways-game-of-life/kata-conways-game-of-life.md):

The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970.

The "game" is a zero-player game, meaning that its evolution is determined by its initial state, requiring no further input. One interacts with the Game of Life by creating an initial configuration and observing how it evolves.

# Rules

The universe of the Game of Life is a two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, live or dead. Every cell interacts with its eight neighbors, which are the cells that are directly horizontally, vertically, or diagonally adjacent.

If the cell is on the fringe of the grid it laps over to the other side:

![alt text](https://github.com/sindhumyob/conways-game-of-life/blob/master/cell-overlap.png)

At each step in time, the following transitions occur:

* Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
* Any live cell with more than three live neighbours dies, as if by overcrowding.
* Any live cell with two or three live neighbours lives on to the next generation.
* Any dead cell with exactly three live neighbours becomes a live cell.

The initial pattern constitutes the seed of the system. The first generation is created by applying the above rules simultaneously to every cell in the seed. Births and deaths happen simultaneously, and the discrete moment at which this happens is sometimes called a tick. The rules continue to be applied repeatedly to create further generations.

![alt text](https://github.com/sindhumyob/conways-game-of-life/blob/master/Game_of_life_toad.gif)

# Task
* Visualize the game (you can decide in what medium)
* Be able to define how big the world/grid is (10x10, 50x80, etc.)
* Be able to set the inital state of the world

# My Requirements
* It is a console version of the game
* The minimum grid height and width is 3 and the maximum grid height and width is 100. (ie. minimum grid size is 3x3 and maximum grid size is 100x100).
