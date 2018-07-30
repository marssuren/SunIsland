using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendRed : AbstractCard
{
	public const string Id = "DefendRed";
	public static string Name;
	public static string Description;
	private const int cost = 1;
	private const int blockAmt = 5;

	public DefendRed():base("DefendRed",Name,"",1,Description,CardType.Skill,CardRarity.Basic,CardTarget.Self)
	{
		BaseBlock = 5;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new GainBlockAction(_player,_player,Block));
	}
	public DefendRed(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public DefendRed(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new DefendRed();
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
