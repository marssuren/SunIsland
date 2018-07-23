using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMoveAction : AbstractGameAction
{
    private AbstractMonster monster;
    private byte nextMove;
    private Intent nextIntent;
    private int nextDamage;
    private string nextName;
    private int multiplier;
    private bool isMultiplier;

    public SetMoveAction(AbstractMonster _monster, string _moveName, byte _nextMove, Intent _intent, int _baseDamage, int _multiplierAmt, bool _isMultiplier)
    {
        isMultiplier = false;
        nextName = _moveName;
        nextMove = _nextMove;
        nextIntent = _intent;
        nextDamage = _baseDamage;
        monster = _monster;
        multiplier = _multiplierAmt;
        isMultiplier = _isMultiplier;
    }

    public SetMoveAction(AbstractMonster _monster, byte _nextMove, Intent _intent, int _baseDamage, int _multiplierAmt, bool _isMultiplier) : this(_monster, null, _nextMove, _intent, _baseDamage, _multiplierAmt, _isMultiplier)
    {

    }

    public SetMoveAction(AbstractMonster _monster, string _moveName, byte _nextMove, Intent _intent, int _baseDamage) : this(_monster, _moveName, _nextMove, _intent, _baseDamage, 0, false)
    {

    }

    public SetMoveAction(AbstractMonster _monster, string _moveName, byte _nextMove, Intent _intent) : this(_monster, _moveName, _nextMove, _intent, -1)
    {

    }
    public SetMoveAction(AbstractMonster _monster, byte _nextMove, Intent _intent, int _baseDamage) : this(_monster, null, _nextMove, _intent, _baseDamage)
    {

    }
    public SetMoveAction(AbstractMonster _monster, byte _nextMove, Intent _intent) : this(_monster, null, _nextMove, _intent, -1)
    {

    }



}
