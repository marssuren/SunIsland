using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleAction : AbstractGameAction
{
    private CardGroup group;

    public ShuffleAction(CardGroup _cardGroup)
    {
        SetValues(null,null,0);
        GameActionType = ActionType.Shuffle;
        group = _cardGroup;
    }

}
