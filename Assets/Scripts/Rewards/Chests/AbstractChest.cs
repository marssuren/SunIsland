using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class AbstractChest
{
	public readonly string[] Text;
	public bool IsOpen;
	public int CommonChance;
	public int UncommonChance;
	public int RareChance;
	public int GoldChance;
	public int GoldAmount;
	public RelicReward Relic;
	public bool IsGoldReward;
	public bool IsCursed;
	public void RandomizeReward()
	{
		int tRoll = AbstractDungeon.TreasureRng.Next(0, 99);
		if(tRoll < GoldChance)
		{
			IsGoldReward = true;
		}

		if(tRoll < CommonChance)
		{
			Relic = RelicReward.CommonRelic;
		}
		else if(tRoll < UncommonChance + CommonChance)
		{
			Relic = RelicReward.UncommonRelic;
		}
		else
		{
			Relic = RelicReward.RareRelic;
		}
	}
	public void Open(bool _isBossChest)
	{
		for (int i = 0; i < AbstractDungeon.Player.Relics.Count; i++)
		{
			AbstractDungeon.Player.Relics[i].OnChestOpen(_isBossChest);
		}

		if (IsGoldReward)
		{
			
		}

		if (IsCursed)
		{
			
		}

		switch (Relic)
		{
			case RelicReward.CommonRelic:
				AbstractDungeon.GetCurrRoom().AddRelicToRewards(RelicTier.Common);
                
				break;
		    case RelicReward.UncommonRelic:
		        AbstractDungeon.GetCurrRoom().AddRelicToRewards(RelicTier.Uncommon);
		        break;
		    case RelicReward.RareRelic:
		        AbstractDungeon.GetCurrRoom().AddRelicToRewards(RelicTier.Rare);
		        break;
		    
        }
	}

    public void Close()
    {

    }

}
public enum RelicReward
{
	None = 0,
	CommonRelic = 1,
	UncommonRelic = 2,
	RareRelic = 3,
}
