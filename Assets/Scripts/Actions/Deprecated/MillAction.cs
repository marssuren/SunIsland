using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillAction : AbstractGameAction
{
    public MillAction(AbstractCreature _target,AbstractCreature _source,int _amount)
    {
        SetValues(_target,_source,_amount);
        GameActionType = ActionType.CardManipulation;
    }
	
}
