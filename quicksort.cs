using System;
using System.IO;
using System.Diagnostics;

// Using Hoare partition scheme

// Kinda using this code psudo code:

// // Sorts a (portion of an) array, divides it into partitions, then sorts those
// algorithm quicksort(A, lo, hi) is 
//   if lo >= 0 && hi >= 0 && lo < hi then
//     p := partition(A, lo, hi) 
//     quicksort(A, lo, p) // Note: the pivot is now included
//     quicksort(A, p + 1, hi) 

// // Divides array into two partitions
// algorithm partition(A, lo, hi) is 
//   // Pivot value
//   pivot := A[lo] // Choose the first element as the pivot

//   // Left index
//   i := lo - 1 

//   // Right index
//   j := hi + 1

//   loop forever 
//     // Move the left index to the right at least once and while the element at
//     // the left index is less than the pivot
//     do i := i + 1 while A[i] < pivot
    
//     // Move the right index to the left at least once and while the element at
//     // the right index is greater than the pivot
//     do j := j - 1 while A[j] > pivot

//     // If the indices crossed, return
//     if i >= j then return j
    
//     // Swap the elements at the left and right indices
//     swap A[i] with A[j]


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

        while (true) {
            while (i <= j && arr[i] <= pivot)
                i++;
            while (i <= j && arr[j] > pivot)
                j--;
            if (i >= j)
                break;
            // Swap arr[i] and arr[j]
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        // Swap arr[left] and arr[j]
        arr[left] = arr[j];
        arr[j] = pivot;

        return j;
    }

    public static void PrintArray(int[] arr) {
        foreach (int num in arr)
            Console.Write(num + " ");
        Console.WriteLine();
    }

    static void Main(string[] args) {

        // import numbers from file
        string filePath = "rand_arr.txt";
        string content = File.ReadAllText(filePath);
        
        string[] numbersStr = content.Split(',');

        int[] arr = new int[numbersStr.Length -1];
        for (int i = 0; i < numbersStr.Length -1; i++)
        {
            arr[i] = int.Parse(numbersStr[i]);
        }

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        Sort(arr);
        stopwatch.Stop();

        //PrintArray(arr);

        Console.WriteLine($"Execution time: {stopwatch.Elapsed.TotalSeconds:F3} seconds");
    }
}