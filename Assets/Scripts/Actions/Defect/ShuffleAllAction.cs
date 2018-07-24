using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleAllAction : AbstractGameAction
{
    private bool isShuffled;
    private bool isVfxDone;
    private int count = 0;

    public ShuffleAllAction()
    {
        SetValues(null,null,0);
        GameActionType = ActionType.Shuffle;


        for (int i = 0; i < AbstractDungeon.Player.Relics.Count; i++)
        {
            AbstractDungeon.Player.Relics[i].OnShuffle();
        }
    }


}
