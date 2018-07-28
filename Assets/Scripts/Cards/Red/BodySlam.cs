using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//全身撞击
public class BodySlam : AbstractCard
{
	public const string Id = "BodySlam";
	public static string Name;
	public static string Description;
	public static string UpgradeDescription;
	private const int cost = 1;

	public BodySlam() : base("BodySlam", Name, "", 1, Description, CardType.Attack, CardRarity.Common, CardTarget.Enemy)
	{
		BaseDamage = 0;
	}
	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		BaseDamage = _player.CurrentBlock;
		CalculateCardDamage(_monster);
		AbstractDungeon.ActionManager.AddToBottom(new DamageAction(_monster, new DamageInfo(_player, Damage, DamageType.Normal), AttackEffect.BluntHeavy));
		RawDescription = Description;
		InitializeDescription();
	}

	public void ApplyPowers()
	{
		BaseDamage = AbstractDungeon.Player.CurrentBlock;
		base.ApplyPowers();
		RawDescription = Description;
		RawDescription += UpgradeDescription;
		InitializeDescription();
	}

	public void OnMoveToDiscard()
	{
		RawDescription = Description;
		InitializeDescription();
	}

	public void CalculateCardDamage(AbstractMonster _monster)
	{
		base.CalculateCardDamage(_monster);
		RawDescription = Description;
		RawDescription += UpgradeDescription;
		InitializeDescription();
	}

	public BodySlam(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public BodySlam(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new BodySlam();
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
