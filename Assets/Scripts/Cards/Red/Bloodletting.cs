using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//放血
public class Bloodletting : AbstractCard
{
	public const string Id = "Bloodletting";
	public static string Name;
	public static string Description;
	public static string UpgradeDescription;
	private const int cost = 0;
	private const int hpLoss = 3;
	private const int energyAmt = 1;

	public Bloodletting() : base("Bloodletting", Name, "", 0, Description, CardType.Skill, CardRarity.UnCommon, CardTarget.Self)
	{
		BaseMagicNumber = 1;
		MagicNumber = BaseMagicNumber;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new GainEnergyAction(MagicNumber));
		AbstractDungeon.ActionManager.AddToBottom(new LoseHPAction(_player, _player, 3));
	}
	public Bloodletting(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Bloodletting(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Bloodletting();

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
