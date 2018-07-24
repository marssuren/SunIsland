using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReinForceBodyAction : AbstractGameAction
{
    public int[] MultiDamage;
    private bool isFreeToPlayOnce;
    private AbstractPlayer player;
    private int energyOnUse = -1;

    public ReinForceBodyAction(AbstractPlayer _player,int _amount,bool _isFreeToPlayOnce,int _energyOnUse)
    {
        Amount = _amount;
        player = _player;
        isFreeToPlayOnce = _isFreeToPlayOnce;
        GameActionType = ActionType.Special;
        energyOnUse = _energyOnUse;


    }

}
