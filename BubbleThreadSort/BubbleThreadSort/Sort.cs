using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace BubbleThreadSort
{
    public static class Sort
    {
        public static void Bubble_Sort(int[] array)
        {
            for (int k = array.Length - 1; k > 0; k--)
                for (int i = 0; i < k; i++)
                    if (array[i] > array[i + 1])
                    {
                        Swap(ref array[i], ref array[i + 1]);
                    }

        }

        public static void Swap(ref int aFirstArg, ref int aSecondArg)
        {
            int tmpParam = aFirstArg;
            aFirstArg = aSecondArg;
            aSecondArg = tmpParam;
        }

        public static void ThreadBubbleSort(int[] array)
        {
            //Thread thread = new Thread((id) =>                 
            Thread[] thr1 = new Thread[(int)array.Length / 2];
            Thread[] thr2 = new Thread[(int)array.Length / 2];
            int count1;
            int count2;
            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.WriteLine("Начало сортировки с прохода {0}", i);
                if (i % 2 == 0)//если i четное
                {
                    count1 = 0; ;
                    for (int j = 0; j < array.Length / 2; j++)
                    {
                        int temp = j;
                        count1++;
                        thr1[temp] = new Thread(() =>
                          {
                              Console.WriteLine("Поток1 {0} Начал сортировку", temp);
                              if (array[2 * temp] > array[2 * temp + 1])
                              {
                                  Swap(ref array[2 * temp], ref array[2 * temp + 1]);
                              }
                              Console.WriteLine("Поток1 {0} закончил сортировку", temp);
                          });
                        thr1[temp].Start();
                    }
                    for (int m = 0; m < count1; m++)
                    {
                        thr1[m].Join();
                    }
                }
                else//если i нечётное
                {
                    count2 = 0;
                    for (int k = 0; k < array.Length / 2 - 1; k++)
                    {
                        int temp = k;
                        count2++;
                        thr2[temp] = new Thread(() =>
                          {
                              Console.WriteLine("Поток2 {0} Начал сортировку", temp);
                              if (array[2 * temp + 1] > array[2 * temp + 2])
                              {
                                  Swap(ref array[2 * temp + 1], ref array[2 * temp + 2]);
                              }
                              Console.WriteLine("Поток2 {0} закончил сортировку", temp);
                          });
                        thr2[temp].Start();
                    }
                    for (int m = 0; m < count2; m++)
                    {
                        thr2[m].Join();
                    }
                }

            }


        }

        public static void ThreadPoolBubbleSort(int[] array)
        {

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < array.Length / 2; j++)
                    {
                        int temp = j;
                        ThreadPool.QueueUserWorkItem(new WaitCallback((s) =>
                        {
                            if (array[2 * temp] > array[2 * temp + 1])
                            {
                                Swap(ref array[2 * temp], ref array[2 * temp + 1]);
                            }
                        }));
                    }
                }
                else
                {
                    for (int k = 0; k < array.Length / 2 - 1; k++)
                    {
                        int temp = k;
                        ThreadPool.QueueUserWorkItem(new WaitCallback((s) =>
                        {
                            if (array[2 * temp + 1] > array[2 * temp + 2])
                            {
                                Swap(ref array[2 * temp + 1], ref array[2 * temp + 2]);
                            }
                        }));

                    }

                }
            }
        }
    }
}

