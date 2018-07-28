using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitAction : AbstractGameAction
{
	public WaitAction(float _setDur)
	{
		SetValues(null, null, 0);
		GameActionType = ActionType.Wait;
	}
	public void Upgrade()
	{ }


}
