using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiendFireAction : AbstractGameAction
{
	private DamageInfo damageInfo;

	public FiendFireAction(AbstractCreature _target,DamageInfo _info)
	{
		damageInfo = _info;
		SetValues(_target,_info);
		GameActionType = ActionType.Wait;
		GameAttackEffect = AttackEffect.Fire;

	}

}
