using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDontTriggerAction : AbstractGameAction
{
    private AbstractCard card;
    private bool isTrigger;

    public SetDontTriggerAction(AbstractCard _card,bool _isDontTrigger)
    {
        card = _card;
        isTrigger = _isDontTrigger;
    }

}
