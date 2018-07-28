using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//交锋
public class Clash : AbstractCard
{
	public const string Id = "Clash";
	public static string Name;
	public static string Description;
	public static string[] ExtendedDescription;
	private const int cost = 0;
	private const int damageAmt = 14;

	public Clash() : base("Clash", Name, "", 0, Description, CardType.Attack, CardRarity.Common, CardTarget.Enemy)
	{
		BaseDamage = 14;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new DamageAction(_monster, new DamageInfo(_player, Damage, DamageTypeForTurn), AttackEffect.SlashHeavy));
	}

	public bool IsCanUse(AbstractPlayer _player, AbstractMonster _monster)
	{
		bool tIsCanUse = base.IsCanUse(_player, _monster);
		if (!tIsCanUse)
		{
			return false;
		}
		else
		{
			AbstractCard tCard;
			for (int i = 0; i < _player.Hand.Group.Count; i++)
			{
				tCard = _player.Hand.Group[i];
				if (tCard.Type != CardType.Attack)
				{
					tIsCanUse = false;
					CantUseMessage = ExtendedDescription[0];
				}
			}

			return tIsCanUse;
		}

	}

	public Clash(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Clash(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Clash();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeDamage(4);
		}
	}
}
