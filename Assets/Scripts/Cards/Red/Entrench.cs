using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrench : AbstractCard
{
	public const string Id = "Entrench";
	public static string Name;
	public static string Description;
	public static string UpgradeDescription;
	private const int cost = 2;

	public Entrench():base("Entrench",Name,"",2,Description,CardType.Skill,CardRarity.UnCommon,CardTarget.Self)
	{
		
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new DoubleYourBlockAction(_player));
	}

	public void TriggerOnEndOfPlayerTurn()
	{
		AbstractDungeon.ActionManager.AddToTop(new ExhaustAllEtherealAction());
	}
	public Entrench(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Entrench(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Entrench();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeBaseCost(1);
			RawDescription = UpgradeDescription;
			InitializeDescription();
		}
	}
}
