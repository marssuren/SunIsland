using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainEnergyAndEnableControlsAction : AbstractGameAction
{
    private int energyGain;

    public GainEnergyAndEnableControlsAction(int _amount)
    {
        SetValues(AbstractDungeon.Player,AbstractDungeon.Player,0);
        energyGain = _amount;
    }

}
