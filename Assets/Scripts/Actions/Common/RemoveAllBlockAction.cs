using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveAllBlockAction : AbstractGameAction
{
    public RemoveAllBlockAction(AbstractCreature _target,AbstractCreature _source)
    {
        SetValues(_target,_source,Amount);
        GameActionType = ActionType.Block;
    }
	
}
