using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamBarrier : AbstractCard
{
	public const string Id = "FlameBarrier";
	public static string Name;
	public static string Description;
	private const int cost = 2;
	private const int defenseGained = 12;
	private const int flameDamage = 4;

	public FlamBarrier():base("FlameBarrier",Name,"",2,Description,CardType.Skill,CardRarity.UnCommon,CardTarget.Self)
	{
		BaseBlock = 12;
		BaseMagicNumber = 4;
		MagicNumber = BaseMagicNumber;
	}

	public void Use(AbstractPlayer _player, AbstractMonster _monster)
	{
		AbstractDungeon.ActionManager .AddToBottom(new GainBlockAction(_player,_player,Block));
		AbstractDungeon.ActionManager.AddToBottom(new ApplyPowerAction(_player,_player,new FlameBarrierPower(_player,MagicNumber),MagicNumber));

	}

	public FlamBarrier(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
	{
	}

	public FlamBarrier(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget)
	{
	}

	public override AbstractCard MakeCopy()
	{
		return new FlamBarrier();
	}

	public override void Upgrade()
	{
		if (!IsUpgraded)
		{
			UpgradeName();
			UpgradeBlock(4);
			UpgradeMagicNumber(2);

		}
	}
}
