using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntentFlashAction : AbstractGameAction
{
    private AbstractMonster monster;

    public IntentFlashAction(AbstractMonster _monster)
    {
        monster = _monster;
        GameActionType = ActionType.Wait;
    }

}
