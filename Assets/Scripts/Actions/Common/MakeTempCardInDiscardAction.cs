using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTempCardInDiscardAction : AbstractGameAction
{
    private AbstractCard cardToMake;
    private int numCards;

    public MakeTempCardInDiscardAction(AbstractCard _card,int _amount)
    {
        numCards = _amount;
        GameActionType = ActionType.CardManipulation;
        cardToMake = _card;
    }

}
