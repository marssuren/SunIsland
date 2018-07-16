using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicAboveCreatureAction : AbstractGameAction
{
    private bool isUsed = false;
    private AbstractRelic relic;

    public RelicAboveCreatureAction(AbstractCreature _source,AbstractRelic _relic)
    {
        SetValues(_source,_source);
        relic = _relic;
        GameActionType = ActionType.Text;

    }

    public void DoUse()
    {
        if (!isUsed) 
        {
            //AbstractDungeon.EffectList.Add(new );
            isUsed = true;
        }
    }

}
