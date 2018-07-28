using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmamentsAction : AbstractGameAction
{
	private AbstractPlayer player;
	private List<AbstractCard> cannnotUpgrade=new List<AbstractCard>();
	private bool isUpgraded;

	public ArmamentsAction(bool _isArmamentsPlus)
	{
		GameActionType = ActionType.CardManipulation;
		player = AbstractDungeon.Player;
		isUpgraded = _isArmamentsPlus;
	}

	private void returnCards()
	{
		AbstractCard tCard;
		for (int i = 0; i < cannnotUpgrade.Count; i++)
		{
			tCard = cannnotUpgrade[i];
			player.Hand.AddToTop(tCard);
		}
		player.Hand.RefreshHandLayout();
	}
}
