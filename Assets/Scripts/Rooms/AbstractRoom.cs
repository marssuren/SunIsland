using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractRoom
{
	public static string[] Text;
	public List<AbstractPotion> Potions = new List<AbstractPotion>();

	public List<AbstractRelic> Relics = new List<AbstractRelic>();
	public List<RewardItem> rewards = new List<RewardItem>();

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
}
