using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideAction : AbstractGameAction
{
    private AbstractMonster monster;
    private bool isRelicTrigger;

    public SuicideAction(AbstractMonster _target,bool _isRelicTrigger)
    {
        GameActionType = ActionType.Damage;
        monster = _target;
        isRelicTrigger = _isRelicTrigger;
    }

    public SuicideAction(AbstractMonster _target):this(_target,true)
    {
        
    }

}
