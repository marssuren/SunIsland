using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunderAction : AbstractGameAction
{
    private int energyAmount;
    private DamageInfo info;

    public SunderAction(AbstractCreature _target,DamageInfo _info,int _energyAmount)
    {
        info = _info;
        SetValues(_target,_info);
        energyAmount = _energyAmount;
        GameActionType = ActionType.Damage;

    }

}
