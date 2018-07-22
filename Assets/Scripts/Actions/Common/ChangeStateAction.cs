using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStateAction : AbstractGameAction
{
    private bool isCalled = false;
    private AbstractMonster monster;
    private string stateName;

    public ChangeStateAction(AbstractMonster _monster,string _stateName)
    {
        GameActionType = ActionType.Special;
        monster = _monster;
        stateName = _stateName;
    }

}
