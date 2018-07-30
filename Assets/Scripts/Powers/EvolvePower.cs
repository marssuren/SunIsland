using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolvePower : AbstractPower
{
	public const string PowerId = "Evolve";
	public static string Name;
	public static string[] Descriptions;

	public EvolvePower(AbstractCreature _owner,int _drawAmt)
	{
		name = Name;
		ID = "Evolve";
		Owner = _owner;
		Amount = _drawAmt;
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


}
