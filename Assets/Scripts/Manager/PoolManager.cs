using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour    //对象池，用于管理重复利用的对象
{
	private List<CardController> cardPool;	//卡牌池


	public CardController Spwan(int _id)    //生成卡牌
	{
		CardController tCardController;
		if(cardPool.Count > 0)
		{
			tCardController = cardPool[0];
			cardPool.RemoveAt(0);
			tCardController.SetData(_id);
			return tCardController;
		}
		string tPath = Config.CardPath;      //根据id获得prefab的路径
		tCardController = Resources.Load<CardController>(tPath);
		tCardController.SetData(_id);
		return tCardController;
	}
	public void Recover(CardController _card)       //回收卡牌
	{
		_card.gameObject.SetActive(false);
		cardPool.Add(_card);                        //将这张卡牌加入对象池
	}
}
