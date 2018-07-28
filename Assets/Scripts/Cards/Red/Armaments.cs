using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armaments : AbstractCard
{
	public const string Id = "Armaments";
	public static string Name;
	public static string Description;
	public static string UpgradeDescription;
	private const int cost = 1;
	private const int defenseGained = 5;

	public Armaments() : base("Armaments", Name, "", 1, Description, CardType.Skill, CardRarity.Common, CardTarget.Self)
	{
		BaseBlock = 5;
	}
	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager.AddToBottom(new GainBlockAction(_player, _player, Block));
		AbstractDungeon.ActionManager.AddToBottom(new ArmamentsAction(IsUpgraded));
	}

	public override AbstractCard MakeCopy()
	{
		return new Armaments();
	}

	public override void Upgrade()
	{
		throw new System.NotImplementedException();
	}

	public Armaments(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public Armaments(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}
}
