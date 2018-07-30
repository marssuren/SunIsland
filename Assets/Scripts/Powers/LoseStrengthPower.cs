using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseStrengthPower : AbstractPower
{
	public const string PowerId = "Flex";
	public static string Name;
	public static string[] Descriptions;

	public LoseStrengthPower(AbstractCreature _owner,int _amount)
	{
		name = Name;
		ID = "Flex";
		Owner = _owner;
		Amount = _amount;
		UpdateDescription();
	}

	public void UpdateDescription()
	{
		Description = Descriptions[0] + Amount + Descriptions[1];

	}

	public void AtEndOfTurn(bool _isPlayer)
	{
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(Owner,Owner,new StrengthPower(Owner,-Amount),-Amount));
		AbstractDungeon.ActionManager.AddToBottom(new RemoveSpecificPowerAction(Owner,Owner,"Flex"));
	}
}
