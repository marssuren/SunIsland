using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDrawPower : AbstractPower
{
	public const string PowerId = "NoDraw";
	public static string Name;
	public static string[] Descriptions;

	public NoDrawPower(AbstractCreature _owner)
	{
		name = Name;
		Owner = _owner;
		Amount = -1;
		Description = Descriptions[0];
	}

	public void AtEndOfTurn(bool _isPlayer)
	{
		if (_isPlayer)
		{
			AbstractDungeon.ActionManager.AddToBottom(new RemoveSpecificPowerAction(Owner,Owner,"NoDraw"));
		}
	}


}
