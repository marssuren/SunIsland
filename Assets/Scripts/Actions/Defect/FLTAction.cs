using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLTAction : AbstractGameAction
{
    private DamageInfo info;
    private AbstractCreature target;
    private int cardPlayCount = 0;

    public FLTAction(AbstractCreature _target,DamageInfo _info,int _cardPlayCount)
    {
        info = _info;
        target = _target;
        cardPlayCount = _cardPlayCount;
    }

}
