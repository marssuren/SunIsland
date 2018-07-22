using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceCostAction : AbstractGameAction
{
    private AbstractCard card;

    public ReduceCostAction(AbstractCard _card,int _amout)
    {
        card = _card;
        Amount = _amout;

    }

}
