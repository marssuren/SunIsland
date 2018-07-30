using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropKick : AbstractCard
{
	public const string Id = "DropKick";
	public static string Name;
	public static string Description;
	private const int cost = 1;
	private const int damage = 5;

	public DropKick():base("DropKick",Name,"",1,Description,CardType.Attack,CardRarity.UnCommon,CardTarget.Enemy)
	{
		BaseDamage = 5;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new DropkickAction(_monster));
		AbstractDungeon.ActionManager.AddToBottom(new DamageAction(_monster,new DamageInfo(_player,Damage,DamageTypeForTurn),AttackEffect.BluntHeavy));
	}
	public DropKick(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public DropKick(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new DropKick();
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
