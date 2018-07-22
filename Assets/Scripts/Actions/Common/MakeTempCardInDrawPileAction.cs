using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTempCardInDrawPileAction : AbstractGameAction
{
    private AbstractCard cardToMake;
    private bool isRandomSpot;
    private bool isCardOffset;

    public MakeTempCardInDrawPileAction(AbstractCard _card, int _amount, bool _isRandomSpot, bool _isCardOffset)
    {
        SetValues(Target, Source, _amount);
        GameActionType = ActionType.CardManipulation;
        cardToMake = _card;
        isRandomSpot = _isRandomSpot;
        isCardOffset = _isCardOffset;
    }

}
