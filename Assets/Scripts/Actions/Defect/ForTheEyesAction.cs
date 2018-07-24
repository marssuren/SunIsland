using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForTheEyesAction : AbstractGameAction
{
    private AbstractMonster monster;

    public ForTheEyesAction(int _weakAmt,AbstractMonster _monster)
    {
        GameActionType = ActionType.Wait;
        Amount = _weakAmt;
        monster = _monster;
    }

}
