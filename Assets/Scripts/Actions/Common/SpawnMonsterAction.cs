using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonsterAction : AbstractGameAction
{
    private bool isUsed;
    private AbstractMonster monster;
    private bool isMinion;
    private int targetSlot;

    public SpawnMonsterAction(AbstractMonster _monster,bool _isMinion,int _slot)
    {
        isUsed = false;
        GameActionType = ActionType.Special;
        monster = _monster;
        targetSlot = _slot;
        if (AbstractDungeon.Player.HasRelic("Philosopher'sStone"))
        {
            monster.AddPower(new StrengthPower(monster,2));
        }
    }
    public SpawnMonsterAction(AbstractMonster _monster,bool _isMinion):this(_monster,_isMinion,-99)
    {
        
    }

}
