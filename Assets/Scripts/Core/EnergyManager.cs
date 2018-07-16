using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager
{
    public int Energy;
    public int EnergyMaster;

    public EnergyManager(int _energy)
    {
        EnergyMaster = _energy;
    }
    public void Prep()
    {
        Energy = EnergyMaster;
        EnergyPanel.TotalCount = 0;

    }
    public void Recharge()
    {
        if (AbstractDungeon.Player.HasRelic("IceCream"))
        {
            if (EnergyPanel.TotalCount > 0)
            {
                //AbstractDungeon.Player.GetRelic("IceCream").Flash();
                AbstractDungeon.ActionManager.AddToTop(new RelicAboveCreatureAction(AbstractDungeon.Player, AbstractDungeon.Player.GetRelic("IceCream")));
            }
            EnergyPanel.AddEnergy(Energy);
        }
        else if (AbstractDungeon.Player.IsHasPower("Conserve"))
        {
            if (EnergyPanel.TotalCount > 0)
            {
                AbstractDungeon.ActionManager.AddToTop(new ReducePowerAction(AbstractDungeon.Player, AbstractDungeon.Player, "Conserve", 1));
            }
            EnergyPanel.AddEnergy(Energy);
        }
        else
        {
            EnergyPanel.SetEnergy(Energy);
        }
        AbstractDungeon.ActionManager.UpdateEnergyGain(Energy);
    }

    public void Use(int _e)
    {
        EnergyPanel.UseEnergy(_e);
    }
}
