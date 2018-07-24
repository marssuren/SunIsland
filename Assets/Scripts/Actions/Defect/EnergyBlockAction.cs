using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBlockAction : AbstractGameAction
{
    private bool isUpgraded;

    public EnergyBlockAction(bool _isUpgraded)
    {
        isUpgraded = _isUpgraded;
    }

}
