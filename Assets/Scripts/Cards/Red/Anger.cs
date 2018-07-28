using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anger : AbstractCard
{
	public const string Id = "Anger";
	public static string Name;
	public static string Description;
	private const int cost = 0;
	private const int attackDmg = 5;

	public Anger() : base("Anger", Name, "", 0, Description, CardType.Attack, CardRarity.Common, CardTarget.Enemy)
	{
		BaseDamage = 5;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new DamageAction(_monster, new DamageInfo(_player, Damage, DamageTypeForTurn), AttackEffect.BluntHeavy));
		//AbstractDungeon.ActionManager.AddToBottom(new VFX);
		AbstractDungeon.ActionManager.AddToBottom(new MakeTempCardInDiscardAction(MakeStatEquivalentCopy(), 1));
	}
	public Anger(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Anger(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Anger();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeDamage(2);
		}
	}
}
