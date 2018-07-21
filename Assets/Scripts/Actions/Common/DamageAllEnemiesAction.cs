using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAllEnemiesAction : AbstractGameAction
{
    public int[] Damage;
    //private bool isFirstGame;

    public DamageAllEnemiesAction(AbstractCreature _source,int[] _amount,DamageType _damageType,AttackEffect _attackEffect,bool _isFast)
    {
        SetValues(null,_source,_amount[0]);
        Damage = _amount;
        GameActionType = ActionType.Damage;
        GameDamageType = _damageType;
        GameAttackEffect = _attackEffect;
        
    }

    public DamageAllEnemiesAction(AbstractCreature _source,int[] _amount,DamageType _damageType,AttackEffect _effect):this(_source,_amount,_damageType,_effect,false)
    {
        
    }

}
