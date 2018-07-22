using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTempCardInHandAction : AbstractGameAction
{
    private AbstractCard card;
    private bool isOtherCardInCenter;

    public MakeTempCardInHandAction(AbstractCard _card, bool _isOtherCardInCenter)
    {
        isOtherCardInCenter = true;
        Amount = 1;
        GameActionType = ActionType.CardManipulation;
        card = _card;
        isOtherCardInCenter = _isOtherCardInCenter;
    }

    public MakeTempCardInHandAction(AbstractCard _card, int _amount)
    {
        isOtherCardInCenter = true;
        Amount = _amount;
        GameActionType = ActionType.CardManipulation;
        card = _card;
    }

    public MakeTempCardInHandAction(AbstractCard _card) : this(_card, 1)
    {

    }

    private void addToHand(int _handAmount)
    {
        int i;
        switch (Amount)
        {
            case 0:
                break;
            case 1:
                if (_handAmount == 1)
                {
                    if (isOtherCardInCenter)
                    {
                        //AbstractDungeon.EffectList.Add(new ShowCardAndAddToHandEffect());
                    }
                    else
                    {

                    }


                }
                break;
            case 2:
                if (_handAmount == 1)
                {
                        //AbstractDungeon.EffectList.Add(new ShowCardAndAddToHandEffect(tCard));
                }
                break;
        }
    }

    private void addToDiscard(int _discardAmount)
    {

    }
}
