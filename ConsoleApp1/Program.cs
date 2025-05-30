using System;
using System.Collections.Generic;

public class IntervalMerger
{
    public static void Main()
    {
        int[][] intervalos1 =
        {
            new int[] {1, 3},
            new int[] {6, 8},
            new int[] {9, 10},
            new int[] {2, 4}
        };
        MostrarIntervalos(intervalos1);
        int[][] resultado1 = UnirIntervalos(intervalos1);
        MostrarIntervalos(resultado1);

        int[][] intervalos2 =
        {
            new int[] {6, 8},
            new int[] {1, 9},
            new int[] {2, 4}
        };
        MostrarIntervalos(intervalos2);
        int[][] resultado2 = UnirIntervalos(intervalos2);
        MostrarIntervalos(resultado2);
    }

    public static int[][] UnirIntervalos(int[][] intervals)
    {
        if (intervals == null || intervals.Length == 0)
        {
            return new int[0][];
        }

        BubbleSort(intervals);
        List<int[]> resultado = new List<int[]>();
        resultado.Add(new int[] { intervals[0][0], intervals[0][1] });
        for (int i = 1; i < intervals.Length; i++)
        {
            int[] ultimo = resultado[resultado.Count - 1];
            int inicioActual = intervals[i][0];
            int finActual = intervals[i][1];
            if (inicioActual <= ultimo[1])
            {
                ultimo[1] = Math.Max(ultimo[1], finActual);
            }
            else
            {
                resultado.Add(new int[] { inicioActual, finActual });
            }
        }
        
        return resultado.ToArray();
    }    private static void BubbleSort(int[][] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j][0] > arr[j + 1][0])
                {
                    int[] temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }
    private static void MostrarIntervalos(int[][] intervals)
    {
        foreach (int[] intervalo in intervals)
        {
            Console.Write($"{{{intervalo[0]},{intervalo[1]}}} ");
        }
        Console.WriteLine();
    }
}