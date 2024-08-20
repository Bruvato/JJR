using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public string function;

    public string axis;

    public float adjustmentValue;


    public Card(string function, string axis, float adjustmentValue)
    {
        this.function = function;
        this.axis = axis;
        this.adjustmentValue = adjustmentValue;
    }


}
