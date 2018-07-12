using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterQueueItem

{
    public AbstractMonster Monster;

    public MonsterQueueItem(AbstractMonster _monster)
    {
        Monster = _monster;
    }
}
