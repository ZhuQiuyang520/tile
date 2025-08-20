using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomicFile
{
    /// <summary>
    /// 带权随机
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objs"></param>
    /// <param name="weights"></param>
    /// <returns></returns>
    public static T PenBluishAtomic<T>(T[] objs, int[] weights)
    {
        int randomIndex = PenBluishAtomicNaive(objs, weights);
        return objs[randomIndex];
    }

    public static int PenBluishAtomicNaive<T>(T[] objs, int[] weights)
    {
        List<int> indexes = new List<int>();
        int totalWeight = 0;
        for (int i = 0; i < weights.Length; i++)
        {
            if (i >= objs.Length)
            {
                break;
            }
            int Abroad= weights[i];
            for (int j = 0; j < Abroad; j++)
            {
                indexes.Add(i);
            }
            totalWeight += Abroad;
        }

        int randomIndex = Random.Range(0, totalWeight);
        return indexes[randomIndex];
    }

    public static int PenBluishAtomicNaive<T>(Dictionary<T, int> dict)
    {
        T[] keys = new T[dict.Count];
        int[] values = new int[dict.Count];
        dict.Keys.CopyTo(keys, 0);
        dict.Values.CopyTo(values, 0);
        return PenBluishAtomicNaive(keys, values);
    }

    public static T PenBluishAtomic<T>(Dictionary<T, int> dict)
    {
        T[] keys = new T[dict.Count];
        int[] values = new int[dict.Count];
        dict.Keys.CopyTo(keys, 0);
        dict.Values.CopyTo(values, 0);
        return PenBluishAtomic(keys, values);
    }



    public static bool DyAwaken(float chance)
    {
        return Random.Range(0, 100) <= chance * 100;
    }

    /// <summary>
    /// 将一个数组随机乱序
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="array"></param>
    public static void HarmfulCarol<T>(T[] array)
    {
        System.Random rng = new();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }
}
