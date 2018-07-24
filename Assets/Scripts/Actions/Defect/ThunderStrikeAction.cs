using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStrikeAction : AbstractGameAction
{
    private DamageInfo info;
    private int numTimes;

    public ThunderStrikeAction(AbstractCreature _target,DamageInfo _info,int _numTimes)
    {
        info = _info;
        Target = _target;
        GameActionType = ActionType.Damage;
        GameAttackEffect = AttackEffect.None;
        numTimes = _numTimes;

    }

}
