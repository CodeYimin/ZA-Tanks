using System;
using System.Text;
using UnityEngine;

namespace Utility
{
    public static class Util
    {
        public static void Fill2DArray<T>(T[,] array, T valueToFill)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = valueToFill;
                }
            }
        }

        public static void PrintArray<T>(T[] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach(T item in array)
            {
                sb.Append(item + ", ");
            }
            Debug.Log(sb);
        }
    }
}