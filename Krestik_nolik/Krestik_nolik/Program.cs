using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krestik_nolik
{    
    class Program        
    {
        static void Main(string[] args)
        {
            int matrixSize = GetSizeMatrix(); //присваиваем переменную, хранящую размерность матрицы. Размерность определяется через метод GetSizeMatrix
            int[,] matrix = new int[matrixSize, matrixSize]; //задаем двумерный массив, представляющий нашу матрицу nxn, где n - размерность матрицы, введенная оператором            
            SetDefaultMatrix(matrixSize, matrix); //создаем метод, в котором будет построена первичная матрица, содержащая значения -1
            bool FirstPlayerMove = true; //присваиваем переменную, отвечающую за то, какое значение должно записываться в матрицу (1 или 0)
            int[] LeftIndexes = new int[matrixSize * matrixSize]; //задаем одномерный массив, хранящий свободные индексы для ввода значений
            SetDefaultLeftIndexes(ref LeftIndexes, matrixSize); //создаем метод для заполнения одномерного массива свободными индексами для ввода значений
            bool NoMove = true; //присваиваем переменную, отвечающую за наличие пустых для ввода ячеек матрицы            
            while (true) //создаем цикл, выход из которого будет в случае совпадения значений в строках, вертикалях, диагоналях или в случае завершения пустых для ввода ячеек
            {                
                int matrixIndex = GetMatrixIndex(LeftIndexes); //присваиваем индекс матрицы для ввода через метод GetMatrixIndex
                MakeMove(ref FirstPlayerMove, ref matrix, matrixIndex, matrixSize); //создаем метод, предназначенный заполнить требуемую ячейку матрицы
                if (CheckSamePole(matrixSize, matrix) == true) //создаем метод, предначначенный проверить совпадение значений по строкам, столбцам и диагоналям и при наличии совпадений завершаем цикл while
                {
                    break;                    
                }
                int NumberLeftIndexes = 0; //присваиваем переменную, отвечающую за поиск количества оставшихся индексов для ввода в матрица                
                SetMatrix(matrixSize, matrix, ref NoMove, ref LeftIndexes, ref NumberLeftIndexes); //создаем метод, предназначенный для формирования матрицы, полученной после ввода текущего значения
                if (NoMove == true) //завершаем цикл while, если больше нет пустых для ввода в матрицу ячеек
                {
                    break;
                }
                WriteLeftIndexes(LeftIndexes, NumberLeftIndexes); //создаем метод, предназначенный для отображения оставшихся индексов
            }
            Console.ReadLine(); //отображть консольное окно до нажатия клавиши "Enter"
        }
        static int GetSizeMatrix() //метод, не имеющий входных параметров, но возвращающий размерность матрицы
        {            
            Console.Write("Введите число, соответствующее размерности квадратной матрицы: "); //вывод сообщения пользователю о запросе ввести размерность матрицы без переключения каретки
            int matrixSize; //инициализируем переменную, отвечающую за размерность матрицы
            try //создаем обработку исключений, чтобы поймать ошибку ввода. Так как программа ждет число, то при ввода строки возникнет ошибка
            {
                matrixSize = Convert.ToInt32(Console.ReadLine()); //сохраняем в переменную число, введенное пользователем
            }
            catch (FormatException) //ловим ошибку некорректного формата введенного значения пользователем
            {
                Console.WriteLine("Был введен неверный формат размерности, по умолчанию формат принят равным 3"); //если ошибка поймана, то сообщаем об этом пользователю
                matrixSize = 3; //и присваем значение по умолчанию
            }
            return matrixSize; //возвращаем размерность матрицы 
 
        }
        static int GetMatrixIndex(int[] LeftIndexes) //создаем метод, входным параметром которого является массив оставшихся индексов, и возвращает индекс матрицы для ввода в него значения
        {
            bool IndexIsRight = false; //присваиваем переменную, сигнализирующую о наличии введенного индекса в массиве оставшихся индексов  
            int matrixIndex = 0; //присваиваем переменную, храняющую введенный индекс для ввода в матрицу 
            while (IndexIsRight == false) //создаем цикл, выход из которого будет тлько в случае ввода индекса из массива оставшихся индексов
            {
                Console.Write("Введите индекс матрицы для ввода в него значения: "); //вывод сообщения пользователю
                try //обработка исключения
                {
                    matrixIndex = Convert.ToInt32(Console.ReadLine()); //присваиваем в переменную введенный пользователем индекс
                }
                catch (FormatException) //ловим ошибку формата введенного значения
                {
                    Console.WriteLine("Был введен неверный формат индекса матрицы, по умолчанию взят минимальный свободный индекс"); //отображаем сообщение о неверном формате ввода значения
                    matrixIndex = LeftIndexes[0]; //присваиваем в переменную минимальный свободный индекс
                }
                for (int i = 0; i < LeftIndexes.Length; i++) //создаем цикл для сравнения введенного индекса с массивом оставшихся индексов 
                {
                    if (matrixIndex == LeftIndexes[i]) //если найдено совпадение, то выходим из цикла
                    {
                        IndexIsRight = true;
			break;
                    }                    
                }
                if (IndexIsRight == false) //если совпадений не найдено, то выдаем сообщение пользователю
                {
                    Console.WriteLine("Введенный индекс за границами текущей матрицы");
                }
            }
            return matrixIndex; //возвращаем значение индекса матрицы            
        }
        static void SetDefaultMatrix(int matrixSize, int[,] matrix) //создаем метод с двумя входными параметрами, предназначенный для формирования первичной матрицы
        {
            for (int i = 0; i < matrixSize; i++) //создаем цикл формирования строк
            {
                Console.WriteLine(); //переводим каретку, чтобы с каждым новым значением счетчика был переход на новую строку
                for (int j = 0; j < matrixSize; j++) //создаем цикл формирования столбцов
                {
                    matrix[i, j] = -1; //заполняем все поля матрицы значением -1
                    Console.Write("{0} ", matrix[i, j]); //выводим каждую ячейку
                }
            }
            Console.WriteLine(); //переводим каретку 
        }
        static void SetMatrix(int matrixSize, int[,] matrix, ref bool NoMove, ref int[] LeftIndexes, ref int NumberLeftIndexes) //создаем метод из 2 входных и 3 ссылочных параметров для построения текущей матрицы
        {
            NoMove = true; //присваиваем переменную, сигнализирующую о наличии/отсутствии пустых полей для ввода            
            for (int i = 0; i < matrixSize; i++) //создаем цикл формирования строк 
            {
                Console.WriteLine(); //переводим каретку
                for (int j = 0; j < matrixSize; j++) //создаем цикл формирования столбцов
                {                    
                    Console.Write("{0} ", matrix[i, j]); //отображаем текущую ячейку матрицы
                    if (matrix[i, j] == -1) //ищем наличие пустых ячеек
                    {
                        NoMove = false;
                        LeftIndexes[NumberLeftIndexes] = i * matrixSize + j + 1; //заполняем массив индексами пустых ячеек
                        NumberLeftIndexes++; 
                    }                   
                }
            }
            Console.WriteLine(); //переводим каретку            
        }
        static bool CheckSamePole(int matrixSize, int[,] matrix) //создаем метод с 2 входными параметрами, возвращающий переменную булевого типа
        {
            int firstPole; //инициализируем переменную, хранящую значение первой ячейки
            bool ProgramEnd = false; //присваиваем переменную, сигнализирующую конец программы ввиду наличие повторений по строкам или столбцам или диагоналям           
            for (int i = 0; i < matrixSize; i++) //создаем цикл, проверяющий строки
            {
                firstPole = matrix[i, 0]; //присваиваем первую ячейку строки в переменную
 		for (int j = 1; j < matrixSize; j++) //создаем цикл перехода на следующий столбец
                {			
                    if (firstPole != matrix[i, j] || firstPole == -1) //если первая ячейка пустая или она не равна текущей ячейке строки, выходим из цикла  
                    {
                        break;
                    }
                    if (j == matrixSize - 1) //если цикл прошел все ячейки и не нашел условий для выхода из цикла, значит все строки равны и программа завершена 
                    {
                        Console.WriteLine("Программа завершена");
                        ProgramEnd = true;
                        return ProgramEnd; //возвращаем булевую переменную, сигнализирующую об окончании программы
                    }
                }
            }
            for (int j = 0; j < matrixSize; j++) //создаем цикл проверки совпадений по столбцам, аналогичен проверке по строкам
            {
                firstPole = matrix[0, j];
                for (int i = 0; i < matrixSize; i++)
                {
                    if (firstPole != matrix[i, j] || firstPole == -1)
                    {
                        break;
                    }
                    if (i == matrixSize - 1)
                    {
                        Console.WriteLine("Программа завершена");
                        ProgramEnd = true;
                        return ProgramEnd;
                    }
                }
            }
            firstPole = matrix[0, 0];            
            for (int i = 0; i < matrixSize; i++) //создаем цикл проверки по главной диагонали
            {
                if (firstPole != matrix[i, i] || firstPole == -1)
                {
                    break;
                }
                if (i == matrixSize - 1)
                {
                    Console.WriteLine("Программа завершена");
                    ProgramEnd = true;
                    return ProgramEnd;
                }
            }
            firstPole = matrix[0, matrixSize - 1];
            for (int i = 0; i < matrixSize; i++) //создаем цикл проверки по побочной диагонали
            {
                if (firstPole != matrix[i, matrixSize - (i + 1)] || firstPole == -1)
                {
                    break;
                }
                if (i == matrixSize - 1)
                {
                    Console.WriteLine("Программа завершена");
                    ProgramEnd = true;
                    return ProgramEnd;
                }
            }
            return ProgramEnd; //возвращает значение false
        }
        static void WriteLeftIndexes(int[] LeftIndexes, int NumberLeftIndexes) //создаем метод с 2 входными параметрами для отображения оставшихся индексов
        {
            Console.Write("Оставшиеся индексы для использования: ");
            for (int i = 0; i < NumberLeftIndexes; i++) //создаем цикл для вывода всех значений оставшихся индексов из массива индексов
            {   
 		if (i == NumberLeftIndexes - 1) //последний индекс пишем с точкой
		{
			Console.Write("{0}. ", LeftIndexes[i]);	
		}
		else //остальные с запятой
		{            
                	Console.Write("{0}, ", LeftIndexes[i]);
		}
            }
            Console.WriteLine();
        }
        static void SetDefaultLeftIndexes(ref int[] LeftIndexes, int matrixSize) //создаем метод с 1 входной переменной и 1 ссылочной для заполнения массива, хранящего оставшиеся индексы первичной матрицы 
        {
            for (int i = 0; i < matrixSize * matrixSize; i++) //так как в первичной матрице все индексы свободны, то заполняем массив всеми индексами матрицы
            {
                LeftIndexes[i] = i + 1; //прибаляем 1, чтобы отсчет индексов был с 1, а не с 0
            }
        }
        static void MakeMove(ref bool FirstPlayerMove, ref int[,] matrix, int matrixIndex, int matrixSize) //создаем метод, с 2 входными параметрами и 2 ссылочными для определения значения для ввода
        {
            if (FirstPlayerMove == true) //логика для переменного ввода значений 1 и 0 
            {
                matrix[(matrixIndex - 1) / matrixSize, (matrixIndex - 1) % matrixSize] = 0;
                FirstPlayerMove = false;
            }
            else
            {
                matrix[(matrixIndex - 1) / matrixSize, (matrixIndex - 1) % matrixSize] = 1;
                FirstPlayerMove = true;
            }
        }
    }
}
