using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceWarAction : AbstractGameAction
{
    private int perOrbAmt;

    public IceWarAction(int _blockAmount,int _perOrbAmt)
    {
        Amount = _blockAmount;
        perOrbAmt = _perOrbAmt;
    }

}
