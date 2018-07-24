using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAction : AbstractGameAction
{
    private AbstractPlayer player;

    public SeekAction(int _amount)
    {
        player = AbstractDungeon.Player;
        SetValues(player,AbstractDungeon.Player,_amount);
        GameActionType = ActionType.CardManipulation;


    }

}
