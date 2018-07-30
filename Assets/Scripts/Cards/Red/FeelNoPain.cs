using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeelNoPain : AbstractCard
{
	public const string Id = "FeelNoPain";
	public static string Name;
	public static string Description;
	public static string UpgradeDescription;
	private const int cost = 1;
	private const int block = 3;
	private const int upgBlock = 1;

	public FeelNoPain():base("FeelNoPain",Name,"",1,Description,CardType.Power,CardRarity.UnCommon,CardTarget.Self)
	{
		BaseMagicNumber = 3;
		MagicNumber = BaseMagicNumber;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player,_player,new FeelNoPainPower(_player,MagicNumber),MagicNumber));

	}
	public FeelNoPain(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public FeelNoPain(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new FeelNoPain();
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
