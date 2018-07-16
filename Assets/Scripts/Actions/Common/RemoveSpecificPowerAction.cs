using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSpecificPowerAction : AbstractGameAction
{
    private string powerToRemove;
    private bool isPowerExists = false;
    private int powerLocation;


    public RemoveSpecificPowerAction(AbstractCreature _target,AbstractCreature _source,string _powerToRemove)
    {
        SetValues(_target,_source,Amount);
        GameActionType = ActionType.Debuff;
        powerToRemove = _powerToRemove;

    }

    public void DoUse()
    {
        if (Target.IsDeadOrEscaped())
        {
            IsDone = true;
            return;
        }

        for (int i = 0; i < Target.powers.Count; i++)
        {
            if (Target.powers[i].ID.Equals(powerToRemove))
            {
                isPowerExists = true;
                powerLocation = i;
            }
        }

        if (isPowerExists&&Target.powers.Count!=0)
        {
            Target.powers[powerLocation].OnRemove();
            Target.powers.RemoveAt(powerLocation);
            AbstractDungeon.OnModifyPower();
        }
    }

}
