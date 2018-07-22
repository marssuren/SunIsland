using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTempCardInDiscardAndDeckAction : AbstractGameAction
{
    private AbstractCard cardToMake;

    public MakeTempCardInDiscardAndDeckAction(AbstractCard _card)
    {
        GameActionType = ActionType.CardManipulation;
        cardToMake = _card;

    }

}
