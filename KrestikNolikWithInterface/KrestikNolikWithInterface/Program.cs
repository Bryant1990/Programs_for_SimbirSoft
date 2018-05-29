using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KrestikNolikWithInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            int matrixSize = GetSizeMatrix(); //присваиваем переменную, хранящую размерность матрицы. Размерность определяется через метод GetSizeMatrix
            int[,] matrix = new int[matrixSize, matrixSize]; //задаем двумерный массив, представляющий нашу матрицу nxn, где n - размерность матрицы, введенная оператором            
            SetDefaultMatrix(matrixSize, matrix);         
            //создаем метод, в котором будет построена первичная матрица, содержащая значения -1
            bool FirstPlayerMove = true; //присваиваем переменную, отвечающую за то, какое значение должно записываться в матрицу (1 или 0)
            int matrixIndexI, matrixIndexJ;
            int firstPole = 0;
            StatusGame SG = new StatusGame(matrix, matrixSize, firstPole);
            DrawingGame DG = new DrawingGame(matrix, matrixSize);
            DG.IDraw();
            //File.Create("C:\\KNOutput.sql");
            FileStream SQLfile = new FileStream("files/KNOutput.sql", FileMode.Append); //создаем файловый поток
            StreamWriter SQLfileWriter = new StreamWriter(SQLfile); //создаем «потоковый писатель» и связываем его с файловым потоком 
            /*SQLfileWriter.WriteLine("CREATE DATABASE KNOutputDB"); //записываем в файл
            SQLfileWriter.WriteLine("CREATE TABLE Users ( "); //записываем в файл
            SQLfileWriter.WriteLine("UserID INT NOT NULL,");
            SQLfileWriter.WriteLine("FirstName VARCHAR(50) NOT NULL,");
            SQLfileWriter.WriteLine("LastName VARCHAR(50) NOT NULL,");
            SQLfileWriter.WriteLine("Age INT NULL");
            SQLfileWriter.WriteLine(");");*/
            while (true) //создаем цикл, выход из которого будет в случае совпадения значений в строках, вертикалях, диагоналях или в случае завершения пустых для ввода ячеек
            {
                GetMatrixIndex(matrix, matrixSize, out matrixIndexI, out matrixIndexJ); //присваиваем индекс матрицы для ввода через метод GetMatrixIndex                
                MakeMove(ref FirstPlayerMove, ref matrix, matrixIndexI, matrixIndexJ, matrixSize); //создаем метод, предназначенный заполнить требуемую ячейку матрицы
                DG.IDraw();                                                
                if (SG.IWinner() == true)
                {
                    Console.WriteLine("Игра завершена. Победитель игрок №{0}", SG.IfirstPole + 1);
                    SQLfileWriter.WriteLine("INSERT INTO Users(FirstName, Date) VALUES('Игрок №{0}', '{1}')", SG.IfirstPole + 1, DateTime.Now);                   

                    SQLfileWriter.Close(); //закрываем поток. Не закрыв поток, в файл ничего не запишется
                    break;
                }
                else
                {
                    if (SG.ILeftMoves() == false)
                    {
                        Console.WriteLine("Не осталось ходов. Игра завершена. У нас ничья");
                        break;
                    }
                    else
                    {
                        if (FirstPlayerMove == true)
                        {
                            Console.WriteLine("Игра не завершена. Ходит игрок №1. Остается пустых ячеек для хода - {0}", SG.INumberLeftMove());
                        }
                        else
                        {
                            Console.WriteLine("Игра не завершена. Ходит игрок №2. Остается пустых ячеек для хода - {0}", SG.INumberLeftMove());
                        }
                    }
                }                
            }
            Console.ReadLine(); //отображть консольное окно до нажатия клавиши "Enter"
        }
        static int GetSizeMatrix() //метод, не имеющий входных параметров, но возвращающий размерность матрицы
        {
            Console.Write("Введите число, соответствующее размерности поля игры: "); //вывод сообщения пользователю о запросе ввести размерность матрицы без переключения каретки
            int matrixSize; //инициализируем переменную, отвечающую за размерность матрицы
            try //создаем обработку исключений, чтобы поймать ошибку ввода. Так как программа ждет число, то при ввода строки возникнет ошибка
            {
                matrixSize = Convert.ToInt32(Console.ReadLine()); //сохраняем в переменную число, введенное пользователем
            }
            catch (FormatException) //ловим ошибку некорректного формата введенного значения пользователем
            {
                Console.WriteLine("Был введен неверный формат размерности поля игры, по умолчанию формат принят равным 3"); //если ошибка поймана, то сообщаем об этом пользователю
                matrixSize = 3; //и присваем значение по умолчанию
            }
            return matrixSize; //возвращаем размерность матрицы 
        }
        static void GetMatrixIndex(int[,] matrix, int matrixSize, out int matrixIndexI, out int matrixIndexJ) //создаем метод, входным параметром которого является массив оставшихся индексов, и возвращает индекс матрицы для ввода в него значения
        {
            bool IndexIsRight = false; //присваиваем переменную, сигнализирующую о наличии введенного индекса в массиве оставшихся индексов  
            matrixIndexI = 0;
            matrixIndexJ = 0; //присваиваем переменную, храняющую введенный индекс для ввода в матрицу 
            while (IndexIsRight == false) //создаем цикл, выход из которого будет тлько в случае ввода индекса из массива оставшихся индексов
            {
                try //обработка исключения
                {
                    Console.Write("Введите строковый индекс поля игры для хода: "); //вывод сообщения пользователю
                    matrixIndexI = Convert.ToInt32(Console.ReadLine()); //присваиваем в переменную введенный пользователем индекс
                    Console.Write("Введите столбцовый индекс поля игры для хода: ");
                    matrixIndexJ = Convert.ToInt32(Console.ReadLine());
                    if (matrixIndexI < matrixSize && matrixIndexJ < matrixSize)
                    {
                        if (matrix[matrixIndexI, matrixIndexJ] == -1)
                        {
                            IndexIsRight = true;
                        }
                        else
                        {
                            Console.WriteLine("Введен индекс занятой ячейки поля игры");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введенный индекс ячейки лежит за границами текущего поля игры");
                    }
                }
                catch (FormatException) //ловим ошибку формата введенного значения
                {
                    Console.WriteLine("Был введен неверный формат индекса ячейки поля игры"); //отображаем сообщение о неверном формате ввода значения
                }
            }
        }
        static void SetDefaultMatrix(int matrixSize, int[,] matrix) //создаем метод с двумя входными параметрами, предназначенный для формирования первичной матрицы
        {
            for (int i = 0; i < matrixSize; i++) //создаем цикл формирования строк
            {
                for (int j = 0; j < matrixSize; j++) //создаем цикл формирования столбцов
                {
                    matrix[i, j] = -1; //заполняем все поля матрицы значением -1                    
                }
            }            
        }          

        static void MakeMove(ref bool FirstPlayerMove, ref int[,] matrix, int matrixIndexI, int matrixIndexJ, int matrixSize) //создаем метод, с 2 входными параметрами и 2 ссылочными для определения значения для ввода
        {
            if (FirstPlayerMove == true) //логика для переменного ввода значений 1 и 0 
            {
                matrix[matrixIndexI, matrixIndexJ] = 0;
                FirstPlayerMove = false;
            }
            else
            {
                matrix[matrixIndexI, matrixIndexJ] = 1;
                FirstPlayerMove = true;
            }
        }        
    }
}
