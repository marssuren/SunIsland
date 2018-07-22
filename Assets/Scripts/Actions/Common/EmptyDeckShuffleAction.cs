using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyDeckShuffleAction : AbstractGameAction
{
    private bool isShuffled = false;
    private int count = 0;

    public EmptyDeckShuffleAction()
    {
        SetValues(null,null,0);
        GameActionType = ActionType.Shuffle;
        for (int i = 0; i < AbstractDungeon.Player.Relics.Count; i++)
        {
            AbstractDungeon.Player.Relics[i].OnShuffle();
        }
    }

}
