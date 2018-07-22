using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollMoveAction : AbstractGameAction
{
    private AbstractMonster monster;

    public RollMoveAction(AbstractMonster _monster)
    {
        monster = _monster;
    }

}
