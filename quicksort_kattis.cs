using System;
// using System.Diagnostics;
class QuickSort {
    private const int InsertionSortThreshold = 15; // Set your threshold here

    public static void Sort(int[] arr) {
        if (arr == null || arr.Length == 0)
            return;
        Sort(arr, 0, arr.Length - 1);
    }
    private static void Sort(int[] arr, int left, int right) {
        while (left < right) {
            int pivotIndex = Partition(arr, left, right);
            Sort(arr, left, pivotIndex - 1); // Sort smaller part first
            left = pivotIndex + 1; // Handle larger part in next iteration (tail recursion)
        }
    }

    private static int MedianOfThree(int a, int b, int c) {
        return Math.Max(Math.Min(a, b), Math.Min(Math.Max(a, b), c));
    }

    private static void Swap(int[] arr, int i, int j) {
        (arr[i], arr[j]) = (arr[j], arr[i]);
    }

    private static int Partition(int[] arr, int left, int right) {
        int pivot = arr[left];
        int i = left;
        int j = right;

        while (true) {
            while (i <= right && arr[i] < pivot)
                i++;
            while (j >= left && arr[j] > pivot)
                j--;
            if (i >= j)
                return j;
            // Swap arr[i] and arr[j]
            (arr[i], arr[j]) = (arr[j], arr[i]);
            i++;
            j--;
        }
    }
    private static void InsertionSort(int[] arr, int left, int right) {
        for (int i = left + 1; i <= right; i++) {
            int key = arr[i];
            int j = i - 1;

            while (j >= left && arr[j] > key) {
                arr[j + 1] = arr[j];
                j--;
            }

            arr[j + 1] = key;
        }
    }

    public static void PrintArray(int[] arr) {
        foreach (int num in arr)
            Console.Write(num + " ");
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        string input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            // Stopwatch stopwatch1 = new Stopwatch();
            // stopwatch1.Start();
            string[] numbersStr = input.Split(' ');
            int[] arr = new int[int.Parse(numbersStr[0])];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(numbersStr[i + 1]);
            }

            // stopwatch1.Stop();

            // // Console.WriteLine($"Execution time: {stopwatch1.Elapsed.TotalSeconds:F3} seconds");


            // Stopwatch stopwatch2 = new Stopwatch();
            // stopwatch2.Start();
            Sort(arr);
            // stopwatch2.Stop();

            // // Console.WriteLine($"Execution time: {stopwatch2.Elapsed.TotalSeconds:F3} seconds");

            PrintArray(arr);
        }
    }
}