using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggregateEnergyAction : AbstractGameAction
{
    private int divideAmount;

    public AggregateEnergyAction(int _divideAmount)
    {
        divideAmount = _divideAmount;
    }

}
