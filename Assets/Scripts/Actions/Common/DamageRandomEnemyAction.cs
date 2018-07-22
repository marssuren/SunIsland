using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageRandomEnemyAction : AbstractGameAction
{
    private DamageInfo info;

    public DamageRandomEnemyAction(DamageInfo _info,AttackEffect _effect)
    {
        info = _info;
        SetValues(AbstractDungeon.GetMonsters().GetRandomMonster(true),info);
        GameActionType = ActionType.Damage;
        GameAttackEffect = _effect;
    }

}
