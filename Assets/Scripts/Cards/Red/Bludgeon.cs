using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//重击
public class Bludgeon : AbstractCard			
{
	public const string Id = "Bludgeon";
	public static string Name;
	public static string Description;
	private const int cost = 3;
	private const int attackDmg = 32;

	public Bludgeon():base("Bludgeon",Name,"",3,Description,CardType.Attack,CardRarity.Rare,CardTarget.Enemy)
	{
		BaseDamage = 32;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		if (null!=_monster)
		{
			//AbstractDungeon.ActionManager.AddToBottom(new VFXAction);
		}
		AbstractDungeon.ActionManager.AddToBottom(new WaitAction(0.8f));
		AbstractDungeon.ActionManager.AddToBottom(new DamageAction(_monster,new DamageInfo(_player,Damage,DamageTypeForTurn),AttackEffect.None));
	}
	public Bludgeon(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Bludgeon(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Bludgeon();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeDamage(10);
		}
	}
}
