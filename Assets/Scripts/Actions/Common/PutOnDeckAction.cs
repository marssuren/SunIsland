﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOnDeckAction : AbstractGameAction
{
    private AbstractPlayer player;
    private bool isRandom;
    public static int NumPlaced;

    public PutOnDeckAction(AbstractCreature _target,AbstractCreature _source,int _amount,bool _isRandom)
    {
        Target = _target;
        player=_target as AbstractPlayer;
        SetValues(_target,_source,_amount);
        GameActionType = ActionType.CardManipulation;
        isRandom = _isRandom;

    }

}