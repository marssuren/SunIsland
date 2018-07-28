using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//战斗专注
public class BattleTrance : AbstractCard			
{
	public const string Id = "BattleTrance";
	public static string Name;
	public static string Description;
	private const int cost = 0;
	private const int draw = 3;

	public BattleTrance() : base("BattleTrance", Name, "", 0, Description, CardType.Skill, CardRarity.UnCommon, CardTarget.None)
	{
		BaseMagicNumber = 3;
		MagicNumber = BaseMagicNumber;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _montser)
	{
		AbstractDungeon.ActionManager.AddToBottom(new DrawCardAction(_player,MagicNumber));
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player,_player,new NoDrawPower(_player)));
	}

	public BattleTrance(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public BattleTrance(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new BattleTrance();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeMagicNumber(1);
		}
	}
}
