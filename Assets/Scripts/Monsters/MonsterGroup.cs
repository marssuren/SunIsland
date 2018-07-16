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

        if (CardCrawlGame.Dungeon is TheCity)
        {
	        return true;
        }

	    return false;
    }
	public AbstractMonster GetRandomMonster()
	{
		return GetRandomMonster(null, false);
	}
	public AbstractMonster GetRandomMonster(bool _isAliveOnly)
	{
		return GetRandomMonster(null, _isAliveOnly);
	}
	public AbstractMonster GetRandomMonster(AbstractMonster _exception, bool _isAliveOnly)
	{
		if (AreMonstersBasicallyDead())
		{
			return null;
		}
		else
		{
			List<AbstractMonster> tempList;
			AbstractMonster tAbstractMonster;
			if (null==_exception)
			{
				if (_isAliveOnly)
				{
					tempList=new List<AbstractMonster>();
					for (int i = 0; i < Monsters.Count; i++)
					{
						if (Monsters[i].HalfDead&&!Monsters[i].IsDying&&!Monsters[i].IsEscaping)
						{
							tempList.Add(Monsters[i]);
						}
					}
					if (tempList.Count<=0)
					{
						return null;
					}
					return tempList[Random.Range(0, tempList.Count)];
				}
				return Monsters[Random.Range(0, Monsters.Count)];
			}
			if(Monsters.Count==1)
			{
				return Monsters[0];
			}

			if (_isAliveOnly)
			{
				List<AbstractMonster> tLst=new List<AbstractMonster>();
				for (int i = 0; i < Monsters.Count; i++)
				{
					if (!Monsters[i].HalfDead&&!Monsters[i].IsDying&&!Monsters[i].IsEscaping&&!_exception.Equals(Monsters[i]))
					{
						tLst.Add(Monsters[i]);
					}
				}
				if (tLst.Count==0)
				{
					return null;
				}
				return tLst[Random.Range(0, tLst.Count)];
			}
			else
			{
				List<AbstractMonster> tLst=new List<AbstractMonster>();
				for (int i = 0; i < Monsters.Count; i++)
				{
					if (!_exception.Equals(Monsters[i]))
					{
						tLst.Add(Monsters[i]);
					}
				}
				return tLst[Random.Range(0, tLst.Count)];
			}
		}
	}
	public void Escape()
	{
		for (int i = 0; i < Monsters.Count; i++)
		{
			Monsters[i].Escape();
		}
	}
   

    public void ShowIntent()
    {
        for (int i = 0; i < Monsters.Count; i++)
        {
            Monsters[i].CreateIntent();
        }
    }

    public void Init()
    {
        for (int i = 0; i < Monsters.Count; i++)
        {
            Monsters[i].init();
        }
    }
}
