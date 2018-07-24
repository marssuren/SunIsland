using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedoAction : AbstractGameAction
{
    private AbstractOrb orb;

    public RedoAction()
    {
        GameActionType = ActionType.Damage;
    }

}
