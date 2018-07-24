using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseMaxOrbAction : AbstractGameAction
{
    public DecreaseMaxOrbAction(int _slotDecrease)
    {
        Amount = _slotDecrease;
        GameActionType = ActionType.Block;
    }
	
}
