using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardAction : AbstractGameAction
{
    private AbstractPlayer player;
    private bool isRandom;
    private bool isEndTurn;
    public static int NumDiscarded;

    public DiscardAction(AbstractCreature _target,AbstractCreature _source,int _amount,bool _isRandom,bool _isEndTurn)
    {
        player = _target as AbstractPlayer;
        isRandom = _isRandom;
        SetValues(_target,_source,_amount);
        GameActionType = ActionType.Discard;
        isEndTurn = _isEndTurn;

    }
    public DiscardAction(AbstractCreature _target,AbstractCreature _source,int _amount,bool _isRandom):this(_target,_source,_amount,_isRandom,false)
    {
        
    }

}
