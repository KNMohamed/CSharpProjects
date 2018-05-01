using SudokuSolver.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuSolver.Workers
{
    class SudokuMapper
    {
        public SudokuMap Find(int givenRow, int givenCol)
        {
            SudokuMap sudokuMap = new SudokuMap();

            if (givenRow <= 2) { sudokuMap.StartRow = 0; }
            else if (givenRow <= 5) { sudokuMap.StartRow = 3; }
            else if (givenRow <= 8) { sudokuMap.StartRow = 6; }

            if(givenCol <= 2) { sudokuMap.StartCol = 0; }
            else if(givenCol <= 5) { sudokuMap.StartCol = 3; }
            else if(givenCol <= 8) { sudokuMap.StartCol = 6; }

            return sudokuMap;
        } 
    }
}
