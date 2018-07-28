using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuringPact : AbstractCard
{
	public const string Id = "BurningPact";
	public static string Name;
	public static string Descrption;
	private const int cost = 1;
	private const int draw = 2;
	private const int baseExhaust = 1;

	public BuringPact():base("BuringPact",Name,"",1,Descrption,CardType.Skill,CardRarity.UnCommon,CardTarget.None)
	{
		BaseMagicNumber = 2;
		MagicNumber = BaseMagicNumber;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new ExhaustAction(_player,_player,1,false));
		AbstractDungeon.ActionManager.AddToBottom(new DrawCardAction(_player,MagicNumber));
	}

	public BuringPact(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public BuringPact(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new BuringPact();
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
