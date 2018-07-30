using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropkickAction : AbstractGameAction
{

	public DropkickAction(AbstractCreature _target)
	{
		GameActionType = ActionType.Block;
		Target = _target;
	}

	
}
