using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardPileToHandAction : AbstractGameAction
{
    private AbstractPlayer player;

    public DiscardPileToHandAction(int _amount)
    {
        player = AbstractDungeon.Player;
        SetValues(player,AbstractDungeon.Player,_amount);
        GameActionType = ActionType.CardManipulation;
    }
	
}
