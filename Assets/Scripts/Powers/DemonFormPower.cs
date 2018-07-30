using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonFormPower : AbstractPower
{
	public const string PowerId = "DemonFormPower";
	public static string Name;
	public static string[] Descriptions;

	public DemonFormPower(AbstractCreature _owner,int _strengthAmount)
	{
		name = Name;
		ID = "DemonForm";
		Owner = _owner;
		Amount = _strengthAmount;
		UpdateDescription();


	}

	public void UpdateDescription()
	{
		Description = Descriptions[0] + Amount + Descriptions[1];
	}

	public void AtStartOfTurnPostDraw()
	{
		//flash
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(Owner,Owner,new StrengthPower(Owner,Amount),Amount));
	}


}
