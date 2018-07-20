using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningOrbEvokeAction : AbstractGameAction
{
    private DamageInfo damageInfo;
    private bool isHitAll;

    public LightningOrbEvokeAction(DamageInfo _info,bool _isHitAll)
    {
        damageInfo = _info;
        GameActionType = ActionType.Damage;
        GameAttackEffect = AttackEffect.None;
        isHitAll = _isHitAll;
    }


}
