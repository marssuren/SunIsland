using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrutalityPower : AbstractPower
{
	public const string PowerId = "Brutality";
	public static string Name;
	public static string[] Description;

	public BrutalityPower(AbstractCreature _owner,int _drawAmount)
	{
		name = Name;
		ID = "Brutality";
		Owner = _owner;
		Amount = _drawAmount;
		UpdateDescription();
	}

	public void UpdateDescription()
	{
		AbstractDungeon.ActionManager.AddToBottom(new DrawCardAction(Owner,Amount));
		AbstractDungeon.ActionManager.AddToBottom(new LoseHPAction(Owner,Owner,Amount));
	}

}
