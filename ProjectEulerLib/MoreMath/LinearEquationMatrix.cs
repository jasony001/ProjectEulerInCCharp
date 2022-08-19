
using System;

namespace ProjectEulerLib.MoreMath
{

    public class LinearEquationMatrix
    {
        int precision = 4;
        
        double[][] _content;

        double[][] Content { get { return _content; } }

        int _size;
        int Size { get { return _size; } }

        public LinearEquationMatrix(double[][] content)
        {
            _size = content.Length;
            if (_size < 1) throw new System.Exception("Empty matrix is not supported");

            _content = new double[_size][];

            for (int i = 0; i < _size; i++)
            {
                double[] line = content[i];
                if (line.Length != _size + 1) throw new System.Exception("Variable width matrix is not supported.");

                _content[i] = new double[_size + 1];
                for (int j = 0; j < _size + 1; j++)
                    _content[i][j] = content[i][j];
            }
        }

        public LinearEquationMatrix MulitplyLineByNumber(int lineIndex, double n)
        {
            LinearEquationMatrix matrix = new LinearEquationMatrix(_content);
            if (lineIndex > matrix.Size) throw new System.Exception($"Index out of range: lineIndex = {lineIndex}, matrix siz = {matrix.Size}");

            for (int j = 0; j < matrix._size + 1; j++)
            {
                matrix._content[lineIndex][j] = matrix._content[lineIndex][j] * n;
            }

            return matrix.Round(precision);
        }

        public LinearEquationMatrix AddTwoLines(int lineIndex1, int lineIndex2, int destLineIndex)
        {
            LinearEquationMatrix matrix = new LinearEquationMatrix(_content);
            if (lineIndex1 > matrix.Size) throw new System.Exception($"Index out of range: lineIndex1 = {lineIndex1}, matrix siz = {matrix.Size}");
            if (lineIndex2 > matrix.Size) throw new System.Exception($"Index out of range: lineIndex2 = {lineIndex2}, matrix siz = {matrix.Size}");
            if (destLineIndex > matrix.Size) throw new System.Exception($"Index out of range: destLineIndex = {destLineIndex}, matrix siz = {matrix.Size}");

            for (int j = 0; j < matrix._size + 1; j++)
                matrix._content[destLineIndex][j] = matrix._content[lineIndex1][j] + matrix._content[lineIndex2][j];

            return matrix.Round(precision);
        }

        public LinearEquationMatrix SwitchTwoLines(int lineIndex1, int lineIndex2)
        {
            LinearEquationMatrix matrix = new LinearEquationMatrix(_content);
            if (lineIndex1 > matrix.Size) throw new System.Exception($"Index out of range: lineIndex1 = {lineIndex1}, matrix siz = {matrix.Size}");
            if (lineIndex2 > matrix.Size) throw new System.Exception($"Index out of range: lineIndex2 = {lineIndex2}, matrix siz = {matrix.Size}");

            for (int j = 0; j < matrix._size + 1; j++)
            {
                double temp = matrix._content[lineIndex2][j];
                matrix._content[lineIndex2][j] = matrix._content[lineIndex1][j];
                matrix._content[lineIndex1][j] = temp;
            }

            return matrix.Round(precision);
        }
        
        public LinearEquationMatrix Sort()
        {
            LinearEquationMatrix matrix = new LinearEquationMatrix(_content);

            int[] numberOfZerosOnLines = new int[matrix._size];
            for (int lineIndex = 0; lineIndex < matrix._size; lineIndex++)
            {
                numberOfZerosOnLines[lineIndex] = 0;
                for (int colIndex = matrix._size - 1; colIndex >= 0; colIndex--)
                {
                    if (matrix._content[lineIndex][colIndex] != 0) break;
                    numberOfZerosOnLines[lineIndex] = numberOfZerosOnLines[lineIndex] + 1;
                }
            }

            int swap = 0;
            do
            {
                swap = 0;
                for (int lineIndex = 0; lineIndex < _size - 1; lineIndex++)
                {
                    if (numberOfZerosOnLines[lineIndex] < numberOfZerosOnLines[lineIndex + 1])
                    {
                        matrix = matrix.SwitchTwoLines(lineIndex, lineIndex + 1);
                        int temp = numberOfZerosOnLines[lineIndex];
                        numberOfZerosOnLines[lineIndex] = numberOfZerosOnLines[lineIndex + 1];
                        numberOfZerosOnLines[lineIndex + 1] = temp;
                        swap++;
                    }
                }
            } while (swap > 0);

            return matrix.Round(precision);
        }

        public void WriteToConsole()
        {
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size + 1; j++)
                {
                    Console.Write(Math.Round(_content[i][j], 2).ToString() + "\t");
                }
                Console.WriteLine();
            }
        }

        public double[] SolveLinearEquations()
        {
            double[] solutions = new double[_size];

            LinearEquationMatrix matrix = new LinearEquationMatrix(_content);
            // Console.WriteLine("Solving linear equation:");
            // matrix.WriteToConsole();
            // Console.WriteLine();

            for (int columnIndex = _size - 1; columnIndex >= 1; columnIndex--)
            {
                // sort the matrix, so that the row with more 0s on the right appears on top
                // Console.WriteLine("Sort by right size 0s:");
                matrix = matrix.Sort();
                // matrix.WriteToConsole();
                // Console.WriteLine();

                // make column c zero in each rowIndex from 0 to colIndex - 1
                // Console.WriteLine($"Zero out column {columnIndex} from 0 to {columnIndex - 1}");
                matrix = matrix.ZeroOutAColumnLinesAbove(columnIndex);
                // matrix.WriteToConsole();
                // Console.WriteLine();
            }

            for (int columnIndex = 0; columnIndex < matrix._size; columnIndex++)
            {
                // there should be one and only one column with none zero in line c, which should be column c
                solutions[columnIndex] = matrix.GetSolutionInColumn(columnIndex);
                // Console.WriteLine($"solutions[{columnIndex}] = {solutions[columnIndex]}");
                // Console.WriteLine();

                // make column c zero in each rowIndex from columnIndex + 1 to size - 1
                // Console.WriteLine($"Zero out column {columnIndex} from {columnIndex + 1} to {_size - 1}");
                matrix = matrix.ZeroOutAColumnLinesBelow(columnIndex);
                // matrix.WriteToConsole();
                // Console.WriteLine();

            }

            return solutions;
        }

        private double GetSolutionInColumn(int columnIndex)
        {
            if (_content[columnIndex][columnIndex] == 0) throw new Exception("No solution");
            for(int c = 0; c < _size; c ++) {if (c != columnIndex && _content[columnIndex][c] != 0) throw new Exception("No solution"); }

            return _content[columnIndex][Size] / _content[columnIndex][columnIndex];
        }

        private LinearEquationMatrix ZeroOutAColumnLinesAbove(int colIndex)
        {
            LinearEquationMatrix matrix = new LinearEquationMatrix(this._content);

            // make column c zero in each rowIndex from 0 to colIndex - 1
            for (int rowIndex = 0; rowIndex < colIndex; rowIndex++)
            {
                if (matrix._content[rowIndex][colIndex] == 0) continue;

                for (int otherRowIndex = rowIndex + 1; otherRowIndex < colIndex + 1; otherRowIndex++)
                {
                    if (matrix._content[otherRowIndex][colIndex] == 0) continue;
                    double n = -1 * matrix._content[rowIndex][colIndex] / matrix._content[otherRowIndex][colIndex];
                    matrix = matrix.MulitplyLineByNumber(otherRowIndex, n);
                    matrix = matrix.AddTwoLines(rowIndex, otherRowIndex, rowIndex);
                    break;
                }
            }

            return matrix.Round(precision);
        }

        private LinearEquationMatrix ZeroOutAColumnLinesBelow(int colIndex)
        {
            LinearEquationMatrix matrix = new LinearEquationMatrix(this._content);

            // make column c zero in each rowIndex from columnIndex + 1 to size - 1
            for (int rowIndex = colIndex + 1; rowIndex < _size; rowIndex++)
            {
                if (matrix._content[rowIndex][colIndex] == 0) continue;
                double n = -1 * matrix._content[rowIndex][colIndex] / matrix._content[colIndex][colIndex];
                matrix = matrix.MulitplyLineByNumber(colIndex, n);
                matrix = matrix.AddTwoLines(colIndex, rowIndex, rowIndex);
            }

            return matrix.Round(precision);
        }

        private LinearEquationMatrix Round(int digits)
        {
            LinearEquationMatrix matrix = new LinearEquationMatrix(_content);

            for(int i = 0; i < _content.Length; i ++)
            {
                for(int j = 0; j < _content.Length + 1; j ++)
                {
                    matrix._content[i][j] = Math.Round(matrix._content[i][j], digits);
                }
            }

            return matrix;
        }
    }

}