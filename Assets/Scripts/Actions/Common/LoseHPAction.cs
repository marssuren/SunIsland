using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseHPAction : AbstractGameAction
{
    public LoseHPAction(AbstractCreature _target,AbstractCreature _source,int _amount,AttackEffect _effect)
    {
        SetValues(_target,_source,_amount);
        GameActionType = ActionType.Damage;
        GameAttackEffect = _effect;
    }
    public LoseHPAction(AbstractCreature _target,AbstractCreature _source,int _amount)
    {
        
    }
	
}
