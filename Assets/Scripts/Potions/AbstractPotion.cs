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
        return AbstractDungeon.GetCurrRoom().Monsters != null &&
               !AbstractDungeon.GetCurrRoom().Monsters.AreMonstersBasicallyDead() &&
               !AbstractDungeon.ActionManager.IsTurnHasEnded && AbstractDungeon.GetCurrRoom().Phase == RoomPhase.Combat;

    }

    public abstract int GetPotency(int _arg);

    public int GetPotency()
    {
        return GetPotency(AbstractDungeon.ascensionLevel);
    }

    public abstract AbstractPotion MakeCopy();
}

public enum PotionRarity
{
    None = 0,
    PlaceHolder = 1,
    Common = 2,
    UnCommon = 3,
    Rare = 4,
}

public enum PotionColor
{
    None = 0,
    Poison = 1,
    Blue = 2,
    Fire = 3,
    Green = 4,
    Explosive = 5,
    Weak = 6,
    Fear = 7,
    Strength = 8,
    White = 9,
    Fairy = 10,
    Ancient = 11,
    Elixir = 12,
    Energy = 13,
    Swift = 14,
    Fruit = 15,
    Snecko = 16,
    Smoke = 17,
    Steroid = 18,
    Skill = 19,
    Attack = 20,
    Power = 21,

}

public enum PotionSize
{
    None = 0,
    T = 1,
    S = 2,
    M = 3,
    Sphere = 4,
    H = 5,
    Bottle = 6,
    Heart = 7,
    Snecko = 8,
    Fairy = 9,
    Ghost = 10,
    Jar = 11,
    Bolt = 12,
    Card = 13

}
