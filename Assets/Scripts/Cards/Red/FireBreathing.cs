using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathing : AbstractCard
{
	public const string Id = "FireBreathing";
	public static string Name;
	public static string Description;
	private const int cost = 1;

	public FireBreathing():base("FireBreathing",Name,"",1,Description,CardType.Power,CardRarity.UnCommon,CardTarget.Self)
	{
		
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player,_player,new FireBreathingPower(_player,1),1));
	}

	public FireBreathing(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public FireBreathing(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new FireBreathing();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeBaseCost(0);
		}
	}
}
