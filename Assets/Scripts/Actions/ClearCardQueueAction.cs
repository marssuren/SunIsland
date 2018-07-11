using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCardQueueAction : AbstractGameAction
{
	void Update()
	{
		for (int i = 0; i < AbstractDungeon.ActionManager.CardQueue.Count; i++)
		{
			CardQueueItem tItem = AbstractDungeon.ActionManager.CardQueue[i];
			if (AbstractDungeon.Player.Limbo.IsContains(tItem.Card))
			{
				AbstractDungeon.EffectList.Add(new ExhaustCardEffect(tItem.Card));
			    AbstractDungeon.Player.Limbo.Group.Remove(tItem.Card);
			}
		}
        AbstractDungeon.ActionManager.CardQueue.Clear();
	    IsDone = true;
	}

}
