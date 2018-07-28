using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleave : AbstractCard
{
	public const string Id = "Cleave";
	public static string Name;
	public static string Description;
	private const int cost = 1;
	private const int attackDmg = 8;

	public Cleave():base("Cleave",Name,"",1,Description,CardType.Attack,CardRarity.Common,CardTarget.AllEnemy)
	{
		BaseDamage = 8;
		IsMultiDamage = true;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		//AbstractDungeon.ActionManager.AddToBottom(new );
		AbstractDungeon.ActionManager.AddToBottom(new DamageAllEnemiesAction(_player,MultiDamage,DamageTypeForTurn,AttackEffect.None));
	}
	public Cleave(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Cleave(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Cleave();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeDamage(3);
		}
	}
}
