using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReprieveAction : AbstractGameAction
{
    private int focusIncrease;
    private AbstractMonster targetMonster;


    public ReprieveAction(int _incraseAmount,AbstractMonster _monster)
    {
        GameActionType = ActionType.Wait;
        focusIncrease = _incraseAmount;
        targetMonster = _monster;
    }

	
}
