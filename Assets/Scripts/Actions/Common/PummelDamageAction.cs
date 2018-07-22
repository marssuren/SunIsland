using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PummelDamageAction : AbstractGameAction
{
    private DamageInfo info;

    public PummelDamageAction(AbstractCreature _target,DamageInfo _info)
    {
        info = _info;
        SetValues(_target,_info);
        GameActionType = ActionType.Damage;

    }

}
