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

    public MonsterGroup(AbstractMonster _monster) : this(new AbstractMonster[] {_monster})
    {

    }

    public void ShowIntent()
    {
        for (int i = 0; i < Monsters.Count; i++)
        {
            Monsters[i].CreateIntent();
        }
    }

}
