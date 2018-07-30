using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disarm : AbstractCard
{
	public const string Id = "Disarm";
	public static string Name;
	public static string Description;
	private const int cost = 1;
	private const int baseStr = 2;

	public Disarm():base("Disarm",Name,"",1,Description,CardType.Skill,CardRarity.UnCommon,CardTarget.Enemy)
	{
		BaseMagicNumber = baseStr;
		MagicNumber = BaseMagicNumber;
		IsExhaust = true;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_monster,_player,new StrengthPower(_monster,-MagicNumber),-MagicNumber));

	}
	public Disarm(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Disarm(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Disarm();
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
