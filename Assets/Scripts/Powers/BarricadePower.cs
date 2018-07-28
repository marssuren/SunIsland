using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadePower : AbstractPower
{
	public const string PowerId = "Barricade";
	public static string Name;
	public static string[] Descriptions;

	public BarricadePower(AbstractCreature _owner)
	{
		name = Name;
		ID = "Barricade";
		Owner = _owner;
		UpdateDescription();

	}

	public void UpdageDescription()
	{
		if (Owner.IsPlayer)
		{
			Description = Descriptions[0];
		}
		else
		{
			Description = Descriptions[1];
		}
	}

}
