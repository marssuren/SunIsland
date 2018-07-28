using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bash : AbstractCard
{
	public const string Id = "Bash";
	public static string Name;
	public static string Descripton;
	private const int cost = 2;
	private const int attackDmg = 8;
	private const int debugDmg = 100;
	private const int vulnerableAmt = 2;			//造成的易伤层数

	public Bash():base("Bash",Name,"",2,Descripton,CardType.Attack,CardRarity.Basic,CardTarget.Enemy)
	{
		BaseDamage = 8;
		BaseMagicNumber = 2;
		MagicNumber = BaseMagicNumber;
	}

	public void Use(AbstractPlayer _player,AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new DamageAction(_monster,new DamageInfo(_player,Damage,DamageTypeForTurn),AttackEffect.BluntHeavy));
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_monster,_player,new VulnerablePower(_monster,MagicNumber,false),MagicNumber));
	}
	public Bash(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Bash(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Bash();
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
