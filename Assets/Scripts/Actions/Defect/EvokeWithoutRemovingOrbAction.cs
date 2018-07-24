using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvokeWithoutRemovingOrbAction : AbstractGameAction
{
    private int orbCount;

    public EvokeWithoutRemovingOrbAction(int _amount)
    {
        orbCount = _amount;
        GameActionType = ActionType.Damage;
    }

}
