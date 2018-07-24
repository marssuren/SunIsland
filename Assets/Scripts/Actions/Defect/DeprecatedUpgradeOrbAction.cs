using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeprecatedUpgradeOrbAction : AbstractGameAction
{
    private bool isRandom = false;

    public DeprecatedUpgradeOrbAction(bool _isRandom)
    {
        GameActionType = ActionType.Damage;
        isRandom = _isRandom;
    }

}
