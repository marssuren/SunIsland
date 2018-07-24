using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAllButOneEnemyAction : AbstractGameAction
{
    public int[] Damage;
    private bool isFirstFrame;

    public DamageAllButOneEnemyAction(AbstractCreature _source, AbstractCreature _target, int[] _amount, DamageType _damageType, AttackEffect _effect, bool _isFast)
    {
        isFirstFrame = true;
        SetValues(_target, _source, _amount[0]);
        Damage = _amount;
        GameActionType = ActionType.Damage;
        GameDamageType = _damageType;
        GameAttackEffect = _effect;

    }

    public DamageAllButOneEnemyAction(AbstractCreature _source, AbstractCreature _target, int[] _amount, DamageType _damageType, AttackEffect _effect) : this(_source, _target, _amount, _damageType, _effect, false)
    {

    }

}
