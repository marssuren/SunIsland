using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DualWieldAction : AbstractGameAction
{
	private const float durationPerCard = 0.25f;
	private AbstractPlayer player;
	private int dupeAmount = 1;
	List<AbstractCard> cannotDuplicate=new List<AbstractCard>();

	public DualWieldAction(AbstractCreature _source,int _amount)
	{
		SetValues(AbstractDungeon.Player,_source,_amount);
		GameActionType = ActionType.Draw;
		player = AbstractDungeon.Player;
		dupeAmount = _amount;
	}

	private void returnCards()
	{
		for (int i = 0; i < cannotDuplicate.Count; i++)
		{
			AbstractCard tCard = cannotDuplicate[i];
			player.Hand.AddToTop(tCard);
		}
		player.Hand.RefreshHandLayout();
	}

	private bool isDualWieldable(AbstractCard _card)
	{
		return _card.Type == CardType.Attack || _card.Type == CardType.Power;
	}
}
