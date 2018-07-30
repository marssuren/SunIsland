using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualWield : AbstractCard
{
	public const string Id = "DualWield";
	public static string Name;
	public static string Description;
	public static string UpdateDescription;
	private const int cost = 1;
	private const int dupe = 1;

	public DualWield():base("DualWield",Name,"",1,Description,CardType.Skill,CardRarity.UnCommon,CardTarget.None)
	{
		BaseMagicNumber = 1;
		MagicNumber = BaseMagicNumber;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new DualWieldAction(_player,MagicNumber));
	}
	public DualWield(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public DualWield(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new DualWield();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeMagicNumber(1);
			RawDescription = UpdateDescription;
			InitializeDescription();
		}
	}
}
