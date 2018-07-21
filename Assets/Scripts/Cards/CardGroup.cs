using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGroup
{
	public List<AbstractCard> Group = new List<AbstractCard>();
	public CardGroupType Type;
	public Dictionary<int, int> HandPositionMap;
	public CardGroup(CardGroupType _type)
	{
		HandPositionMap = new Dictionary<int, int>();
		Type = _type;
	}
	public CardGroup(CardGroup _cardGroup, CardGroupType _type)
	{
		HandPositionMap = new Dictionary<int, int>();
		//IEnumerator tEnumerator = _cardGroup.Group.GetEnumerator();
		//while (tEnumerator.MoveNext())
		//{
		//	AbstractCard tAbstractCard =
		//}
		if(_cardGroup.Group.Count > 0)
		{
			for(int i = 0; i < _cardGroup.Group.Count; i++)
			{
				Group.Add(_cardGroup.Group[i]);
			}
		}

	}
	public bool IsContains(AbstractCard _card)
	{
		return Group.Contains(_card);
	}
	public int Size()
	{
		return Group.Count;
	}
	public CardGroup GetUpgradableCards()
	{
		CardGroup tCardGroup = new CardGroup(CardGroupType.Unspecified);
		for(int i = 0; i < Group.Count; i++)
		{
			AbstractCard tCard = Group[i];
			if(tCard.IsCanUpgrade())
			{
				tCardGroup.Group.Add(tCard);
			}
		}
		return tCardGroup;
	}
	public bool HasUpgradableCards()
	{
		AbstractCard tAbstractCard;
		for(int i = 0; i < Group.Count; i++)
		{
			if(Group[i].IsCanUpgrade())
			{
				return true;
			}
		}
		return false;
	}
	public CardGroup GetPurgeableCards()    //可净化
	{
		CardGroup tCardGroup = new CardGroup(CardGroupType.Unspecified);
		for(int i = 0; i < Group.Count; i++)
		{
			AbstractCard tAbstractCard = Group[i];
			if(!tAbstractCard.CardID.Equals("Necronomicurse") && !tAbstractCard.CardID.Equals("AscendersBane"))
			{
				tCardGroup.Group.Add(tAbstractCard);
			}
		}
		return tCardGroup;
	}
	public AbstractCard GetSpecificCard(AbstractCard _targetCard)
	{
		return Group.Contains(_targetCard) ? _targetCard : null;
	}
	public void TriggerOnOtherCardPlayed(AbstractCard _usedCard)
	{
		for(int i = 0; i < Group.Count; i++)
		{
			AbstractCard tCard = Group[i];
			if(tCard != _usedCard)
			{
				tCard.TriggerOnCardPlayed(_usedCard);
			}
		}
		for(int i = 0; i < AbstractDungeon.Player.powers.Count; i++)
		{
			AbstractPower tAbstractPower = AbstractDungeon.Player.powers[i];
			tAbstractPower.OnAfterCardPlayed(_usedCard);
		}
	}
	private void sortWithComparator(IComparer<AbstractCard> _comparable, bool _isAscending = false)
	{
		if(_isAscending)
		{
			Group.Sort(_comparable);
		}
		else
		{

			//todo:reverse Group.Sort(_comparable);
		}
	}
	public void SortByRarity(bool _isAscending)
	{
		sortWithComparator(new CardRarityComparator(),_isAscending);
	}
	public void SortByRarityPlusStatusCardType(bool _isAscending)
	{
		sortWithComparator(new CardTypeComparator(),_isAscending);
        sortWithComparator(new StatusCardLastComparator(),true);
	}

}
//public class CardLockednessComparator:IComparer<AbstractCard>
//{
//	public int Compare(AbstractCard _card0, AbstractCard _card1)
//	{
//		int _card0Rank = 0;
//		//if (Unlock)
//		//{
			
//		//}
//	}
//}
public class CardTypeComparator:IComparer<AbstractCard>
{
	public int Compare(AbstractCard _card0, AbstractCard _card1)
	{
		return _card0.Type.CompareTo(_card1.Type);
	}
}
public class StatusCardLastComparator : IComparer<AbstractCard>
{
	public int Compare(AbstractCard _card0, AbstractCard _card1)
	{
		if (_card0.Type==CardType.Status&&_card1.Type!=CardType.Status)
		{
			return 1;
		}
		return (_card0.Type != CardType.Status && _card1.Type == CardType.Status) ? -1 : 0;
	}
}
public class CardRarityComparator : IComparer<AbstractCard>
{
	public int Compare(AbstractCard _card0, AbstractCard _card1)
	{
		return _card0.Rarity.CompareTo(_card1.Rarity);
	}
}
public enum CardGroupType
{
	None = 0,
	DrawPile = 1,       //抽牌堆
	MasterDeck = 2,
	Hand = 3,           //手牌堆
	DiscardPile = 4,    //已经打出的牌堆
	ExhaustPile = 5,    //消耗牌堆
	CardPool = 6,
	Unspecified = 7,

}
