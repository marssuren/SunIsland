using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGroup
{
    public List<AbstractMonster> Monsters;
    public AbstractMonster HoveredMonster;

    public MonsterGroup(AbstractMonster[] _input)
    {
        Monsters = new List<AbstractMonster>();
        HoveredMonster = null;
        Monsters.AddRange(_input);
    }

    public void AddMonster(AbstractMonster _monster)
    {
        Monsters.Add(_monster);
    }

    public void AddMonster(int _newIndex, AbstractMonster _monster)
    {
        Monsters.Insert(_newIndex, _monster);
    }

    public void AddSpawnMonster(AbstractMonster _monster)
    {
        Monsters.Insert(0, _monster);
    }

    public MonsterGroup(AbstractMonster _monster) : this(new AbstractMonster[] { _monster })
    {

    }

    public bool AreMonstersBasicallyDead()
    {
        for (int i = 0; i < Monsters.Count; i++)
        {
            if (!Monsters[i].IsDying || !Monsters[i].IsEscaping)
            {
                return false;
            }
        }
        return true;
    }

    public void ApplyPreTurnLogic()
    {
        for (int i = 0; i < Monsters.Count; i++)
        {
            if (!Monsters[i].IsDying&&!Monsters[i].IsEscaping)
            {
                if (!Monsters[i].IsHasPower("Barricade"))
                {
                    Monsters[i].LoseBlock();
                }
                Monsters[i].ApplyStartOfTurnPowers();
            }
        }
    }

    public AbstractMonster GetMonster(string _id)
    {
        AbstractMonster tMonster=null;
        for (int i = 0; i < Monsters.Count; i++)
        {
            if (Monsters[i].Id == _id)
            {
                tMonster= Monsters[i];
            }
        }
        return tMonster;
    }

    public void QueueMonsters()
    {
        for (int i = 0; i < Monsters.Count; i++)
        {
            if (Monsters[i].IsDeadOrEscaped()&&!Monsters[i].HalfDead)
            {
                AbstractDungeon.ActionManager.MonsterQueue.Add(new MonsterQueueItem(Monsters[i]));
            }
        }
    }

    public bool HaveMonstersEscaped()
    {
        for (int i = 0; i < Monsters.Count; i++)
        {
            if (!Monsters[i].IsEscaped)
            {
                return false;
            }
        }
        return true;
    }

    public bool IsMonstersEscaping()
    {
        for (int i = 0; i < Monsters.Count; i++)
        {
            if (Monsters[i].NextMove==99)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasMonsterEscaped()
    {
        for (int i = 0; i < Monsters.Count; i++)
        {
            if (Monsters[i].IsEscaping)
            {
                return true;
            }
        }

        if (CardCrawlGame.Dungeon is c)
        {
            
        }
    }

   

    public void ShowIntent()
    {
        for (int i = 0; i < Monsters.Count; i++)
        {
            Monsters[i].CreateIntent();
        }
    }

}
