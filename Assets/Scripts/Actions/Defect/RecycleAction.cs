using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleAction : AbstractGameAction
{
    private AbstractPlayer player;

    public RecycleAction()
    {
        GameActionType = ActionType.CardManipulation;
        player = AbstractDungeon.Player;

    }

}
