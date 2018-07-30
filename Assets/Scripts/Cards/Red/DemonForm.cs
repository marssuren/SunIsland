using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//恶魔形态
public class DemonForm :AbstractCard
{
	public const string Id = "DemonForm";
	public static string Name;
	public static string Description;
	private const int cost = 3;

	public DemonForm():base("DemonForm",Name,"",3,Description,CardType.Power,CardRarity.Rare,CardTarget.None)
	{
		BaseMagicNumber = 2;
		MagicNumber = BaseMagicNumber;

	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player,_player,new DemonFormPower(_player,MagicNumber),MagicNumber));
	}


	public DemonForm(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public DemonForm(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new DemonForm();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeMagicNumber(1);
		}
	}
}
