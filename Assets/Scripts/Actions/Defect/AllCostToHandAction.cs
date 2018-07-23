using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllCostToHandAction : AbstractGameAction
{
    private AbstractPlayer player;
    private int costToTarget;

    public AllCostToHandAction(int _costToTarget)
    {
        player = AbstractDungeon.Player;
        SetValues(player,AbstractDungeon.Player,Amount);
        GameActionType = ActionType.CardManipulation;
        costToTarget = _costToTarget;
    }

}
