# Minimaxed Tic Tac Toe.

## The Problem:
Creating an unbeatable version of Tic Tac Toe.


### To create an unbeatable Tic Tac Toe game, it is best to first analyze the features of Tic Tac Toe as a game:

* Turn-based
* Small range of options, therefore limited scope of possible permutations
* Very simple rules (must pick an empty space, 3 in a row = win, 9 spaces occupied = draw)
* Zero-sum game, any move that is good for one player is bad for the other

Based on these features, the best-fit solution would be a simple and comprehensive minimax algorithm.


## The Minimax Algorithm:
The minimax algorithm is a deceptively simple algorithm that evaluates the possible states of a system using a given value and then alternates in picking the highest and lowest possible values within that system to reach the highest value terminal (end) state possible. In our application, this equates to any moves that are a win for the AI having a high value, opposed by moves that will lead to the opponent (the player) winning, having a low value. These values are summed up as the algorithm moves through the possible states of the game.

In simpler terms, the algorithm always assumes that all of the AI's moves will be the best possible for it, and the opponent's actions will always do the worst thing possible for the AI. It's a best-worst-case scenario, or to put it simply - a minimized maximization. (To explain it further, for each best possible move you make, the opponent is predicted to do the worst possible move for you. That's the min-max.)

Due to the game having a very limited number of possible states, a minimax algorithm can, in this instance, simulate every possible permutation on the board and thus guarantee the best possible result every time, as opposed to a game like chess, where the permutations exceed the atoms in the observable universe.

### Facilitating the Use of the Minimax Algorithm:
To effectively 'solve' the game using a minimax algorithm, we utilize a node structure containing the state of the field in the given node, as well as if that node is terminal or not.
To illustrate how this AI functions within a reliable testing environment, the computer will always be the starting player. This both enables the best and worst results being a win or draw for the computer and allows for testing of every available path of game states (or to put it simply, allows testing every available move).



### Demo gif:
![minimaxttt_2023-08-02_09-28-21](https://github.com/forsbergsskola-se/201-algorithms-and-datastructures-Jlindhub/assets/112474995/33904e05-0f1f-4e29-acb3-0cf4b9e7d542)
