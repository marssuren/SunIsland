using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GashAction : AbstractGameAction
{
    private AbstractCard card;

    public GashAction(AbstractCard _card,int _amount)
    {
        card = _card;
        Amount = _amount;
    }

}
