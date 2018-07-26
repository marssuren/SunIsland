using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyBlade : AbstractCard
{
	public const string Id = "HeavyBlade";
	public static string Name;
	public static string Description;
	private const int cost = 2;
	private static int attactDamage = 14;

	public HeavyBlade() : base("HeavyBlade", Name, "", 2, Description, CardType.Attack, CardRarity.Common, CardTarget.Enemy)
	{
		BaseDamage = 14;
		BaseMagicNumber = 3;
		MagicNumber = BaseMagicNumber;
	}
	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		if(null != _monster)
		{
			//AbstractDungeon.ActionManager.AddToBottom(new VFXAction());
		}
		AbstractDungeon.ActionManager.AddToBottom(new DamageAction(_monster, new DamageInfo(_player, Damage, DamageTypeForTurn), AttackEffect.BluntHeavy));
	}
	public HeavyBlade(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public HeavyBlade(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new HeavyBlade();
	}

	public override void Upgrade()
	{
		throw new System.NotImplementedException();
	}
}
