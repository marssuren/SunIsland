using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractRelic : IComparable<AbstractRelic>
{
    public static string[] Msg;
    public static string[] Label;
    public readonly string Name;
    public readonly string relicId;
    private readonly string[] Descriptions;
    public bool IsEnergyBased;
    public string Description;
    public int Cost;
    public int Counter = -1;
    public RelicTier Tier;
    public string ImgURL;
    protected bool IsPulse;
    public bool IsSeen;
    public bool IsDone;
    public bool IsDiscarded;

    public AbstractRelic(string _setId, string _imgName, RelicTier _tier, LandingSound _sfx)
    {
        IsPulse = false;
        IsDone = false;
        relicId = _setId;

    }

    public void OnEvokeOrb(AbstractOrb _ammo)
    {

    }

    public void OnPlayCard(AbstractCard _card, AbstractMonster _monster)
    {

    }

    public void OnObtainCard(AbstractCard _card)
    {

    }

    public void OnGainGold()
    {

    }

    public void OnLoseGold()
    {

    }

    public void OnEquip()
    {

    }

    public void OnUnEquip()
    {

    }

    public void AtPreBattle()
    {

    }

    public void AtBattleStart()
    {

    }

    public void AtBattleStartPreDraw()
    {

    }

    public void AtTurnStart()
    {

    }

    public void OnPlayerEndTurn()
    {

    }

    public void OnBloodied()
    {

    }

    public void OnNotBloodied()
    {

    }

    public int OnPlayerGainBlock(int _blockAmount)
    {
        return _blockAmount;
    }

    public int OnPlayerGainedBlock(float _blockAmount)
    {
        return Mathf.FloorToInt(_blockAmount);
    }

    public int OnPlayerHeal(int _healAmount)
    {
        return _healAmount;
    }

    public void OnMeditate()
    {

    }

    public void OnEnergyRecharge()
    {

    }

    public void OnRest()
    {

    }

    public void OnRitual()
    {

    }

    public void OnEnterRestRoom()
    {

    }

    public void OnRefreshHand()
    {

    }

    public void OnShuffle()
    {
    }

    public void OnSmith()
    {

    }
    public void OnAttack(DamageInfo _info, int _damageAmount, AbstractCreature _target)
    {

    }

    public int OnAttacked(DamageInfo _info, int _damageAmount)
    {
        return _damageAmount;
    }

    public int OnAttackedMonster(DamageInfo _info, int _damageAmount)
    {
        return _damageAmount;
    }

    public void OnExhaust(AbstractCard _card)
    {

    }

    public void OnTrigger()
    {

    }

    public void OnTrigger(AbstractCreature _target)
    {

    }

    public bool CheckTrigger()
    {
        return false;
    }

    public void OnEnterRoom(AbstractRoom _room)
    {

    }

    public void OnCardDraw(AbstractCard _card)
    {

    }

    public void OnDrawOrDiscard()
    {

    }

    public void OnMonsterDeckChange()
    {

    }


    public void OnUsePotion()
    {

    }
    public void OnUseCard(AbstractCard _targetCard, UseCardAction _useCardAction)
    {

    }
    public void OnLoseHp(int _damageAmount)
    {

    }


    public void OnChestOpen(bool _isBossChest)
    {

    }

    public bool IsCanPlay(AbstractCard _card)
    {
        return true;
    }

    public int CompareTo(AbstractRelic other)
    {
        throw new NotImplementedException();
    }
}

public enum RelicTier
{
    None = 0,
    Deprecated = 1,
    Starter = 2,
    Common = 3,
    Uncommon = 4,
    Rare = 5,
    Special = 6,
    Boss = 7,
    Shop = 8,
}

public enum LandingSound
{
    None = 0,
    Clink = 1,
    Heavy = 2,
    Magical = 3,
    Solid = 4,
}
