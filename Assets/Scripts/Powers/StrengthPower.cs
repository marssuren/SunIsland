using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthPower : AbstractPower
{
    public const string PowerId = "Strength";
    public static string Name;

    public StrengthPower(AbstractCreature _owner, int _amount)
    {
        this.name = Name;
        ID = "Strength";
        Owner = _owner;
        Amount = _amount;
        if (Amount >= 999)
        {
            Amount = 999;
        }

        if (Amount <= -999)
        {
            Amount = -999;
        }

        IsCanGoNegative = true;
    }

    public void StackPower(int _stackAmount)        //叠加力量
    {
        Amount += _stackAmount;
        if (Amount == 0)
        {
            AbstractDungeon.ActionManager.AddToTop(new RemoveSpecificPowerAction(Owner, Owner, "Strength"));
        }

        if (Amount >= 50)
        {

        }

        if (Amount >= 999)
        {
            Amount = 999;
        }

        if (Amount <= -999)
        {
            Amount = -999;
        }
    }

    public void ReducePower(int _reduceAmount)
    {
        Amount -= _reduceAmount;
        if (Amount == 0)
        {
            AbstractDungeon.ActionManager.AddToTop(new RemoveSpecificPowerAction(Owner, Owner, Name));
        }

        if (Amount >= 999)
        {
            Amount = 999;

        }

        if (Amount <= -999)
        {
            Amount = -999;
        }

    }

    public float AtDamageGive(float _damage, DamageType _type)
    {
        return _type == DamageType.Normal ? _damage + Amount : _damage;
    }
}
