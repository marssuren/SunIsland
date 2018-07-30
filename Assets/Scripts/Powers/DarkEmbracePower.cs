using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEmbracePower : AbstractPower
{
	public const string PowerId = "DarkEmbrace";
	public static string Name;
	public static string[] Descriptions;

	public DarkEmbracePower(AbstractCreature _owner,int _amount)
	{
		name = Name;
		ID = "DarkEmbrace";
		Owner = _owner;
		Amount = _amount;
		UpdateDescription();
	}

	public void UpdateDescription()
	{
		if (Amount==1)
		{
			Description = Descriptions[0];

		}
		else
		{
			Description = Descriptions[1] + Amount + Descriptions[2];
		}
	}

	public void OnExhaust(AbstractCard _card)
	{
		if (!AbstractDungeon.GetMonsters().AreMonstersBasicallyDead())
		{
			//flash
			AbstractDungeon.ActionManager.AddToBottom(new DrawCardAction(Owner,Amount));
		}
	}



}
