using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGroup
{
	public List<AbstractCard> Group=new List<AbstractCard>();
	public CardGroupType Type;
	public Dictionary<int, int> HandPositionMap;
	public CardGroup(CardGroupType _type)
	{
		HandPositionMap=new Dictionary<int, int>();
		Type = _type;
	}
	public CardGroup(CardGroup _cardGroup, CardGroupType _type)
	{
		HandPositionMap=new Dictionary<int, int>();
		//IEnumerator tEnumerator = _cardGroup.Group.GetEnumerator();
		//while (tEnumerator.MoveNext())
		//{
		//	AbstractCard tAbstractCard =
		//}
		if (_cardGroup.Group.Count>0)
		{
			for (int i = 0; i < _cardGroup.Group.Count; i++)
			{
				Group.Add(_cardGroup.Group[i]);
			}
		}
		
	}
	public bool IsContains(AbstractCard _card)
	{
		return Group.Contains(_card);
	}

}
public enum CardGroupType
{
	None=0,
	DrawPile=1,		//抽牌堆
	MasterDeck=2,	
	Hand=3,			//手牌堆
	DiscardPile=4,	//已经打出的牌堆
	ExhaustPile=5,	//消耗牌堆
	CardPool=6,
	Unspecified=7,

}
