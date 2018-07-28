using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BerserkPower : AbstractPower
{
	public const string PowerId = "Berserk";
	public static string Name;
	public static string[] Descriptions;

	public BerserkPower(string _name,AbstractCreature _owner,int _amount)
	{
		name = _name;
		ID = "Berserk";
		Owner = _owner;
		Amount = _amount;
		UpdateDescription();
	}

	public void UpdateDescription()
	{
		StringBuilder tStringBuilder=new StringBuilder();
		tStringBuilder.Append(Descriptions[0]);
		for (int i = 0; i < Amount; i++)
		{
			tStringBuilder.Append("[R]");
		}

		tStringBuilder.Append(Descriptions[1]);
		Description = tStringBuilder.ToString();

	}

	public void AtStartOfTurn()
	{
		if (Owner.IsPlayer&&Owner.CurrentHealth<=Owner.MaxHealth/2f)
		{
			AbstractDungeon.ActionManager.AddToBottom(new GainEnergyAction(Amount));
			
		}
	}

}
