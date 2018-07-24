using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvokeOrbAction : AbstractGameAction
{
    private int orbCount;

    public EvokeOrbAction(int _amount)
    {
        orbCount = _amount;
        GameActionType = ActionType.Damage;
    }

}
