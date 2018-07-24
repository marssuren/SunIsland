using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMaxOrbAction : AbstractGameAction
{
    public IncreaseMaxOrbAction(int _slotIncrease)
    {
        Amount = _slotIncrease;
        GameActionType = ActionType.Block;
    }
	
}
