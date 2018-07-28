using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brutality : AbstractCard
{
	public const string Id = "Brutality";
	public static string Name;
	public static string Description;
	public static string UpgradeDescription;
	private const int cost = 0;

	public Brutality():base("Brutality",Name,"",0,Description,CardType.Power,CardRarity.Rare,CardTarget.Self)
	{
		
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player,_player,new BrutalityPower(_player,1),1));
	}
	public Brutality(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Brutality(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Brutality();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			IsInnate = true;
			RawDescription = UpgradeDescription;
			InitializeDescription();
		}
	}
}
