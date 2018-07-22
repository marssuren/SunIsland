using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardSpecificCardAction : AbstractGameAction
{
    private AbstractCard targetCard;

    public DiscardSpecificCardAction(AbstractCard _card)
    {
        targetCard = _card;
        GameActionType = ActionType.Discard;

    }

}
