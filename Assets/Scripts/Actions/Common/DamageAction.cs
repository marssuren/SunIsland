using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageAction : AbstractGameAction
{
    private DamageInfo damageInfo;
    private int goldAmount;
    private bool isSkipWait;

    public DamageAction(AbstractCreature _target, DamageInfo _info, AttackEffect _effect)
    {
        goldAmount = 0;
        isSkipWait = false;
        damageInfo = _info;
        SetValues(_target, _info);
        GameActionType = ActionType.Damage;
        GameAttackEffect = _effect;

    }

    public DamageAction(AbstractCreature _target, DamageInfo _info, int _stealGoldAmount) : this(_target, _info,
        AttackEffect.SlashDiagonal)
    {
        goldAmount = _stealGoldAmount;
    }

    public DamageAction(AbstractCreature _target,DamageInfo _info):this(_target,_info,AttackEffect.None)
    {
        
    }

    public DamageAction(AbstractCreature _target,DamageInfo _info,bool _isSuperFast):this(_target,_info,AttackEffect.None)
    {
        isSkipWait = true;
    }

    public DamageAction(AbstractCreature _target,DamageInfo _info,AttackEffect _effect,bool _isSuperFast):this(_target,_info,_effect)
    {
        isSkipWait = true;
    }

    private void stealGold()
    {
        if (Target.Gold!=0)
        {
            if (Target.Gold<goldAmount)
            {
                goldAmount = Target.Gold;
            }

            Target.Gold -= goldAmount;
            for (int i = 0; i < goldAmount; i++)
            {
                if (Source.IsPlayer)
                {
                    //AbstractDungeon.EffectList.Add(new GainPennyEffect);
                }
            }
        }
    }


}
