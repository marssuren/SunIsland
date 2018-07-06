using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractRelic : IComparable<AbstractRelic>
{
    public static string[] Msg;
    public static string[] Label;
    public readonly string Name;
    public readonly string relicId;
    private readonly string[] Descriptions;
    public bool IsEnergyBased;
    public string Description;
    public int Cost;
    public int Counter = -1;
    public RelicTier Tier;
    public string ImgURL;
    protected bool IsPulse;
    public bool IsSeen;
    public bool IsDone;
    public bool IsDiscarded;

    public AbstractRelic(string _setId, string _imgName, RelicTier _tier, LandingSound _sfx)
    {
        IsPulse = false;
        IsDone = false;
        relicId = _setId;

    }

    public void OnUsePotion()
    {

    }
    public void OnUseCard(AbstractCard _targetCard, UseCardAction _useCardAction)
    {

    }
    public void OnLoseHp(int _damageAmount)
    {

    }

    public int CompareTo(AbstractRelic other)
    {
        throw new NotImplementedException();
    }
	public void OnChestOpen(bool _isBossChest)
	{

	}
}

public enum RelicTier
{
    None = 0,
    Deprecated = 1,
    Starter = 2,
    Common = 3,
    Uncommon = 4,
    Rare = 5,
    Special = 6,
    Boss = 7,
    Shop = 8,
}

public enum LandingSound
{
    None = 0,
    Clink = 1,
    Heavy = 2,
    Magical = 3,
    Solid = 4,
}
