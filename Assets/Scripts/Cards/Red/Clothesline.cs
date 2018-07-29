using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clothesline : AbstractCard
{
	public const string Id = "Clothesline";
	public static string Name;
	public static string Description;
	private const int cost = 2;
	private const int attackDmg = 12;
	private static int weak;

	public Clothesline():base("Clothesline",Name,"",2,Description,CardType.Attack,CardRarity.Common,CardTarget.Enemy)
	{
		BaseDamage = 12;
		BaseMagicNumber = weak;
		MagicNumber = BaseMagicNumber; 
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new DamageAction(_monster,new DamageInfo(_player,Damage,DamageTypeForTurn),AttackEffect.BluntHeavy));
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_monster,_player,new WeakPower(_monster,MagicNumber,false),MagicNumber));
	}
	public Clothesline(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Clothesline(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Clothesline();
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
