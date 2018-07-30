using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExhumeAction : AbstractGameAction
{
	private bool isUpgrade;
	private AbstractPlayer player;
	private List<AbstractCard> exhums=new List<AbstractCard>();

	public ExhumeAction(bool _isUpgrade)
	{
		isUpgrade = _isUpgrade;
		player = AbstractDungeon.Player;
		SetValues(player,AbstractDungeon.Player,Amount);
		GameActionType = ActionType.CardManipulation;

	}

}
