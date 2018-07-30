using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendFire : AbstractCard
{
	public const string Id = "FriendFire";
	public static string Name;
	public static string Description;
	private const int baseDamage = 7;
	private const int cost = 2;

	public FriendFire():base("FriendFire",Name,"",2,Description,CardType.Attack,CardRarity.Rare,CardTarget.Enemy)
	{
		BaseDamage = 7;
		IsExhaust = true;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new FiendFireAction(_monster,
			new DamageInfo(_player, Damage, DamageTypeForTurn)));
	}
	public FriendFire(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public FriendFire(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new FriendFire();
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
