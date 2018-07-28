using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//壁垒
public class Barricade : AbstractCard
{
	public const string Id = "Barricade";
	public static string Name;
	public static string Description;
	private const int cost = 3;

	public Barricade() : base("Barricade", Name, "", 3, Description, CardType.Power, CardRarity.Rare, CardTarget.Self)
	{

	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		bool tIsPowerExist = false;
		AbstractPower tPower;
		for (int i = 0; i < _player.powers.Count; i++)
		{
			tPower = _player.powers[i];
			if (tPower.ID.Equals("Barricade"))
			{
				tIsPowerExist = true;
				break;
			}
		}

		if (!tIsPowerExist)
		{
			AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player, _player, new BarricadePower(_player)));
		}
	}
	public Barricade(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Barricade(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Barricade();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeBaseCost(2);
		}
	}
}
