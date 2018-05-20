using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KrestikNolikWithInterface
{
    class StatusGame : IDescribeGame
    {
        public int[,] Imatrix { get; set; }
        public int ImatrixSize { get; set; }        
        public StatusGame() { }
        public StatusGame(int[,] matrix, int matrixSize)
        {
            Imatrix = matrix;
            ImatrixSize = matrixSize;
        }
        public bool ILeftMoves()
        {
            for (int i = 0; i < ImatrixSize; i++)
            {
                for (int j = 0; j < ImatrixSize; j++)
                {
                    if (Imatrix[i, j] == -1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool IWinner()
        {
            int firstPole; //инициализируем переменную, хранящую значение первой ячейки                       
            for (int i = 0; i < ImatrixSize; i++) //создаем цикл, проверяющий строки
            {
                firstPole = Imatrix[i, 0]; //присваиваем первую ячейку строки в переменную
                for (int j = 1; j < ImatrixSize; j++) //создаем цикл перехода на следующий столбец
                {
                    if (firstPole != Imatrix[i, j] || firstPole == -1) //если первая ячейка пустая или она не равна текущей ячейке строки, выходим из цикла  
                    {
                        break;
                    }
                    if (j == ImatrixSize - 1) //если цикл прошел все ячейки и не нашел условий для выхода из цикла, значит все строки равны и программа завершена 
                    {                       
                        Console.WriteLine("Игра завершена. Победитель игрок №{0}", firstPole + 1);
                        return true; //возвращаем булевую переменную, сигнализирующую об окончании программы
                    }
                }
            }
            for (int j = 0; j < ImatrixSize; j++) //создаем цикл проверки совпадений по столбцам, аналогичен проверке по строкам
            {
                firstPole = Imatrix[0, j];
                for (int i = 0; i < ImatrixSize; i++)
                {
                    if (firstPole != Imatrix[i, j] || firstPole == -1)
                    {
                        break;
                    }
                    if (i == ImatrixSize - 1)
                    {                     
                        Console.WriteLine("Игра завершена. Победитель игрок №{0}", firstPole + 1);
                        return true;
                    }
                }
            }
            firstPole = Imatrix[0, 0];
            for (int i = 0; i < ImatrixSize; i++) //создаем цикл проверки по главной диагонали
            {
                if (firstPole != Imatrix[i, i] || firstPole == -1)
                {
                    break;
                }
                if (i == ImatrixSize - 1)
                {                    
                    Console.WriteLine("Игра завершена. Победитель игрок №{0}", firstPole + 1);
                    return true;
                }
            }
            firstPole = Imatrix[0, ImatrixSize - 1];
            for (int i = 0; i < ImatrixSize; i++) //создаем цикл проверки по побочной диагонали
            {
                if (firstPole != Imatrix[i, ImatrixSize - (i + 1)] || firstPole == -1)
                {
                    break;
                }
                if (i == ImatrixSize - 1)
                {                 
                    Console.WriteLine("Игра завершена. Победитель игрок №{0}", firstPole + 1);
                    return true;
                }
            }
            return false; //возвращает значение false
        }
        public int INumberLeftMove()
        {
            int NumberLeftPole = 0;
            for (int i =0;i<ImatrixSize;i++)
            {
                for (int j=0;j<ImatrixSize;j++)
                {
                    if (Imatrix[i,j] == -1)
                    {
                        NumberLeftPole++;
                    }
                }
            }
            return NumberLeftPole;
        }
    }
}
