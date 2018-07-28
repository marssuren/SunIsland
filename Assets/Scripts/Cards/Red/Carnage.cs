using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//残杀
public class Carnage : AbstractCard
{
	public const string Id = "Carnage";
	public static string Name;
	public static string Description;
	private const int cost = 2;
	private const int attackDmg = 20;

	public Carnage() : base("Carnage", Name, "", 2, Description, CardType.Attack, CardRarity.UnCommon, CardTarget.Enemy)
	{
		BaseDamage = 20;
		IsEthereal = true;

	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new DamageAction(_monster, new DamageInfo(_player, Damage, DamageTypeForTurn), AttackEffect.BluntHeavy));
	}
	public Carnage(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Carnage(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Carnage();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeDamage(8);
		}
	}
}
