using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReducePowerAction : AbstractGameAction
{
    private string powerId;

    public ReducePowerAction(AbstractCreature _target, AbstractCreature _source, string _power, int _amount)
    {
        SetValues(_target, _source, _amount);
        powerId = _power;
        GameActionType = ActionType.ReducePower;
    }

    public void DoUse()
    {
        for (int i = 0; i < Target.powers.Count; i++)
        {
            if (Target.powers[i].ID.Equals(powerId))
            {
                if (Amount < Target.powers[i].Amount)
                {
                    Target.powers[i].ReducePower(Amount);
                    Target.powers[i].UpdateDescription();
                    AbstractDungeon.OnModifyPower();
                }
                else
                {
                    AbstractDungeon.ActionManager.AddToTop(new RemoveSpecificPowerAction(Target, Source, powerId));
                }
                break;
            }
        }
    }

}
