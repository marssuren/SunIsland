using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObtainPotionAction : AbstractGameAction
{
    private AbstractPotion potion;

    public ObtainPotionAction(AbstractPotion _potion)
    {
        GameActionType = ActionType.Special;
        potion = _potion;
    }


}
