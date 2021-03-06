﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractMonster : AbstractCreature
{
    public static string[] Text;
    public static string StingerKey;
    public static long StingerID;
    private const float deathTime = 1.8f;
    private const float escapeTime = 3f;
    protected const byte escape = 99;
    protected const byte Roll = 98;
    public float DeathTimer;
    protected Dictionary<byte, string> MoveSet;
    public bool IsEscaped;
    public bool IsEscapeNext;
    public EnemyType Type;
    private float hoverTime;
    public bool IsCannotEscape;
    public List<DamageInfo> DamageInfoList;
    private EnemyMoveInfo move;
    public List<byte> MoveHistory;
    public List<AbstractGameEffect> IntentFlash;
    private List<AbstractGameEffect> IntentVFX;
    public byte NextMove;

    public Intent MonsterIntent;
    public Intent TipIntent;
    private Texture intentImg;
    private Texture intentBg;
    private int intentDmg;
    private int intentBaseDmg;
    private int intentMultiAmt;
    private bool isMultiDmg;
    public string MoveName;
    public static string[] Moves;
    public static string[] Dialog;


    public static IEnumerator<AbstractMonster> SortByCollider;

    public AbstractMonster(string _name, string _id, int _maxHealth, string _imgURL) : this(_name, _id, _maxHealth,
        _imgURL, false)
    {
    }

    public AbstractMonster(string _name, string _id, int _maxHealth, string _imgURL, bool _isIgnoreBlights)
    {
        DeathTimer = 0f;
        IsEscaped = false;
        IsEscapeNext = false;
        Type = EnemyType.Normal;

        IsCannotEscape = false;
        DamageInfoList = new List<DamageInfo>();
        MonsterIntent = Intent.Debug;
        TipIntent = Intent.Debug;
        IsPlayer = false;
        Name = _name;
        Id = _id;
        MaxHealth = _maxHealth;
        CurrentHealth = MaxHealth;
        CurrentBlock = 0;

    }
    void Update()
    {
        if (powers.Count > 0)
        {
            AbstractPower tAbstractPower = powers[0];

        }

    }
    private void updateIntent()
    {

    }
    public void Heal(int _healAmount)
    {
        if (!IsDying)
        {
            AbstractPower tAbstractPower;

        }
    }

    public void CreateIntent()
    {
        MonsterIntent = move.InfoIntent;
        NextMove = move.NextMove;
        intentBaseDmg = move.BaseDamage;
        if (move.BaseDamage > -1)
        {
            calculateDamage(intentBaseDmg);
            if (move.IsMultiDamage)
            {
                intentMultiAmt = move.MultiPlayer;
                isMultiDmg = true;
            }
            else
            {
                intentMultiAmt = -1;
                isMultiDmg = false;
            }
        }

        //	    intentImg = getintentImg();
        updateIntentTip();
    }

    private void calculateDamage(int _dmg)
    {
        AbstractPlayer tTarget = AbstractDungeon.Player;
        float tDmg = _dmg;
        //if (tTarget)
        //{

        //}
        AbstractPower tPower;
        for (int i = 0; i < powers.Count; i++)
        {
            powers[i].AtDamageGive(tDmg, DamageType.Normal);
        }
        for (int i = 0; i < powers.Count; i++)
        {
            powers[i].AtDamageReceive(tDmg, DamageType.Normal);
        }
        for (int i = 0; i < powers.Count; i++)
        {
            powers[i].AtDamageFinalGive(tDmg, DamageType.Normal);
        }
        for (int i = 0; i < powers.Count; i++)
        {
            powers[i].AtDamageFinalReceive(tDmg, DamageType.Normal);
        }

        tDmg = Mathf.FloorToInt(tDmg);
        if (tDmg < 0)
        {
            tDmg = 0;
        }

        intentDmg = (int)tDmg;
    }

    protected abstract void GetMove(int _arg);
    public override void Damage(DamageInfo _info)
    {
        if (_info.Output > 0 && IsHasPower("IntangiblePlayer"))
        {
            _info.Output = 1;
        }

        int tDamageAmount = _info.Output;
        if (!IsDying && !IsEscaping)
        {
            if (tDamageAmount < 0)
            {
                tDamageAmount = 0;
            }

            bool isHadBlock = true;
            if (CurrentBlock == 0)
            {
                isHadBlock = false;
            }

            bool tWeakenedToZero = tDamageAmount == 0;
            tDamageAmount = DecrementBlock(_info, tDamageAmount);
            if (_info.Owner is AbstractPlayer)
            {
                for (int i = 0; i < AbstractDungeon.Player.Relics.Count; i++)
                {
                    AbstractDungeon.Player.Relics[i].OnAttack(_info, tDamageAmount, this);
                }
            }

            AbstractPower tAbstractPower;
            if (null != _info.Owner)
            {
                for (int i = 0; i < _info.Owner.powers.Count; i++)
                {
                    _info.Owner.powers[i].OnAttack(_info, tDamageAmount, this);
                }
            }
            for (int i = 0; i < powers.Count; i++)
            {
                tDamageAmount = powers[i].OnAttacked(_info, tDamageAmount);
            }

            for (int i = 0; i < AbstractDungeon.Player.Relics.Count; i++)
            {
                tDamageAmount = AbstractDungeon.Player.Relics[i].OnAttackedMonster(_info, tDamageAmount);
            }

            if (tDamageAmount > 0)
            {
                if (_info.Owner != this)
                {
                    UseStaggerAnimation();
                }

                if (tDamageAmount >= 99 && !CardCrawlGame.IsOverkill)
                {
                    CardCrawlGame.IsOverkill = true;
                }

                CurrentHealth -= tDamageAmount;
                //AbstractDungeon.EffectList.Add(new Strike);
                if (CurrentHealth < 0)
                {
                    CurrentHealth = 0;
                }

            }
            else if (tWeakenedToZero && CurrentBlock == 0)
            {
                if (isHadBlock)
                {
                    //AbstractDungeon.EffectList.Add(new );
                }
                else
                {
                    AbstractDungeon.EffectList.Add(new StrikeEffect(this, 0, 0, 0));
                }
            }
            //else if (tAbstractPower)
            //         {

            //         }
            if (CurrentHealth <= 0)
            {
                Die();
                if (AbstractDungeon.GetMonsters().AreMonstersBasicallyDead())
                {
                    AbstractDungeon.ActionManager.CleanCardQueue();
                }
            }

            if (CurrentBlock > 0)
            {
                LoseBlock();
                //AbstractDungeon.EffectList
            }
        }

    }


    public void init()
    {
        RollMove();
    }

    public void RollMove()
    {
        GetMove(AbstractDungeon.AIRng.Next(99));
    }

    protected bool LastMove(byte _move)
    {
        if (MoveHistory.Count == 0)
        {
            return false;
        }
        else
        {
            return _move == MoveHistory[MoveHistory.Count - 1];
        }
    }
    public abstract void TakeTurn();

    protected bool LastMoveBefore(byte _move)
    {
        if (MoveHistory.Count == 0)
        {
            return false;
        }
        if (MoveHistory.Count < 2)
        {
            return false;
        }
        return MoveHistory[MoveHistory.Count - 2] == _move;
    }

    protected bool LastTwoMoves(byte _move)
    {
        if (MoveHistory.Count < 2)
        {
            return false;
        }
        return (MoveHistory[MoveHistory.Count - 1] == _move) && (MoveHistory[MoveHistory.Count - 2] == _move);
    }

    //    private Image GetIntentImg()
    //    {
    //        switch (MonsterIntent)
    //        {
    //            case Intent.Attack:
    //                //return this.getAttackIntent();
    //            case Intent.AttackBuff:
    //                //return this.getAttackIntent();
    //            case Intent.AttackDebuff:
    //                //return this.getAttackIntent();
    //            case Intent.AttackDefend:
    //                //return this.getAttackIntent();
    //            case Intent.Buff:
    //                //return ImageMaster.INTENT_BUFF_L;
    //            case Intent.Debuff:
    //                //return ImageMaster.INTENT_DEBUFF_L;
    //            case Intent.StrongDebuff:
    //                //return ImageMaster.INTENT_DEBUFF2_L;
    //            case Intent.Defend:
    //                //return ImageMaster.INTENT_DEFEND_L;
    //            case Intent.DefendDebuff:
    //                //return ImageMaster.INTENT_DEFEND_L;
    //            case Intent.DefendBuff:
    //                //return ImageMaster.INTENT_DEFEND_BUFF_L;
    //            case Intent.Escape:
    //                //return ImageMaster.INTENT_ESCAPE_L;
    //            case Intent.Magic:
    //                //return ImageMaster.INTENT_MAGIC_L;
    //            case Intent.Sleep:
    //                //return ImageMaster.INTENT_SLEEP_L;
    //            case Intent.Stun:
    //                return null;
    //            case Intent.Unknown:
    //                //return ImageMaster.INTENT_UNKNOWN_L;
    //            default:
    //                //return ImageMaster.INTENT_UNKNOWN_L;
    //			return new Texture();
    //        }
    //    }
    private void updateIntentTip()
    {

    }
    public void ChangeState(string _stateName)
    {

    }

    protected void OnBossVictoryLogic()
    {
        AbstractDungeon.BossCount++;
        PlayBossStinger();
        for (int i = 0; i < AbstractDungeon.Blights.Count; i++)
        {
            AbstractDungeon.Blights[i].OnBossDefeat();
        }

        if (GameActionManager.Turn <= 1)
        {

        }

        if (GameActionManager.DamageReceivedThisCombat - GameActionManager.HpLossThisCombat <= 0)
        {
            CardCrawlGame.Perfect++;
        }
    }
    protected void OnFinalBossVictoryLogic()
    {
        CardCrawlGame.StopClock = true;
        if (CardCrawlGame.PlayTime <= 1200f)
        {

        }

        if (AbstractDungeon.Player.MasterDeck.Size() <= 5)
        {
            //UnlockTracker.un
        }

        bool tIsCommonSenseUnlocked = true;
        for (int i = 0; i < AbstractDungeon.Player.MasterDeck.Group.Count; i++)
        {

        }
    }

    public static void PlayBossStinger()
    {

    }

    public void DeathReact()
    {

    }
    public  void Escape()
    {
        IsEscaping = true;

    }
    public void Die()
    {

    }
    public void Die(bool _isTriggerRelics)
    {
        if (!IsDying)
        {
            IsDying = true;
            if (CurrentHealth <= 0)
            {
                for (int i = 0; i < powers.Count; i++)
                {
                    powers[i].OnDeath();
                }
            }

            if (_isTriggerRelics)
            {
                for (int i = 0; i < AbstractDungeon.Player.Relics.Count; i++)
                {
                    AbstractDungeon.Player.Relics[i].OnMonsterDeath(this);
                }
            }

            if (AbstractDungeon.GetMonsters().AreMonstersBasicallyDead())
            {
                //AbstractDungeon.OverLayMenu
                for (int i = 0; i < AbstractDungeon.Player.Limbo.Group.Count; i++)
                {
                    AbstractDungeon.EffectList.Add(new ExhaustCardEffect(AbstractDungeon.Player.Limbo.Group[i]));
                }
                AbstractDungeon.Player.Limbo.Group.Clear();
            }

            if (CurrentHealth < 0)
            {
                CurrentHealth = 0;
            }
        }
    }
}
public enum EnemyType
{
    None = 0,
    Normal = 1,
    Elite = 2,
    Boss = 3,
}
public enum Intent		//意图
{
    None = 0,
    Attack = 1,
    AttackBuff = 2,
    AttackDebuff = 3,
    AttackDefend = 4,
    Buff = 5,
    Debuff = 6,
    StrongDebuff = 7,
    Debug = 8,
    Defend = 9,
    DefendDebuff = 10,
    DefendBuff = 11,
    Escape = 12,
    Magic = 13,
    Sleep = 14,
    Stun = 15,      //昏迷
    Unknown = 16

}
