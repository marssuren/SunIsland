using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhaustSpecificCardAction : AbstractGameAction
{
    private AbstractCard targetCard;
    private CardGroup group;

    public ExhaustSpecificCardAction(AbstractCard _targetCard,CardGroup _group,bool _isFast)
    {
        targetCard = _targetCard;
        SetValues(AbstractDungeon.Player,AbstractDungeon.Player,Amount);
        GameActionType = ActionType.Exhaust;
        group = _group;

    }

    public ExhaustSpecificCardAction(AbstractCard _targetCard,CardGroup _group):this(_targetCard,_group,false)
    {
        
    }

}
