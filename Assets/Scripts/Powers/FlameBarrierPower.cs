using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameBarrierPower : AbstractPower
{
	public const string Id = "FlameBarrier";
	public static string Name;
	public static string[] Descritions;
	private DamageInfo thornsInfo;

	public FlameBarrierPower(AbstractCreature _owner,int _thornsDamage)
	{
		name = Name;
		ID = "FlameBarrier";
		Owner = _owner;
		Amount = _thornsDamage;
		UpdateDescription();
		thornsInfo=new DamageInfo(Owner,Amount,DamageType.Thorns);
	}

	public void StackPower(int _stackAmount)
	{
		if (Amount==-1)
		{
			
		}
		else
		{
			Amount += _stackAmount;
			thornsInfo=new DamageInfo(Owner,Amount,DamageType.Thorns);
			UpdateDescription();
		}
	}

	public int OnAttacked(DamageInfo _info, int _damageAmount)
	{
		if (_info.Owner!=null&&_info.Type!=DamageType.Thorns&&_info.Type!=DamageType.HpLoss&&_info.Owner!=Owner)
		{
			AbstractDungeon.ActionManager.AddToTop(new DamageAction(_info.Owner,thornsInfo,AttackEffect.Fire));
		}

		return _damageAmount;
	}

	public void AtStartOfTurn()
	{
		AbstractDungeon.ActionManager.AddToBottom(new RemoveSpecificPowerAction(AbstractDungeon.Player,AbstractDungeon.Player,"FlameBarrier"));
	}

	public void UpdateDescription()
	{
		Description = Descritions[0] + Amount + Descritions[1];
	}
}
