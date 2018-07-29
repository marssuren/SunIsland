using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombustPower : AbstractPower
{
	public const string PowerId = "Combust";
	public static string Name;
	public static string[] Descriptions;
	private int hpLoss;

	public CombustPower(AbstractCreature _owner,int _hpLoss,int _damageAmount)
	{
		name = Name;
		ID = "Combust";
		Owner = _owner;
		Amount = _damageAmount;
		hpLoss = _hpLoss;
		UpdateDescription();

	}

	public void AtEndOfTurn(bool _isPlayer)
	{
		if (!AbstractDungeon.GetMonsters().AreMonstersBasicallyDead())
		{
			//flash
			AbstractDungeon.ActionManager.AddToBottom(new LoseHPAction(Owner,Owner,hpLoss,AttackEffect.Fire));
			AbstractDungeon.ActionManager.AddToBottom(new DamageAllEnemiesAction(null,DamageInfo.CreateDamageMatrix(Amount,true),DamageType.Thorns,AttackEffect.Fire));
		}
	}

	public void StackPower(int _stackAmount)
	{
		Amount += _stackAmount;
		hpLoss++;
	}

	public void UpdateDescription()
	{
		Description = Descriptions[0] + hpLoss + Descriptions[1] + Descriptions[2];
	}

}
