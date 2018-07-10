using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractRoom
{
    public static string[] Text;
    public List<AbstractPotion> Potions = new List<AbstractPotion>();
    public List<AbstractRelic> Relics = new List<AbstractRelic>();
    public List<RewardItem> rewards = new List<RewardItem>();
    public RoomPhase Phase;
    public AbstractEvent Event = null;
    public MonsterGroup Monsters;
    protected string mapSymbol;
    protected Texture mapImg;
    protected Texture mapImgOutline;
    public bool IsBattleOver;
    public bool IsCannotLose;
    public bool EliteTrigger;

    public bool IsMugged;
    public bool IsSmoked;

    public AbstractRoom()
    {

    }
    public Texture GetMapImg()
    {
        return mapImg;
    }
    public Texture GetMapImgOutline()
    {
        return mapImgOutline;
    }
    public void SetMapImg(Texture _img, Texture _imgOutline)
    {
        mapImg = _img;
        mapImgOutline = _imgOutline;
    }

    public abstract void OnPlayerEntry();
    public void AddRelicToRewards(RelicTier _tier)
    {

    }
    public void EndTurn()
    {
        AbstractDungeon.Player.ApplyEndOfTurnTriggers();
        AbstractDungeon.ActionManager.AddToBottom(new Clea);
    }

    public void ClearEvent()
    {
        
    }
    public void AddCardReward(RewardItem _rewardItem)
    {
        if (!(_rewardItem.Cards.Count == 0))
        {
            rewards.Add(_rewardItem);
        }
    }
}

public enum RoomType
{
    None = 0,
    Shop = 1,
    Monster = 2,
    Shrine = 3,
    Treasure = 4,
    Event = 5,
    Boss = 6,
}
public enum RoomPhase
{
    None = 0,
    Combat = 1,
    Event = 2,
    Complete = 3,
    InComplete = 4,
}
