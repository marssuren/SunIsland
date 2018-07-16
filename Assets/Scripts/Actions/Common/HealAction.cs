using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealAction : AbstractGameAction
{
	public HealAction(AbstractCreature _target,AbstractCreature _source,int _amount)
	{
		SetValues(_target,_source,_amount);
		GameActionType = ActionType.Heal;

	}
	public void DoHeal()
	{
		Target.Heal(Amount);
	}
}
