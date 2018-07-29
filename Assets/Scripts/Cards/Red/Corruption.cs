using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corruption : AbstractCard
{
	public const string Id = "Corruption";
	public static string Name;
	public static string Description;
	private const int str = 3;
	private const int cost = 3;

	public Corruption():base("Corruption",Name,"",3,Description,CardType.Power,CardRarity.UnCommon,CardTarget.Self)
	{
		BaseMagicNumber = 3;
		MagicNumber = BaseMagicNumber;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		//AbstractDungeon.ActionManager.AddToBottom(new);
		bool tIsPowerExist = false;
		for (int i = 0; i < _player.powers.Count; i++)
		{
			AbstractPower tPower = _player.powers[i];
			if (tPower.ID.Equals("Corruption"))
			{
				tIsPowerExist = true;
				break;
			}
		}

		if (!tIsPowerExist)
		{
			AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player,_player,new CorruptionPower(_player)));
		}
	}
	public Corruption(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Corruption(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Corruption();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeBaseCost(2);
		}
	}
}
