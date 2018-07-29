using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorruptionPower : AbstractPower
{
	public const string Id = "Corruption";
	public static string Name;
	public static string[] Descriptions;

	public CorruptionPower(AbstractCreature _owner)
	{
		name = Name;
		ID = "Corruption";
		Owner = _owner;
		Amount = -1;
		Description = Descriptions[0];

	}

	public void UpdateDescription()
	{
		Description = Descriptions[1];
	}

	public void OnUseCard(AbstractCard _card, UseCardAction _action)
	{
		if (_card.Type==CardType.Skill)
		{
			//flash
			_action.IsExhaustCard = true;
		}
	}
}
