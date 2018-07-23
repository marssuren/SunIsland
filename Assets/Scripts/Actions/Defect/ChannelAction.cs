using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelAction : AbstractGameAction
{
    private AbstractOrb orbType;
    private bool isAutoEvoke;

    public ChannelAction(AbstractOrb _newOrbType, bool _isAutoEvoke)
    {
        isAutoEvoke = false;
        orbType = _newOrbType;
        isAutoEvoke = _isAutoEvoke;
    }
    public ChannelAction(AbstractOrb _newOrbType)
    {

    }

}
