using System;
using System.IO;
using System.Collections.Generic;

class QuickSort {
    public static void Sort(int[] arr) {
        // check if array is even a thing
        if (arr == null || arr.Length == 0)
            return;
        // arr + check posisiton left + check posistion right
        Sort(arr, 0, arr.Length - 1);
    }

    private static void Sort(int[] arr, int left, int right) {
        // when positions overlap, exit
        if (left >= right)
            return;


        int pivot = Partition(arr, left, right);
        Sort(arr, left, pivot - 1);
        Sort(arr, pivot + 1, right);
    }

    private static int Partition(int[] arr, int left, int right) {
        int pivot = arr[left];
        int i = left + 1;
        int j = right;

        while (i <= j) {
            while (i <= j && arr[i] <= pivot)
                i++;
            while (i <= j && arr[j] > pivot)
                j--;
            if (i < j)
                // swap elements using fancy tuple stuff 
                (arr[i], arr[j]) = (arr[j], arr[i]); 
        }
        
        // another fancy tuple swap 
        (arr[left], arr[j]) = (arr[j], pivot); 

        return j;
    }

    public static void PrintArray(int[] arr) {
        foreach (int num in arr)
            Console.Write(num + " ");
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        // Read input from standard input
        string input = Console.ReadLine();

        // Process and utilize the input as needed
        if (!string.IsNullOrEmpty(input))
        {
            string[] numbersStr = input.Split(' ');
            int[] arr = new int[numbersStr.Length - 1];

            for (int i = 0; i <= numbersStr.Length - 2; i++)
            {
                arr[i] = int.Parse(numbersStr[i + 1]);
            }

            // Sort the array
            Array.Sort(arr);

            // Print the sorted array
            PrintArray(arr);
        }
    }
}