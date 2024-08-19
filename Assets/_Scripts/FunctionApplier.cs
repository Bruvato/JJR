using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FunctionApplier
{

    public enum Function
    {
        Add,
        Multiply,
        Power, 
    }


    public static float ApplyFunction(Function function, float input, float adjustmentValue)
    {
        switch(function)
        {
            case Function.Add:
                return input + adjustmentValue;

            case Function.Multiply:
                return input * adjustmentValue;

            case Function.Power:
                return Mathf.Pow(input, adjustmentValue);
        }

        return input;
    }

    public static Vector3 ApplyFunctionOnVecComponents(Function function, Vector3 input, float adjustmentValue, bool applyToX, bool applyToY, bool applyToZ)
    {
        Vector3 output = input;

        if (applyToX)
        {
            output.x = ApplyFunction(function, input.x, adjustmentValue);
        }
        if (applyToY)
        {
            output.y = ApplyFunction(function, input.y, adjustmentValue);
        }
        if (applyToZ)
        {
            output.z = ApplyFunction(function, input.z, adjustmentValue);
        }

        return output;
    }

    public static Vector3 ApplyFunctionOnVecX(Function function, Vector3 input, float adjustmentValue)
    {
        return ApplyFunctionOnVecComponents(function, input, adjustmentValue, true, false, false);
    }
    public static Vector3 ApplyFunctionOnVecY(Function function, Vector3 input, float adjustmentValue)
    {
        return ApplyFunctionOnVecComponents(function, input, adjustmentValue, false, true, false);
    }
    public static Vector3 ApplyFunctionOnVecZ(Function function, Vector3 input, float adjustmentValue)
    {
        return ApplyFunctionOnVecComponents(function, input, adjustmentValue, false, false, true);
    }

}
