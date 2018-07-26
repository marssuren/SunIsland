using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSelectedAmountAction : AbstractGameAction
{
    public ArmorSelectedAmountAction(AbstractCreature _target,AbstractCreature _source, int _isMultiplier)
    {
        SetValues(_target,_source,_isMultiplier);
        GameActionType = ActionType.Power;
    }
	
}
