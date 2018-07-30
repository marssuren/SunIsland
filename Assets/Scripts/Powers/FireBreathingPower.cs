using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathingPower : AbstractPower
{
	public const string PowerId = "FireBreathing";
	public static string Name;
	public static string[] Descriptions;

	public FireBreathingPower(AbstractCreature _owner,int _newAmount)
	{
		name = Name;
		ID = "FireBreathing";
		Owner = _owner;
		Amount = _newAmount;
		UpdateDescription();
	}

	public void UpdateDescription()
	{
		Description = Descriptions[0] + Amount + Descriptions[1];
	}

	public void AtEndOfTurn(bool _isPlayer)
	{
		int tCount = 0;
		AbstractCard tCard = null;
		for (int i = 0; i < AbstractDungeon.ActionManager.CardsPlayedThisTurn.Count; i++)
		{
			tCard = AbstractDungeon.ActionManager.CardsPlayedThisTurn[i];
			if (tCard.Type==CardType.Attack)
			{
				tCount++;
			}
		}

		if (tCount>0)
		{
			for (int i = 0; i < tCount; i++)
			{
				AbstractDungeon.ActionManager.AddToBottom(new DamageAllEnemiesAction(null,DamageInfo.CreateDamageMatrix(Amount,true),DamageType.Thorns,AttackEffect.Fire,true));
			}
		}
	}


}
