using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estadistics : MonoBehaviour
{
    public List<int> data;

    private void Start()
    {
        float mean = GetMean();
        Debug.Log(GetMedian());
        Debug.Log($"El promedio es: {mean}");
    }

    private float GetMean()
    {
        float mean = 0;

        foreach(int value in data)
        { mean += value; }

        mean /= data.Count;

        return mean;
    }

    private float GetMedian()
    {
        data.Sort();

        if (data.Count % 2 == 0)
        {
            int indexA = data.Count / 2;
            int indexB = indexA - 1;

            int suma = data[indexA] + data[indexB];

            float result = suma / 2f;

            return result;
        } else {
            float half = data.Count / 2f;

            int index = Mathf.FloorToInt(half);

            return data[index];
        }
    }

    private float GetTypicalVariation()
    {
        float mean = GetMean();
        float resultRange = 0;

        foreach(int value in data)
        {
            resultRange += Mathf.Pow(value - mean, 2);
        }

        float inRootResult = resultRange / data.Count;

        float result = Mathf.Sqrt(inRootResult);

        return result;
    }
}
