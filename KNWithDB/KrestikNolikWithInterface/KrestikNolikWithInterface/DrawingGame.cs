using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KrestikNolikWithInterface
{
    class DrawingGame : GUI
    {
        public int[,] Imatrix { get; set; }
        public int ImatrixSize { get; set; }
        public DrawingGame() { }
        public DrawingGame(int[,] matrix, int matrixSize)
        {
            Imatrix = matrix;
            ImatrixSize = matrixSize;
        }
        public void IDraw()
        {
            for (int i = 0; i<ImatrixSize;i++)
            {                
                for (int j = 0; j< ImatrixSize;j++)
                {
                    if (j == ImatrixSize - 1)
                    {
                        if (Imatrix[i, j] == -1)
                        {
                            Console.Write(" ");
                        }
                        if (Imatrix[i, j] == 1)
                        {
                            Console.Write("X");
                        }
                        if (Imatrix[i, j] == 0)
                        {
                            Console.Write("0");
                        }
                    }
                    else
                    {
                        if (Imatrix[i, j] == -1)
                        {
                            Console.Write(" |");
                        }
                        if (Imatrix[i, j] == 1)
                        {
                            Console.Write("X|");
                        }
                        if (Imatrix[i, j] == 0)
                        {
                            Console.Write("0|");
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
