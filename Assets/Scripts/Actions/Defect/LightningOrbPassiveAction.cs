using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningOrbPassiveAction : AbstractGameAction
{
    private DamageInfo damageInfo;
    private AbstractOrb orb;
    private bool isHitAll;

    public LightningOrbPassiveAction(DamageInfo _info,AbstractOrb _orb,bool _isHitAll)
    {
        damageInfo = _info;
        orb = _orb;
        GameActionType = ActionType.Damage;
        GameAttackEffect = AttackEffect.None;
        isHitAll = _isHitAll;
    }

}
