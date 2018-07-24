using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeprecatedProtectiveNanitesAction : AbstractGameAction
{
    private bool isFreeToPlayOnce;
    private bool isUpgraded;
    private AbstractPlayer player;
    private int energyOnUse;

    public DeprecatedProtectiveNanitesAction(AbstractPlayer _player,bool _isUpgraded,bool _isFreeToPlayOnce,int _energyOnUse)
    {
        player = _player;
        isUpgraded = _isUpgraded;
        isFreeToPlayOnce = _isFreeToPlayOnce;
        GameActionType = ActionType.Special;
        energyOnUse = _energyOnUse;
    }

}
