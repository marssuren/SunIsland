using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainBlockAction : AbstractGameAction
{
    public GainBlockAction(AbstractCreature _target,AbstractCreature _source,int _amount)
    {
        SetValues(_target,_source,_amount);
        GameActionType = ActionType.Block;

    }

    public GainBlockAction(AbstractCreature _target,AbstractCreature _source,int _amount ,bool _isSuperFast)
    {
        SetValues(_target,_source,_amount);
        GameActionType = ActionType.Block;

    }
}
