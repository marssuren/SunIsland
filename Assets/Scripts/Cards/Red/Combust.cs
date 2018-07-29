using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combust : AbstractCard
{
	public const string Id = "Combust";
	public static string Name;
	public static string Description;
	private const int cost = 1;
	public const int HpLoss = 1;
	private const int dmg = 5;

	public Combust():base("Combust",Name,"",1,Description,CardType.Power,CardRarity.UnCommon,CardTarget.Self)
	{
		BaseMagicNumber = 5;
		MagicNumber = BaseMagicNumber;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player,_player,new CombustPower(_player,1,MagicNumber),MagicNumber));
	}
	public Combust(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Combust(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Combust();
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
