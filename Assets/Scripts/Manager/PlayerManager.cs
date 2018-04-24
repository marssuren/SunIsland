using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	private EffectMgr effectMgr;
	public EffectMgr GetEffectMgr
	{
		get
		{
			return effectMgr ?? new EffectMgr();
		}
	}

	private List<int> cardGroup;        //玩家的卡组
	public List<int> CardGroup
	{
		get
		{
			if(null == cardGroup)
			{
				cardGroup = new List<int>();
			}
			return cardGroup;
		}
	}
	void Awake()
	{
		CardGroup.Add(1);               //初始化玩家牌库
	}

	private List<int> droppedCards;     //玩家弃牌堆
	public List<int> DroppedCards
	{
		get
		{
			if(null == droppedCards)
			{
				droppedCards = new List<int>();
			}
			return droppedCards;
		}
	}

	private List<int> unDrawnCards;		//玩家抽牌堆
	public List<int> UnDrawnCards
	{
		get
		{
			if(null == unDrawnCards)
			{
				unDrawnCards = new List<int>();
			}
			return unDrawnCards;
		}
	}

	private List<CardController> handCards; //玩家手牌
	public List<CardController> HandCards
	{
		get
		{
			if(null == handCards)
			{
				handCards = new List<CardController>();
			}
			return handCards;
		}
	}

}
