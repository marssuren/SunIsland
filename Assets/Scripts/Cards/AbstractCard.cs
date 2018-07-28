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
	public bool IsHasEnoughEnergy()
	{
		if (AbstractDungeon.ActionManager.IsTurnHasEnded)
		{
			return false;
		}
		if (AbstractDungeon.Player.IsHasPower("Entangled") && Type == CardType.Attack)
		{
			return false;
		}

		if (IsFreeToPlayOnce)
		{
			return true;
		}

		for (int i = 0; i < AbstractDungeon.Player.Relics.Count; i++)
		{
			AbstractRelic tRelic;
			if (i == AbstractDungeon.Player.Relics.Count - 1)
			{
				for (int j = 0; j < AbstractDungeon.Blights.Count; j++)
				{
					AbstractBlight tBlight = AbstractDungeon.Blights[i];
					if (tBlight.IsCanPlay(this) && j == AbstractDungeon.Blights.Count - 1)
					{
						for (int k = 0; k < AbstractDungeon.Player.Hand.Group.Count; k++)
						{
							AbstractCard tCard = AbstractDungeon.Player.Hand.Group[k];
							if (tCard.IsCanPlay(this) && k == AbstractDungeon.Player.Hand.Group.Count - 1)
							{
								if (EnergyPanel.TotalCount >= CostForTurn)
								{
									return true;
								}

								return false;
							}

						}

					}

				}
			}
		}

		return false;
	}

	public void TookDamage()
	{

	}

	public void DidDiscard()
	{

	}

	protected void UseBlueCandle(AbstractPlayer _player)
	{
		//_player.GetRelic("BlueCandle").flash();
		//AbstractDungeon.ActionManager.AddToBottom();
		IsExhaust = true;
	}

	protected void UseMedicalKit(AbstractPlayer _player)
	{
		//_player.GetRelic("MedicalKit").flash();
		IsExhaust = true;
	}
	public bool IsCanPlay(AbstractCard _card)
	{
		return true;
	}

	public bool IsCanUse(AbstractPlayer _player, AbstractMonster _monster)
	{
		if (Type == CardType.Status)
		{
			if (AbstractDungeon.Player.HasRelic("MedicalKit"))
			{
				return true;
			}

			if (!CardID.Equals("Slimed"))
			{
				CantUseMessage = GetCanPlayMessage();
				return false;
			}

		}

		if (Type == CardType.Curse)
		{
			if (AbstractDungeon.Player.HasRelic("BlueCandle"))
			{
				return true;
			}

			if (!CardID.Equals("Pride"))
			{
				CantUseMessage = GetCanPlayMessage();
				return false;

			}
		}

		return IsCardPlayable(_monster) && IsHasEnoughEnergy();
	}

	public bool IsCardPlayable(AbstractMonster _monster)
	{
		if ((Target != CardTarget.Enemy && Target != CardTarget.SelfAndEnemy || _monster == null || !_monster.IsDying) && !AbstractDungeon.GetMonsters().AreMonstersBasicallyDead())
		{
			return true;
		}
		else
		{
			CantUseMessage = null;
			return false;

		}
	}

	protected void InitializeTitle()
	{

	}
	protected string GetCanPlayMessage()
	{
		return "";
	}
	public bool IsCanUpgrade()
	{
		if (Type == CardType.Curse)
		{
			return false;
		}
		if (Type == CardType.Status)
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

	protected void UpgradeName()
	{
		TimesUpgraded++;
		IsUpgraded = true;
		Name += "+";
		InitializeTitle();
	}
	protected void UpgradeBaseCost(int _newBaseCost)
	{
		int tDifferece = Cost - CostForTurn;        //费用变化值=卡牌原有基础费用-当前回合费用
		int tBaseDiff = _newBaseCost - Cost;        //基础费用变化值=新的基础费用-卡牌原有基础费用
		Cost += tBaseDiff;                          //卡牌原有基础费用+基础费用变化值
		if (Cost < 0)
		{
			Cost = 0;
		}
		if (CostForTurn > 0)
		{
			CostForTurn = Cost - tDifferece;        //重新计算当前回合所需费用
		}
		IsUpgradeCost = true;
	}
	//private string desetupKeyword(string _keyword)
	//{

	//}
	public void InitializeDescription()
	{
		KeyWords.Clear();
		//if (IsUsed)
		//{

		//}
	}
	public AbstractCard MakeStatEquivalentCopy()
	{
		AbstractCard tAbstractCard = MakeCopy();
		for (int i = 0; i < TimesUpgraded; i++)
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

	public void TriggerOnCardPlayed(AbstractCard _cardPlayed)
	{

	}

	public void TriggerOnExhaust()
	{

	}

	public void ApplyPowers()
	{

	}

	private void applyPowersToBlock()
	{
		IsBlockModified = false;
		float tValue = BaseBlock;
		for (int i = 0; i < AbstractDungeon.Player.powers.Count; i++)
		{
			AbstractPower tPower = AbstractDungeon.Player.powers[i];
			tValue = tPower.ModifyBlock(tValue);
			if (BaseBlock != Math.Floor(tValue))
			{
				IsBlockModified = true;
			}
		}

		if (tValue < 0f)
		{
			tValue = 0;
		}

		Block = (int)Math.Floor(tValue);
	}

	public void CalculateCardDamage(AbstractMonster _monster)
	{
		applyPowersToBlock();
		AbstractPlayer tPlayer = AbstractDungeon.Player;
		IsDamageModified = false;
		if (!IsMultiDamage && null != _monster)
		{
			float tValue = BaseDamage;
			if (this is PerfectStrike)
			{
				if (IsUpgraded)
				{
					tValue += 3 * PerfectStrike.CountCards();
				}
				else
				{
					tValue += 2 * PerfectStrike.CountCards();
				}

				if (BaseDamage != (int)tValue)
				{
					IsDamageModified = true;
				}
			}

			AbstractPower tPower;
			for (int i = 0; i < tPlayer.powers.Count; i++)
			{
				tPower = tPlayer.powers[i];
				if (this is HeavyBlade && tPlayer is StrengthPower)     //(升级后的)重刃计算(5)3倍伤害      
				{
					if (IsUpgraded)
					{
						tValue = tPower.AtDamageGive(tValue, DamageTypeForTurn);
						tValue = tPower.AtDamageGive(tValue, DamageTypeForTurn);
					}
					tValue = tPower.AtDamageGive(tValue, DamageTypeForTurn);
					tValue = tPower.AtDamageGive(tValue, DamageTypeForTurn);
				}
				tValue = tPower.AtDamageGive(tValue, DamageTypeForTurn);
				if (BaseDamage != (int)tValue)
				{
					IsDamageModified = true;
				}
			}
			if (tValue < 0f)
			{
				tValue = 0f;
			}
			Damage = (int)Math.Floor(tValue);
		}
		else
		{
			List<AbstractMonster> tMonster = AbstractDungeon.GetCurrRoom().Monsters.Monsters;
			float[] tValue = new float[tMonster.Count];
			for (int i = 0; i < tValue.Length; i++)
			{
				tValue[i] = BaseDamage;
			}

			AbstractPower tPower;
			for (int i = 0; i < tValue.Length; i++)
			{
				for (int j = 0; j < tPlayer.powers.Count; j++)
				{
					tPower = tPlayer.powers[i];
					tValue[i] = tPower.AtDamageGive(tValue[i], DamageTypeForTurn);
					if (BaseDamage != tValue[i])
					{
						IsDamageModified = true;
					}
				}
			}

			for (int i = 0; i < tValue.Length; i++)
			{
				if (tValue[i] < 0)
				{
					tValue[i] = 0;
				}
			}
			MultiDamage = new int[tValue.Length];
			for (int i = 0; i < tValue.Length; i++)
			{
				MultiDamage[i] = (int)Math.Floor(tValue[i]);
			}

			Damage = MultiDamage[0];
		}

	}

	public void UpdateCost(int _amt)
	{
		if (Color == CardColor.Colorless || Color == CardColor.Curse && !CardID.Equals("Pride") || Type == CardType.Status && !CardID.Equals("Slimed"))
		{

		}
		else
		{
			int tCost = Cost;
			int tGap = Cost - CostForTurn;
			if (_amt != 0)
			{
				tCost += _amt;
				if (tCost < 0)
				{
					tCost = 0;
				}
				if (tCost != Cost)
				{
					IsCostModified = true;
					Cost = tCost;
					CostForTurn = Cost - tGap;
					if (CostForTurn < 0)
					{
						CostForTurn = 0;
					}
				}
			}
		}
	}

	public void SetCostForTurn(int _amt)
	{
		if (CostForTurn>0)
		{
			CostForTurn = _amt;
			if (CostForTurn<0)
			{
				CostForTurn = 0;
			}

			if (CostForTurn!=Cost)
			{
				IsCostModifiedForTurn = true;
			}

		}
	}
	public void ModifyCostForTurn(int _amount)
	{
		if (CostForTurn > 0)
		{
			CostForTurn += _amount;
			if (CostForTurn < 0)
			{
				CostForTurn = 0;
			}

			if (CostForTurn != Cost)
			{
				IsCostModifiedForTurn = true;
			}
		}
	}

	public void ModifyCostForCombat(int _amount)
	{
		if (CostForTurn > 0)
		{
			CostForTurn += _amount;
			if (CostForTurn < 0)
			{
				CostForTurn = 0;
			}

			if (Cost != CostForTurn)
			{
				IsCostModified = true;
			}

			Cost = CostForTurn;
		}

		else
		{
			Cost += _amount;
			if (Cost < 0)
			{
				Cost = 0;
			}

			CostForTurn = 0;
			if (Cost != CostForTurn)
			{
				IsCostModified = true;
			}
		}
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
