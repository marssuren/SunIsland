using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveInfo
{
    public byte NextMove;
    public Intent InfoIntent;
    public int BaseDamage;
    public int MultiPlayer;
    public bool IsMultiDamage;

    public EnemyMoveInfo(byte _nextMove, Intent _infoIntent, int _intentBaseDamage, int _multiPlayer,bool _isMultiDamage)
    {
        NextMove = _nextMove;
        InfoIntent = _infoIntent;
        BaseDamage = _intentBaseDamage;
        MultiPlayer = _multiPlayer;
        IsMultiDamage = _isMultiDamage;
    }

}
