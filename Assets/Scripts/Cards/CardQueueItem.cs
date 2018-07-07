using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardQueueItem
{
	public AbstractCard Card;
	public AbstractMonster Monster;
	public int EnergyOnUse;
	public bool IsEndTurnAutoPlay;

	public CardQueueItem()
	{
		EnergyOnUse = 0;
		Card = null;
		Monster = null;
	}

	public CardQueueItem(AbstractCard _card, AbstractMonster _monster) : this(_card, _monster,)
	{

	}

	public CardQueueItem(AbstractCard _card, AbstractMonster _monster, int _setEnergyOnUse)
	{
		EnergyOnUse = 0;
		Card = _card;
		Monster = _monster;
		EnergyOnUse = _setEnergyOnUse;
	}

	public CardQueueItem(AbstractCard _card,bool _isEndTurnAutoPlay)
	{
		
	}


}
