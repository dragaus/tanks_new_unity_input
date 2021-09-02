using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entropy : MonoBehaviour
{
    public List<float> probabilities;

    void Start()
    {
        Debug.Log(CalculateEntropy());
    }

    void Update()
    {
        
    }

    float CalculateEntropy()
    {
        /*
         * Sumar todas las operaciones de probabilidades
         * 
         * probabilidad * log2(probabilidad)
         * 
         * Math.Log(valor, 2)
         */

        float result = 0;

        foreach(float prob in probabilities)
        {
            result += -1 * prob * Mathf.Log(prob, 2);
        }
        return result;
    }
}
