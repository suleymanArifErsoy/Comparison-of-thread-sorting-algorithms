using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Paralel_programlama_odev_1
{
    internal class Program
    {

        static void Shell_Sort(int[] arr)
        {
            int n = arr.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j;
                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                    }
                    arr[j] = temp;
                }
            }
        }
        static void Bubble_Sort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        swapped = true;
                    }
                }
                if (!swapped) break;
            }
        }
        static void Selection_Sort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIdx = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIdx])
                        minIdx = j;
                }
                (arr[i], arr[minIdx]) = (arr[minIdx], arr[i]);
            }
        }
        static void Quick_Sort(int[] arr,int left,int right)
        {
            if (left >= right) return;
            int pivot = arr[(left + right) / 2];
            int index = Partition(arr, left, right, pivot);
            Quick_Sort(arr, left, index - 1);
            Quick_Sort(arr, index, right);
        }
        static int Partition(int[] arr, int left, int right, int pivot)
        {
            while (left <= right)
            {
                while (arr[left] < pivot) left++;
                while (arr[right] > pivot) right--;
                if (left <= right)
                {
                    (arr[left], arr[right]) = (arr[right], arr[left]);
                    left++;
                    right--;
                }
            }
            return left;
        }
        
        static void Main(string[] args)
        {
            // Rastgele sıralı Dizi ü
            Random rnd = new Random();
            int[] dizi = new int[100000];
            for (int i = 0; i < dizi.Length; i++)
            {
                dizi[i] = rnd.Next(0,100001);
            }
            int[] copydizi1 = (int[])dizi.Clone();
            int[] copydizi2 = (int[])dizi.Clone();
            int[] copydizi3 = (int[])dizi.Clone();
            int[] copydizi4 = (int[])dizi.Clone();

            Stopwatch sw1 = new Stopwatch();
            sw1.Start();

            // Quick Sort 
            Thread th1 = new Thread(() => Quick_Sort(copydizi1,0,dizi.Length-1));
            th1.Start();
            th1.Join();
            sw1.Stop();
            Console.WriteLine($"Quick Sort için performans : {sw1.ElapsedMilliseconds}");


            Stopwatch sw2 = new Stopwatch();
            sw2.Start();

            // Shell Sort 
            Thread th2 = new Thread(() => Shell_Sort(copydizi2));
            th2.Start();
            th2.Join();
            sw2.Stop();
            Console.WriteLine($"Shell Sort için performans : {sw2.ElapsedMilliseconds}");


            Stopwatch sw4 = new Stopwatch();
            sw4.Start();

            // Bubble Sort 
            Thread th4 = new Thread(() => Bubble_Sort(copydizi4));
            th4.Start();
            th4.Join();
            sw4.Stop();
            Console.WriteLine($"Bubble Sort için performans : {sw4.ElapsedMilliseconds}");

            Stopwatch sw3 = new Stopwatch();
            sw3.Start();

            // Selection Sort 
            Thread th3 = new Thread(() => Selection_Sort(copydizi3));
            th3.Start();
            th3.Join();
            sw3.Stop();
            Console.WriteLine($"Selection Sort için performans : {sw3.ElapsedMilliseconds}");

           
            Console.ReadLine(); 
        }
    }
}
