﻿using System.Collections.Generic;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Randomizations;
using NoyauTP;


namespace Solver_algo_genetic
{
    /// <summary>
    /// This simple chromosome simply represents each cell by a gene with value between 1 and 9, accounting for the target mask if given
    /// </summary>
    public class SudokuCellsChromosome : ChromosomeBase
    {
        /// <summary>
        /// The target sudoku board to solve
        /// </summary>
        private readonly Sudoku _targetSudokuBoard;

        public SudokuCellsChromosome() : this(null)
        {
        }

        /// <summary>
        /// Constructor that accepts a Sudoku to solve
        /// </summary>
        /// <param name="targetSudokuBoard">the target sudoku to solve</param>
        public SudokuCellsChromosome(Sudoku targetSudokuBoard) : base(81)
        {
            _targetSudokuBoard = targetSudokuBoard;
            for (int i = 0; i < Length; i++)
            {
                ReplaceGene(i, GenerateGene(i));
            }
        }

        /// <summary>
        /// Generates genes with digits for each index within the 81 Sudoku cells
        /// </summary>
        /// <param name="geneIndex"></param>
        /// <returns>a gene with a digit for the corresponding cell index</returns>
        public override Gene GenerateGene(int geneIndex)
        {
            //If a target mask exist and has a digit for the cell, we use it.
            if (_targetSudokuBoard != null )
            {
               // todo:utiliser le bon index return new Gene(_targetSudokuBoard.getCaseSudoku(geneIndex)); doit prendre ligne et colonne comme paramètres
            }
            var rnd = RandomizationProvider.Current;
            // otherwise we use a random digit.
            return new Gene(rnd.GetInt(1, 10));
        }

        public override IChromosome CreateNew()
        {
            return new SudokuCellsChromosome(_targetSudokuBoard);
        }

        ///// <summary>
        ///// Builds a single Sudoku from the 81 genes
        ///// </summary>
        ///// <returns>A Sudoku board built from the 81 genes</returns>
        //public IList<Sudoku> GetSudokus()
        //{
        //    //var sudoku = new SudokuBoard(GetGenes().Select(g => (int)g.Value));
        //    //return new List<SudokuBoard>(new[] { sudoku });
        //}
    }
}
