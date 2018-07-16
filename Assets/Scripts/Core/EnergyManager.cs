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
			if (EnergyPanel.TotalCount>0)
			{
				//AbstractDungeon.Player.GetRelic("IceCream").Flash();
				AbstractDungeon.ActionManager.
			}
		}
	}
}
