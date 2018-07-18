using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCard : IComparable<AbstractCard>
{
	public CardType Type;
	public CardRarity Rarity;
	public CardColor Color;
	public int Cost;
	public int CostForTurn;
	public int Price;
	public int ChargeCost;
	public bool IsCostModified;     //是否费用变化
	public bool IsCostModifiedForTurn;  //是否本局费用变化
	public bool IsRetain;
	public bool IsNotTriggerOnUse;      //是否无法打出
	public bool IsInnate;           //是否固有
	public bool IsLocked;
	public bool IsShowEvokeValue;
	public int ShowEvokeOrbCount;
	public List<string> KeyWords;
	private const int CommonCardPrice = 50;
	private const int UnCommonCardPrice = 75;
	private const int RareCardPrice = 150;
	public bool IsSelected;
	public bool IsExhaust;  //是否消耗
	public bool IsEthereal; //是否虚无
	protected bool IsUsed;  //是否被使用过
	public bool IsUpgraded; //是否升级过
	public int TimesUpgraded;   //升级次数
	public int Misc;
	public int EnergyOnUse;
	public bool IsSeen;
	public bool IsUpgradeCost;
	public bool IsUpgradeDamage;
	public bool IsUpgradeBlock;
	public bool IsUpgradeMagicNumber;
	public int[] MultiDamage;
	protected bool IsMultiDamage;
	public int BaseDamage;
	public int BaseBlock;
	public int BaseMagicNumber;
	public int BaseHeal;
	public int BaseDraw;
	public int BaseDiscard;
	public int Damage;
	public int Block;
	public int MagicNumber;
	public int Heal;
	public int Draw;
	public int Discard;
	public bool IsDamageModified;
	public bool IsBlockModified;
	public bool IsMagicNumberModified;
	protected DamageType CardDamageType;
	public DamageType DamageTypeForTurn;
	public CardTarget Target;
	public bool IsPurgeOnUse;
	public bool IsExhaustOnUseOnce;
	public bool IsExhaustOnFire;
	public bool IsFreeToPlayOnce;


	public static string[] Text;


	public string OriginalName;
	public string Name;
	public string RawDescription;
	public string CardId;

	public string CantUseMessage;
	public bool IsInBottleFlame;
	public bool IsInBottleLightning;
	public bool IsInBottleTornado;
	public AbstractCard(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType)
	{
		ChargeCost = -1;
		IsCostModified = false;
		IsCostModifiedForTurn = false;
		IsRetain = false;
		IsNotTriggerOnUse = false;
		IsInnate = false;
		IsLocked = false;
		IsShowEvokeValue = false;
		ShowEvokeOrbCount = 0;
		KeyWords = new List<string>();
		IsSelected = false;
		IsExhaust = false;
		IsEthereal = false;
		IsUsed = false;
		IsUpgraded = false;
		TimesUpgraded = 0;
		Misc = 0;
		IsSeen = true;
		IsUpgradeCost = false;
		IsUpgradeDamage = false;
		IsUpgradeBlock = false;
		IsUpgradeMagicNumber = false;
		IsMultiDamage = false;
		BaseDamage = -1;
		BaseBlock = -1;
		BaseMagicNumber = -1;
		BaseHeal = -1;
		BaseDraw = -1;
		BaseDiscard = -1;
		Damage = -1;
		Block = -1;
		MagicNumber = -1;
		Heal = -1;
		Draw = -1;
		Discard = -1;
		IsDamageModified = false;
		IsBlockModified = false;
		IsMagicNumberModified = false;
		Target = CardTarget.Enemy;
		IsPurgeOnUse = false;
		IsExhaustOnUseOnce = false;
		IsExhaustOnFire = false;
		IsFreeToPlayOnce = false;
		IsInBottleFlame = false;
		IsInBottleLightning = false;
		IsInBottleTornado = false;
		Name = _name;
		CardID = _cardId;
		Cost = _cost;
		CostForTurn = _cost;
		RawDescription = _rawDescription;
		Type = _cardType;
		Rarity = _cardRarity;
		Target = _cardTarget;
		CardDamageType = _damageType;
		DamageTypeForTurn = _damageType;
		CreateCardImage();
	}
	public AbstractCard(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription, CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : this(_cardId, _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, DamageType.Normal)
	{
	}





	public string CardID;

	public int CompareTo(AbstractCard other)
	{
		return CardID.CompareTo(other.CardID);
	}


	public abstract AbstractCard MakeCopy();
	public void CreateCardImage()
	{

	}
	public bool IsCanUpgrade()
	{
		if(Type == CardType.Curse)
		{
			return false;
		}
		if(Type == CardType.Status)
		{
			return false;
		}
		return !IsUpgraded;
	}
	public abstract void Upgrade();
	protected void UpgradeDamage(int _amount)
	{
		BaseDamage += _amount;
		IsUpgradeDamage = true;
	}
	protected void UpgradeBlock(int _amount)
	{
		BaseBlock += _amount;
		IsUpgradeBlock = true;
	}
	protected void UpgradeMagicNumber(int _amount)
	{
		BaseMagicNumber += _amount;
		MagicNumber = BaseMagicNumber;
		IsUpgradeMagicNumber = true;
	}
	protected void UpgradeBaseCost(int _newBaseCost)
	{
		int tDifferece = Cost - CostForTurn;		//费用变化值=卡牌原有基础费用-当前回合费用
		int tBaseDiff = _newBaseCost - Cost;		//基础费用变化值=新的基础费用-卡牌原有基础费用
		Cost += tBaseDiff;							//卡牌原有基础费用+基础费用变化值
		if(Cost < 0)								
		{
			Cost = 0;
		}
		if(CostForTurn > 0)							
		{
			CostForTurn = Cost - tDifferece;		//重新计算当前回合所需费用
		}
		IsUpgradeCost = true;
	}
	//private string desetupKeyword(string _keyword)
	//{
		
	//}
	public AbstractCard MakeStatEquivalentCopy()
	{
		AbstractCard tAbstractCard = MakeCopy();
		for(int i = 0; i < TimesUpgraded; i++)
		{
			tAbstractCard.Upgrade();
		}

		tAbstractCard.Name = Name;
		tAbstractCard.Target = Target;
		tAbstractCard.IsUpgraded = IsUpgraded;
		tAbstractCard.TimesUpgraded = TimesUpgraded;
		tAbstractCard.BaseDamage = BaseDamage;
		tAbstractCard.BaseBlock = BaseBlock;
		tAbstractCard.BaseMagicNumber = BaseMagicNumber;
		tAbstractCard.Cost = Cost;
		tAbstractCard.CostForTurn = CostForTurn;
		tAbstractCard.IsCostModified = IsCostModified;
		tAbstractCard.IsCostModifiedForTurn = IsCostModifiedForTurn;
		tAbstractCard.IsSeen = IsSeen;
		tAbstractCard.IsLocked = IsLocked;
		tAbstractCard.Misc = Misc;
		return tAbstractCard;
	}
	public bool IsHasEnoughEnergy()
	{

	}
    public void TriggerOnCardPlayed(AbstractCard _cardPlayed)
    {

    }

    public void ResetAttributes()
    {
        Block = BaseBlock;
        IsBlockModified = false;
        Damage = BaseDamage;
        IsDamageModified = false;
        MagicNumber = BaseMagicNumber;
        IsMagicNumberModified = false;
        DamageTypeForTurn = CardDamageType;
        CostForTurn = Cost;
        IsCostModified = false;

    }
}
public enum CardType
{
	None = 0,
	Attack = 1,
	Skill = 2,
	Power = 3,
	Status = 4,
	Curse = 5,
}
public enum CardRarity
{
	None = 0,
	Basic = 1,
	Special = 2,
	Common = 3,
	UnCommon = 4,
	Rare = 5,
	Curse = 6,
}
public enum CardColor
{
	Red = 0,
	Green = 1,
	Blue = 2,
	Colorless = 3,
	Curse = 4,
}
public enum CardTarget
{
	None = 0,
	Enemy = 1,
	AllEnemy = 2,
	Self = 3,
	SelfAndEnemy = 4,
	All = 5,

}
