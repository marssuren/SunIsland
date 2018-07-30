using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTap : AbstractCard
{
	public const string Id = "DoubleTap";
	public static string Name;
	public static string Description;
	public static string UpgradeDescription;
	private const int cost = 1;
	private const int draw = 1;

	public DoubleTap():base("DoubleTap",Name,"",1,Description,CardType.Skill,CardRarity.Rare,CardTarget.Self)
	{
		BaseMagicNumber = draw;
		MagicNumber = BaseMagicNumber;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player,_player,new DoubleTapPower(_player,MagicNumber),MagicNumber));

	}
	public DoubleTap(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public DoubleTap(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new DoubleTap();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeMagicNumber(1);
			RawDescription = UpgradeDescription;
			InitializeDescription();

		}
	}
}
