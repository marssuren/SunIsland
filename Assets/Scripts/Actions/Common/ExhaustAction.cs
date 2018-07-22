using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustAction : AbstractGameAction
{
    private AbstractPlayer player;
    private bool isRandom;
    private bool isAnyNumber;
    private bool isCanPickZero;
    public static int NumExhausted;
    public ExhaustAction(AbstractCreature _target,AbstractCreature _source,int _amount,bool _isRandom,bool _isAnyNumber,bool _isCanPickZero)
    {
        isCanPickZero = false;
        isAnyNumber = _isAnyNumber;
        isCanPickZero = _isCanPickZero;
        player = _target as AbstractPlayer;
        isRandom = _isRandom;
        SetValues(_target,_source,_amount);
        GameActionType = ActionType.Exhaust;
    }

    public ExhaustAction(AbstractCreature _target,AbstractCreature _source,int _amount,bool _isRandom,bool _isAnyNumber):this(_target,_source,_amount,_isRandom,_isAnyNumber,false)
    {
        
    }
	
}
