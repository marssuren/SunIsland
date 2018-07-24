using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnClearAction : MonoBehaviour
{
    private AbstractMonster monster;

    public LockOnClearAction(AbstractMonster _monster)
    {
        monster = _monster;
    }

}
