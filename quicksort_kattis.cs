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
        int mid = left + (right - left) / 2;
        int first = arr[left];
        int middle = arr[mid];
        int last = arr[right];

        int pivotValue = MedianOfThree(first, middle, last);

        int i = left;
        int j = right;

        while (true) {
            while (arr[i] < pivotValue)
                i++;
            while (arr[j] > pivotValue)
                j--;
            if (i >= j)
                break;
            // Swap arr[i] and arr[j]
            (arr[i], arr[j]) = (arr[j], arr[i]);
            i++;
            j--;
        }
        
        return j;
    }

    private static int MedianOfThree(int a, int b, int c) {
        if ((a <= b && b <= c) || (c <= b && b <= a))
            return b; // b is median
        else if ((b <= a && a <= c) || (c <= a && a <= b))
            return a; // a is median
        else
            return c; // c is median
    }

    public static void PrintArray(int[] arr) {
        foreach (int num in arr)
            Console.Write(num + " ");
        Console.WriteLine();
    }

    static void Main(string[] args) {

        string input = Console.ReadLine();
        string[] numbersStr = input.Split(' ');

        int[] arr = new int[numbersStr.Length -1];
        for (int i = 0; i <= numbersStr.Length - 2; i++)
        {
            arr[i] = int.Parse(numbersStr[i+1]);
        }

        Sort(arr);

        PrintArray(arr);
    }
}