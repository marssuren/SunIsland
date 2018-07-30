using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feed :AbstractCard
{
	public const string Id = "Feed";
	public static string Name;
	public static string Description;
	private const int cost = 1;
	private const int attackDmg = 10;
	private int maxHpAmt = 3;

	public Feed():base("Feed",Name,"",1,Description,CardType.Attack,CardRarity.Rare,CardTarget.Enemy)
	{
		BaseDamage = 10;
		IsExhaust = true;
		BaseMagicNumber = maxHpAmt;
		MagicNumber = BaseMagicNumber;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new FeedAction(_monster,new DamageInfo(_player,Damage,DamageTypeForTurn),MagicNumber));
	}

	public Feed(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Feed(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Feed();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeDamage(2);
			UpgradeMagicNumber(1);
		}
	}
}
