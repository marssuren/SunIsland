using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flex : AbstractCard
{
	public const string Id = "Flex";
	public static string Name;
	public static string Description;
	private const int strAmount = 2;
	private const int cost = 0;

	public Flex():base("Flex",Name,"",0,Description,CardType.Skill,CardRarity.Common,CardTarget.Self)
	{
		BaseMagicNumber = 2;
		MagicNumber = BaseMagicNumber;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player,_player,new StrengthPower(_player,MagicNumber),MagicNumber));
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player,_player,new LoseStrengthPower(_player,MagicNumber),MagicNumber));
	}
	public Flex(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Flex(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Flex();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeMagicNumber(2);
		}
	}
}
