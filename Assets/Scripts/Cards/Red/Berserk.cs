using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//狂怒
public class Berserk : AbstractCard
{
	public const string Id = "Berserk";
	public static string Name;
	public static string Description;
	private const int cost = 1;
	private const int energyAmt = 1;

	public Berserk():base("Berserk",Name,"",1,Description,CardType.Power,CardRarity.Rare,CardTarget.Self)
	{
		
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player,_player,new BerserkPower(Name,_player,1),1));
	}
	public Berserk(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Berserk(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Berserk();
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
