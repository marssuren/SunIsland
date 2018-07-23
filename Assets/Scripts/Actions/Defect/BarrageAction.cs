using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageAction : MonoBehaviour
{
    private DamageInfo damageInfo;
    private AbstractCreature target;

    public BarrageAction(AbstractCreature _monster,DamageInfo _info)
    {
        damageInfo = _info;
        target = _monster;
    }

}
