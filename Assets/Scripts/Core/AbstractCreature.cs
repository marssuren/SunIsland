﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCreature : MonoBehaviour
{
    public string Name;
    public string Id;
    public List<AbstractPower> powers = new List<AbstractPower>();
    public bool IsPlayer;
    public bool IsBloodied;
    public float drawX;
    public float drawY;
    public float dialogX;
    public float dialogY;

    public int Gold;
    public int DisplayGold;
    public const int Damage_Flash_Frames = 4;
    public bool IsDamageFlash;
    public int DamageFlashFrames;
    public bool IsDying;
    public bool IsDead;
    public bool HalfDead;
    protected bool FlipHorizontal;
    protected bool FlipVertical;
    public float escapeTime = 0f;
    public bool IsEscaping;


    public string[] Text;
    private float healthHideTimer = 0f;


    public int CurrentHealth;
    public int MaxHealth;
    public int CurrentBlock;
    private float healthBarWidth;
    private float targetHealthBarWidth;

    public abstract void Damage(DamageInfo _damageInfo);
    protected int DecrementBlock(DamageInfo _damageInfo, int _damageAmount)
    {
        if (_damageInfo.Type != DamageType.HpLoss && CurrentBlock > 0)
        {

        }

        return 0;
    }
    public void LoseGold(int _goldAmount)
    {
        if (_goldAmount > 0)
        {
            Gold -= _goldAmount;
            if (Gold < 0)
            {
                Gold = 0;
            }
        }
    }

    public void LoseBlock(int _amount,bool _isNoAnimation)
    {
        bool tIsEffect = false;
        if (CurrentBlock!=0)
        {
            tIsEffect = true;
        }

        CurrentBlock -= _amount;
        if (CurrentBlock<0)
        {
            CurrentBlock = 0;
        }

        if (CurrentBlock==0&&tIsEffect)
        {
            if (!_isNoAnimation)
            {
                //AbstractDungeon.EffectList.Add(new HbBlockBrokenEffect());
            }
        }
    }

    
    public void LoseBlock()
    {
        LoseBlock(CurrentBlock);
    }
    public void LoseBlock(bool _isNoAnimation)
    {
        LoseBlock(CurrentBlock,_isNoAnimation);
    }
    public void LoseBlock(int _amount)
    {
        LoseBlock(_amount,false);
    }

    public void AddPower(AbstractPower _powerToApply)
    {
        bool tIsHasBuffAlready = false;
        for (int i = 0; i < powers.Count; i++)
        {
            if (powers[i].ID==_powerToApply.ID)
            {
                powers[i].StackPower(_powerToApply.Amount);
                powers[i].UpdateDescription();
                tIsHasBuffAlready = true;
            }
        }

        if (!tIsHasBuffAlready)
        {
            powers.Add(_powerToApply);
            if (IsPlayer)
            {
                int tBuffCount = 0;
                for (int i = 0; i < powers.Count; i++)
                {
                    if (powers[i].Type==PowerType.Buff)
                    {
                        tBuffCount++;
                    }
                }

                if (tBuffCount>=10)
                {
                    //UnlockTracker.unlockAchievement("POWERFUL");
                }
            }
        }
    }

    public void ApplyStartOfTurnPowers()
    {
        for (int i = 0; i < powers.Count; i++)
        {
            powers[i].AtStartOfTurn();
        }
    }

    public void ApplyTurnPowers()
    {
        for (int i = 0; i < powers.Count; i++)
        {
            powers[i].DuringTurn();
        }
    }

    public void ApplyStartOfTurnPostDrawPowers()
    {
        for (int i = 0; i < powers.Count; i++)
        {
            powers[i].AtStartOfTurnPostDraw();
        }
    }
    public void ApplyEndOfTurnTriggers()
    {
        for (int i = 0; i < powers.Count; i++)
        {
            powers[i].AtEndOfTurn(IsPlayer);
        }
    }

    //public void UpdatePowers()
    //{
    //    for (int i = 0; i < powers.Count; i++)
    //    {
    //        powers[i].upda
    //    }
    //}

    public void GainGold(int _amount)
    {
        if (_amount < 0)
        {

        }
        else
        {
            Gold += _amount;
        }
    }
   
    public bool IsHasPower(string _targetId)
    {
        for (int i = 0; i < powers.Count; i++)
        {
            if (powers[i].ID.Equals(_targetId))
            {
                return true;
            }
        }

        return false;
    }

    public bool IsDeadOrEscaped()
    {
        if (!IsDying && !HalfDead)
        {
            if (!IsPlayer)
            {
                if (((AbstractMonster)this).IsEscaping)
                {
                    return true;
                }

            }
            return false;
        }
        return true;
    }
    
}

public enum CreatureAnimation
{
    None=0,
    FastShake=1,
    Shake=2,
    AttackFast=3,
    AttackSlow=4,
    Stagger=5,
    Hop=6,
    Jump=7,
}
