using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifyDamageAction : AbstractGameAction
{
    private AbstractCard cardToModify;

    public ModifyDamageAction(AbstractCard _card,int _amount)
    {
        SetValues(Target,Source,_amount);
        GameActionType = ActionType.CardManipulation;
        cardToModify = _card;
    }


}
