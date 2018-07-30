using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedAction : AbstractGameAction
{
	private int increaseHpAmount;
	private DamageInfo info;

	public FeedAction(AbstractCreature _target,DamageInfo _info,int _maxHpAmount)
	{
		info = _info;
		SetValues(_target,_info);
		increaseHpAmount = _maxHpAmount;
		GameActionType = ActionType.Damage;

	}

}
