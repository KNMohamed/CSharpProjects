using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver.Startegies;
using SudokuSolver.Workers;

namespace SudokuSolver.Test.Unit.Strategies
{
    [TestClass]
    public class NakedPairsStrategyTest
    {
        private readonly ISudokuStrategy _nakedPairStrategy = new NakedPairsStrategy(new SudokuMapper());

        [TestMethod]
        public void ShouldEliminateNumbersInRowBasedOnNakedPair()
        {
            int[,] sudokuBoard =
            {
                { 1, 2, 34, 5, 34, 6, 7, 348, 9 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            var solveSudokuBoard = _nakedPairStrategy.Solve(sudokuBoard);
            Assert.IsTrue(solveSudokuBoard[0, 7] == 8);
        }

        [TestMethod]
        public void ShouldEliminateNumbersInColBasedOnNakedPair()
        {
            int[,] sudokuBoard =
            {
                { 1, 0, 0, 0, 0, 0, 0, 0, 0},
                { 24, 0, 0, 0, 0, 0, 0, 0, 0},
                { 3, 0, 0, 0, 0, 0, 0, 0, 0},
                { 5, 0, 0, 0, 0, 0, 0, 0, 0},
                { 6, 0, 0, 0, 0, 0, 0, 0, 0},
                { 24, 0, 0, 0, 0, 0, 0, 0, 0},
                { 7, 0, 0, 0, 0, 0, 0, 0, 0},
                { 8, 0, 0, 0, 0, 0, 0, 0, 0},
                { 249, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            var solveSudokuBoard = _nakedPairStrategy.Solve(sudokuBoard);
            Assert.IsTrue(solveSudokuBoard[8, 0] == 9);
        }

        [TestMethod]
        public void ShouldEliminateNumbersInBlockOneBasedOnNakedPair()
        {
            int[,] sudokuBoard =
            {
                { 1, 5, 24, 0, 0, 0, 0, 0, 0},
                { 24, 8, 6, 0, 0, 0, 0, 0, 0},
                { 3, 9, 247, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            var solveSudokuBoard = _nakedPairStrategy.Solve(sudokuBoard);
            Assert.IsTrue(solveSudokuBoard[2,2] == 7);
        }

        [TestMethod]
        public void ShouldEliminateNumbersInBlockFiveBasedOnNakedPair()
        {
            int[,] sudokuBoard =
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 1, 2, 34, 0, 0, 0},
                { 0, 0, 0, 34, 7, 9, 0, 0, 0},
                { 0, 0, 0, 5, 348, 6, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            var solveSudokuBoard = _nakedPairStrategy.Solve(sudokuBoard);
            Assert.IsTrue(solveSudokuBoard[5,4] == 8);
        }
    }
}
