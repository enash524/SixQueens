# Six Queens

This problem consists of putting one queen (represented by Q) on every column  (labeled a, b, c, ...) of an N x N board, such that no two queens are in the **same row or diagonal**. An example valid solution for N = 6 is:

|   |   |   |   |   |   |   |   |
|---|---|---|---|---|---|---|---|
|   | 6 | - | - | Q | - | - | - |
|   | 5 | - | - | - | - | - | Q |
| R | 4 | - | Q | - | - | - | - |
| O | 3 | - | - | - | - | Q | - |
| W | 2 | Q | - | - | - | - | - |
| S | 1 | - | - | Q | - | - |   |
|   |   | A | B | C | D | E | F |
|   | C | O | L | U | M | N | S |

In board notation, the squares with queens in this solution are called a2, b4, c6, d1, e3, and f5. We'll represent arrays by listing the rows that each column's queen appears in from left to right, so this solution is represented as the array [2, 4, 6, 1, 3, 5].

## Code Challenge

Write a C# function that accepts an array of 6 Integers.\
The function should determine if this array represents a valid combination.

**Example 1:**\
Input: [2, 4, 6, 1, 3, 5]\
Output Expected: true

**Example 2:**\
Input: [3, 4, 2, 1, 6, 5]\
Output Expected: false
