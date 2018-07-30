using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolve : AbstractCard
{
	public const string Id = "Evolve";
	public static string Name;
	public static string Desciption;
	public static string UpgradeDescription;
	private const int cost = 1;
	private  int draw = 1;

	public Evolve():base("Evolve",Name,"",1,Desciption,CardType.Power,CardRarity.UnCommon,CardTarget.Self)
	{
		BaseMagicNumber = draw;
		MagicNumber = BaseMagicNumber;

	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player,_player,new EvolvePower(_player,MagicNumber),MagicNumber));
	}
	public Evolve(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Evolve(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new Evolve();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeMagicNumber(1);
			RawDescription = UpgradeDescription;
			InitializeDescription();
		}
	}
}
