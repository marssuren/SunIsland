using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleYourBlockAction : AbstractGameAction
{
	public DoubleYourBlockAction(AbstractCreature _target)
	{
		GameActionType = ActionType.Block;
		Target = _target;

	}
	
}
