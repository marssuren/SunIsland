using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CacheAction : AbstractGameAction
{
    private AbstractPlayer player;

    public CacheAction(int _amount)
    {
        player = AbstractDungeon.Player;
        SetValues(player,AbstractDungeon.Player,Amount);
    }

}
