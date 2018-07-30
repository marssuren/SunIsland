using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkEmbrace : AbstractCard
{
	public const string Id = "DarkEmbrace";
	public static string Name;
	public static string Description;
	private const int cost = 2;

	public DarkEmbrace():base("DarkEmbrace",Name,"",2,Description,CardType.Power,CardRarity.Rare,CardTarget.Self)
	{
		
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player,_player,new DarkEmbracePower(_player,1),1));
	}
	public DarkEmbrace(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public DarkEmbrace(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new DarkEmbrace();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeBaseCost(1);
		}
	}
}
