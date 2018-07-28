using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodForBlood : AbstractCard
{
	public const string Id = "BloodForBlood";
	public static string Name;
	public static string Description;
	private const int damageAmt = 18;

	public BloodForBlood() : base("BloodForBlood", Name, "", 4, Description, CardType.Attack, CardRarity.UnCommon, CardTarget.Enemy)
	{
		BaseDamage = 18;
	}

	public void TookDamage()
	{
		UpdateCost(-1);
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new DamageAction(_monster, new DamageInfo(_player, Damage, DamageTypeForTurn), AttackEffect.SlashHeavy));
	}

	public BloodForBlood(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public BloodForBlood(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		AbstractCard tCard = new BloodForBlood();
		if (null != AbstractDungeon.Player)
		{
			tCard.UpdateCost(-AbstractDungeon.Player.DamagedThisCombat);
		}
		return tCard;
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			if (Cost<4)
			{
				UpgradeBaseCost(Cost-1);
				if (Cost<0)
				{
					Cost = 0;
				}
			}
			else
			{
				UpgradeBaseCost(3);
			}
			UpgradeDamage(4);
		}
	}
}
