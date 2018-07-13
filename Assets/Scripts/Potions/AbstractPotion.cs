using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPotion : MonoBehaviour
{
	public readonly string[] Text;
	public string Id;
	public string Name;
	public string Description;
	public int Slot = -1;
	public bool IsObtained;
	protected bool IsCanUse;
	public bool Discarded;
	public bool IsThrown;
	public bool IsTargetRequired;
    public PotionRarity Rarity;

	

    public void SetAsObtained(int _slot)
    {
        Slot = _slot;
        IsObtained = true;
        
    }

    public void AdjustPosition(int _slot)
    {

    }

    public int GetPrice()
    {
        switch (Rarity)
        {
            case PotionRarity.None:
                return 999;
            case PotionRarity.Common:
                return 50;
            case PotionRarity.UnCommon:
                return 75;
            case PotionRarity.Rare:
                return 100;
            default:
                return 999;
        }
    }

    public abstract void Use(AbstractCreature _creature);
    public bool CanUse()
    {
        return AbstractDungeon.GetCurrRoom().Monsters != null && !AbstractDungeon.GetCurrRoom().Monsters.

    }

    public abstract int GetPotency(int _arg);

    public int GetPotency()
    {
        return GetPotency(AbstractDungeon.as)
    }
}

public enum PotionRarity
{
    None=0,
    PlaceHolder=1,
    Common=2,
    UnCommon=3,
    Rare=4,
}
