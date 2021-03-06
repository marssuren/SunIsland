﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCardAction : AbstractGameAction
{
	private AbstractCard targetCard;
	public AbstractCreature TargetCreature;
	public bool IsExhaustCard;		//是否为消耗卡牌
	public bool IsReboundCard;
	private const float dur = 0.15f;
	public UseCardAction(AbstractCard _card, AbstractCreature _target)
	{
		TargetCreature = _target;
		IsReboundCard = false;
		targetCard = _card;
		if (_card.IsExhaustOnUseOnce||_card.IsExhaust)
		{
			IsExhaustCard = true;
		}
		SetValues(AbstractDungeon.Player,(AbstractCreature)null,1);
		Duration = 0.15f;
		for (int i = 0; i < AbstractDungeon.Player.powers.Count; i++)
		{
			AbstractDungeon.Player.powers[i].OnUseCard(_card,this);
		}

		for (int i = 0; i < AbstractDungeon.Player.Relics.Count; i++)
		{
		    if (!_card.IsNotTriggerOnUse)
		    {
                AbstractDungeon.Player.Relics[i].OnUseCard(_card,this);
            }
		}

	    for (int i = 0; i < AbstractDungeon.Player.Hand.Group.Count; i++)
	    {
	        if (!_card.IsNotTriggerOnUse)
	        {
	            AbstractDungeon.Player.Hand.Group[i].TriggerOnCardPlayed(_card);
            }
	    }

	    for (int i = 0; i < AbstractDungeon.Player.DiscardPile.Group.Count; i++)
	    {
			if(!_card.IsNotTriggerOnUse)
			{
				AbstractDungeon.Player.DiscardPile.Group[i].TriggerOnCardPlayed(_card);
			}
	    }

		for (int i = 0; i < AbstractDungeon.Player.DrawPile.Group.Count; i++)
		{
		    AbstractCard tCard = AbstractDungeon.Player.DrawPile.Group[i];
		    if (!_card.IsNotTriggerOnUse)
		    {
		        tCard.TriggerOnCardPlayed(_card);
		    }
		}

	    for (int i = 0; i < AbstractDungeon.GetCurrRoom().Monsters.Monsters.Count; i++)
	    {
	        AbstractMonster tMonster = AbstractDungeon.GetCurrRoom().Monsters.Monsters[i];
	        for (int j = 0; j < tMonster.powers.Count; j++)
	        {
	            if (!_card.IsNotTriggerOnUse)
	            {
	                tMonster.powers[i].OnUseCard(_card,this);
	            }
            }
	    }

	    if (IsExhaustCard)
	    {
	        GameActionType = ActionType.Exhaust;
	    }
	    else
	    {
	        GameActionType = ActionType.Use;
	    }
	}

    public UseCardAction(AbstractCard _targetCard) : this(_targetCard, (AbstractCreature) null)
    {

    }

    void Update()
    {

    }

}
