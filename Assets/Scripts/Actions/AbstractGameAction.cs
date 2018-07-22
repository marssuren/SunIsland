using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGameAction
{
    protected float Duration;
    protected float StartDuration;
    public ActionType GameActionType;
    public AttackEffect GameAttackEffect;
    public DamageType GameDamageType;
    public bool IsDone;
    public int Amount;
    public AbstractCreature Target;
    public AbstractCreature Source;

    public AbstractGameAction()
    {
        GameAttackEffect = AttackEffect.None;
        IsDone = false;
    }
    protected void SetValues(AbstractCreature _target, DamageInfo _info)
    {
        Target = _target;
        Source = _info.Owner;
        Amount = _info.Output;
        Duration = 0.5f;
    }
    protected void SetValues(AbstractCreature _target, AbstractCreature _source, int _amount)
    {
        Target = _target;
        Source = _source;
        Amount = _amount;
        Duration = 0.5f;
    }
    protected void SetValues(AbstractCreature _target, AbstractCreature _source)
    {
        Target = _target;
        Source = _source;
        Amount = 0;
        Duration = 0.5f;
    }
    protected bool IsDeadOrEscaped(AbstractCreature _target)
    {
        if (!_target.IsDying && !_target.HalfDead)
        {
            if (!_target.IsPlayer)
            {
                AbstractMonster tAbstractMonster = (AbstractMonster)_target;
                if (tAbstractMonster.IsEscaping)
                {
                    return true;
                }
            }
            return false;
        }
        return true;
    }

    protected bool ShouldCancelAction()
    {
        return Target == null || Source != null && Source.IsDying || Target.IsDeadOrEscaped();
    }
}
public enum ActionType
{
    None = 0,
    Block = 1,
    Power=2,
    CardManipulation = 3,
    Damage = 4,
    Debuff = 5,
    Discard = 6,
    Draw = 7,
    Exhaust =8,
    Heal = 9,
    Energy = 10,
    Text = 11,
    Use = 12,
    ClearCardQueue = 13,
    Dialog = 14,
    Special = 15,
    Wait = 16,
    Shuffle = 17,
    ReducePower = 18,
}
public enum AttackEffect
{
    None = 0,
    BluntLigt = 1,
    BluntHeavy = 2,
    SlashDiagonal = 3,
    Smash = 4,
    SlashHeavy = 5,
    SlashHorizontal = 6,
    SlashVertical = 7,
    Fire = 8,
    Poison = 9,
    Shield = 10,
}
