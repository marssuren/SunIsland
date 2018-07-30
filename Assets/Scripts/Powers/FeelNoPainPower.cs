using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelNoPainPower : AbstractPower
{
	public const string PowerId = "FeelNoPain";
	public static string Name;
	public static string[] Descriptions;

	public FeelNoPainPower(AbstractCreature _owner,int _amount)
	{
		name = Name;
		ID = "FeelNoPain";
		Owner = _owner;
		Amount = _amount;
		UpdateDescription();
	}

	public void UpdateDescription()
	{
		Description = Descriptions[0] + Amount + Descriptions[1];
	}

	public void OnExhaust(AbstractCard _card)
	{
		AbstractDungeon.ActionManager.AddToBottom(new GainBlockAction(Owner,Owner,Amount));
	}



}
