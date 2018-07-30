using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleCardNextTurnPower : AbstractPower
{
	public const string PowerId = "DrawCard";
	public static string Name;
	public static string[] Descriptions;

	public DoubleCardNextTurnPower(AbstractCreature _owner,int _drawAmount)
	{
		name = Name;
		ID = "DrawCard";
		Owner = _owner;
		Amount = _drawAmount;
		UpdateDescription();
		Priority = 20;
	}

	public void UpdateDescription()
	{
		//flash
		AbstractDungeon.ActionManager.AddToBottom(new DrawCardAction(Owner,Amount));
		AbstractDungeon.ActionManager.AddToBottom(new RemoveSpecificPowerAction(Owner,Owner,"DrawCard"));
	}
}
