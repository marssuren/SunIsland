using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exhume : AbstractCard
{

	public const string Id = "Exhume";
	public static string Name;
	public static string Description;
	private const int cost = 1;

	public Exhume():base("Exhume",Name,"",1,Description,CardType.Skill,CardRarity.Rare,CardTarget.None)
	{
		IsExhaust = true;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new ExhumeAction(false));
	}
	public Exhume(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}
	

	public Exhume(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Exhume();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeBaseCost(0);
		}
	}
}
