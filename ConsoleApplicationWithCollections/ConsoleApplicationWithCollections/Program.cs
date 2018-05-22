using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationWithCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Game();
            Console.ReadLine();
        }
        static int WinnerOfRound(int[] summa, ref int Winner)
        {
            int max = summa[0];
            for (int i = 1; i < summa.Length; i++)
            {
                if (summa[i] > max)
                {
                    max = summa[i];
                    Winner = i;
                }
            }
            return max;
        }
        static void Game()
        {
            Dictionary<int, string> Players = new Dictionary<int, string>();
            Players.Add(0, "Илья");
            Players.Add(1, "Сергей");
            Players.Add(2, "Евгений");
            Players.Add(3, "Марат");
            Dictionary<int, int> PlayersWinners = new Dictionary<int, int>();
            PlayersWinners.Add(0, 0);
            PlayersWinners.Add(1, 0);
            PlayersWinners.Add(2, 0);
            PlayersWinners.Add(3, 0);
            Queue<int> KolodaKart = new Queue<int>();
            Random karta = new Random();
            int Winner = 0;
            List<int> TakenKarta_0 = new List<int>();
            List<int> TakenKarta_1 = new List<int>();
            List<int> TakenKarta_2 = new List<int>();
            List<int> TakenKarta_3 = new List<int>();
            while (PlayersWinners[Winner] < 5)
            {
                Winner = 0;
                TakenKarta_0.Clear();
                TakenKarta_1.Clear();
                TakenKarta_2.Clear();
                TakenKarta_3.Clear();
                for (int i = 0; i < 52; i++)
                    KolodaKart.Enqueue(karta.Next(2, 14));
                while (true)
                {
                    try
                    {
                        do
                        {
                            TakenKarta_0.Add(KolodaKart.Dequeue());
                        }
                        while (karta.Next(2) != 1);
                        do
                        {
                            TakenKarta_1.Add(KolodaKart.Dequeue());
                        }
                        while (karta.Next(2) != 1);
                        do
                        {
                            TakenKarta_2.Add(KolodaKart.Dequeue());
                        }
                        while (karta.Next(2) != 1);
                        do
                        {
                            TakenKarta_3.Add(KolodaKart.Dequeue());
                        }
                        while (karta.Next(2) != 1);
                    }
                    catch (InvalidOperationException)
                    {
                        break;
                    }
                }
                int[] summa = new int[4];
                for (int i = 0; i < TakenKarta_0.Count; i++)
                {
                    summa[0] += TakenKarta_0[i];
                }
                for (int i = 0; i < TakenKarta_1.Count; i++)
                {
                    summa[1] += TakenKarta_1[i];
                }
                for (int i = 0; i < TakenKarta_2.Count; i++)
                {
                    summa[2] += TakenKarta_2[i];
                }
                for (int i = 0; i < TakenKarta_3.Count; i++)
                {
                    summa[3] += TakenKarta_3[i];
                }
                Console.WriteLine("\n{1} набрал очков: {0}", summa[0], Players[0]);
                Console.WriteLine("{1} набрал очков: {0}", summa[1], Players[1]);
                Console.WriteLine("{1} набрал очков: {0}", summa[2], Players[2]);
                Console.WriteLine("{1} набрал очков: {0}", summa[3], Players[3]);
                Console.WriteLine("Победитель этого раунда: {1}. У него очков: {0}", WinnerOfRound(summa, ref Winner), Players[Winner]);
                PlayersWinners[Winner]++;
            }
            Console.WriteLine("Победителем игры стал: {0}", Players[Winner]);            
        }        
    }
}
