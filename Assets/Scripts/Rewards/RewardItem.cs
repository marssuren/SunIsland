using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardItem
{
	public readonly string[] Text;
	public readonly string[] Msg;
	public readonly string[] Label;
	public RewardType Type;
	public int GoldAmount = 0;
	public int BonusGold = 0;
	public string TextStr;
	public AbstractRelic Relic;
	public AbstractPotion Potion;
	public List<AbstractCard> Cards;
	private List<AbstractGameEffect> effects=new List<AbstractGameEffect>();
	private bool isBoss;
	public bool IsDone;

	public RewardItem(int _gold)
	{
		Type = RewardType.Gold;
		GoldAmount = _gold;

	}
	public RewardItem(int _gold, bool _theft)
	{
		Type = RewardType.StolenGold;
		GoldAmount = _gold;

	}
	private void applyGoldBonus(bool _isTheft)
	{
		int tGoldAmt = GoldAmount;
		BonusGold = 0;
		if(_isTheft)
		{
			TextStr = GoldAmount + Text[0];


		}
		else
		{
			if (!(AbstractDungeon.GetCurrRoom() is TreasureRoom))
			{
			    if (AbstractDungeon.Player.HasRelic("GoldenIdol"))
			    {
			        BonusGold +=(int) Mathf.Round(tGoldAmt * 0.25f);
			    }

			   
			}

		    if (BonusGold==0)
		    {
		        
		    }

		}
	}
}
public enum RewardType
{
	None=0,
	Card=1,
	Gold=2,
	Relic=3,
	Potion=4,
	StolenGold=5,
}
