using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleThreadSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов массива: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();
            int[] array = new int[quantity];
            for (int i = 0; i < quantity; i++)
            {
                array[i] = rand.Next(100);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("1 для обычной сортировки, 2 для сортировки с потоками, 3 для ThreadPool ");
            int b = Convert.ToInt32(Console.ReadLine());
            switch (b)
            {
                case 1:
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss:fff"));
                    Sort.Bubble_Sort(array);
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss:fff"));
                    Console.WriteLine("Обычная");
                    for (int i = 0; i < quantity; i++)
                    {
                        Console.Write(array[i] + " ");
                    }
                    break;

                case 2:
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss:fff"));
                    Sort.ThreadBubbleSort(array);
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss:fff"));
                    Console.WriteLine("Параллельно");
                    for (int i = 0; i < quantity; i++)
                    {
                        Console.Write(array[i] + " ");
                    }
                    break;
                case 3:
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss:fff"));
                    Sort.ThreadPoolBubbleSort(array);
                    Console.WriteLine(DateTime.Now.ToString("hh:mm:ss:fff"));
                    Console.WriteLine("С пулом");
                    for (int i = 0; i < quantity; i++)
                    {
                        Console.Write(array[i] + " ");
                    }
                    break;

            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
