using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//幽灵铠甲
public class GhostlyArmor : AbstractCard
{
	public const string Id = "GhostlyArmor";
	public static string Name;
	public static string Description;
	private const int cost = 1;
	private const int blockAmt = 10;

	public GhostlyArmor():base("GhostlyArmor",Name,"",1,Description,CardType.Skill,CardRarity.UnCommon,CardTarget.Self)
	{
		IsEthereal = true;
		BaseBlock = 10;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new GainBlockAction(_player,_player,Block));
	}

	public void TriggerOnEndOfPlayerTurn()
	{
		AbstractDungeon.ActionManager.AddToTop(new ExhaustAllEtherealAction());
	}
	public GhostlyArmor(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public GhostlyArmor(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new GhostlyArmor();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeBlock(3);

		}
	}
}
