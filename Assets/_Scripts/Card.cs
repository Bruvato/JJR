using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string function;

    public string axis;

    public float adjustmentValue;


    public Card(string axis, string function, float adjustmentValue)
    {
        this.axis = axis;
        this.function = function;
        this.adjustmentValue = adjustmentValue;
    }


}
