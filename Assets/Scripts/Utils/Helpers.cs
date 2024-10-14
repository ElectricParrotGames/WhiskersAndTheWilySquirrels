using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpers
{
    public static float Map(float value, float originalMin, float originalMax, float newMin, float newMax, bool clamp = false)
    {
        float newValue = (value - originalMin) / (originalMax - originalMin) * (newMax - newMin) + newMin;
        if (clamp)
        {
            newValue = Mathf.Clamp(newValue, newMin, newMax);
        }
        return newValue;
    }
}