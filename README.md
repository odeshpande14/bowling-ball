# Ten-Pin Bowling Score Calculator

This program takes a valid sequence of rolls for one line of Ten-Pin Bowling and calculates the total score for the game.

## Rules of Scoring

A Ten-Pin Bowling game consists of 10 frames where the player has two opportunities in each frame to knock down 10 pins. The score for the frame is the total number of pins knocked down, plus bonuses for strikes and spares.

### Strikes

A strike is when the player knocks down all 10 pins on their first try. The bonus for that frame is the value of the next two balls rolled.

### Spares

A spare is when the player knocks down all 10 pins in two tries. The bonus for that frame is the number of pins knocked down by the next roll.

### Tenth Frame

In the tenth frame, a player who rolls a spare or strike is allowed to roll the extra balls to complete the frame. However, no more than three balls can be rolled in the tenth frame.

## Program Constraints

- The program does not check for valid rolls.
- The program does not need to provide scores for intermediate frames.
