using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainEnergyAction : AbstractGameAction
{
    private int energyGain;

    public GainEnergyAction(int _amount)
    {
        SetValues(AbstractDungeon.Player,AbstractDungeon.Player,0);
        energyGain = _amount;
    }

}
