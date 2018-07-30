using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTapPower : AbstractPower
{
	public const string PowerId = "DoubleTap";
	public static string Name;
	public static string[] Descriptions;

	public DoubleTapPower(AbstractCreature _owner,int _amount)
	{
		name = Name;
		ID = "DoubleTap";
		Owner = _owner;
		Amount = _amount;
		UpdateDescription();
	}

	public void UpdateDescription()
	{
		if (Amount==1)
		{
			Description = Descriptions[0];
		}
		else
		{
			Description = Descriptions[1] + Amount + Descriptions[2];
		}
	}

	public void OnUseCard(AbstractCard _card, UseCardAction _action)
	{
		if (!_card.IsPurgeOnUse&&_card.Type==CardType.Attack&&Amount>0)
		{
			//flash
			AbstractMonster tMonster=null;
			if (_action.Target!=null)
			{
				tMonster = _action.Target as AbstractMonster;
			}
			AbstractCard tCard = _card.MakeStatEquivalentCopy();
			AbstractDungeon.Player.Limbo.AddToBottom(tCard);
			tCard.IsFreeToPlayOnce = true;
			if (null!=tMonster)
			{
				tCard.CalculateCardDamage(tMonster);
			}

			tCard.IsPurgeOnUse = true;
			AbstractDungeon.ActionManager.CardQueue.Add(new CardQueueItem(tCard,tMonster,_card.EnergyOnUse));
			if (tCard.CardID.Equals("Rampage"))
			{
				AbstractDungeon.ActionManager.AddToBottom(new ModifyDamageAction(_card,tCard.MagicNumber));
			}

			Amount--;
			if (Amount == 0)
			{
				AbstractDungeon.ActionManager.AddToBottom(new RemoveSpecificPowerAction(Owner,Owner,"DoubleTap"));
			}
		}
	}

	public void AtEndOfTurn(bool _isPlayer)
	{
		if (_isPlayer)
		{
			AbstractDungeon.ActionManager.AddToBottom(new RemoveSpecificPowerAction(Owner,Owner,"DoubleTap"));
		}
	}



}
