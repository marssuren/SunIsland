using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractRoom
{
    public static string[] Text;
	public List<AbstractPotion> Potions=new List<AbstractPotion>();

	public List<AbstractRelic> Relics=new List<AbstractRelic>();
	public List<RewardItem> rewards=new List<RewardItem>();

	protected string mapSymbol;

	public bool IsBattleOver;
	public bool IsCannotLose;
	public bool EliteTrigger;

	public bool IsMugged;
	public bool IsSmoked;

	public AbstractRoom()
	{

	}

	public abstract void OnPlayerEntry();
	public void AddRelicToRewards(RelicTier _tier)
	{
		
	}
	public void EndTurn()
	{
		AbstractDungeon.Player.ApplyEndOfTurnTriggers();
		AbstractDungeon.ActionManager.
	}
}
