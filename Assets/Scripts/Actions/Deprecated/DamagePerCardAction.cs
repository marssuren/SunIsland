using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePerCardAction : AbstractGameAction
{
    private DamageInfo damageInfo;
    private string cardName;

    public DamagePerCardAction(AbstractCreature _target,DamageInfo _info,string _cardName,AttackEffect _attackEffect)
    {
        damageInfo = _info;
        cardName = _cardName;
        GameAttackEffect = _attackEffect;
        SetValues(_target,_info);
        GameActionType = ActionType.Damage;
    }

}
