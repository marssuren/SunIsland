using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private PlayerManager playerMgr;
	public PlayerManager PlayerMgr      //玩家管理类
	{
		get
		{
			return playerMgr;
		}
	}
	private LocaleMgr localeMgr;
	public LocaleMgr LocaleMgr         //本地化管理类
	{
		get
		{
			return localeMgr;
		}
	}
	private static PoolManager poolMgr;

	public static PoolManager PoolMgr //对象池管理者
	{
		get { return poolMgr; }
	}

	private CardController curChosenCard;       //当前选择的卡牌 

	private static GameManager gameMgr;
	public static GameManager GameMgr
	{
		get
		{
			return gameMgr;
		}
	}

	private static SkillManager skillManager;
	public static SkillManager SkillManager
	{
		get
		{
			return skillManager;
		}
	}


	void Awake()
	{
		gameMgr = this;
		playerMgr = gameObject.AddComponent<PlayerManager>();   //加载玩家管理类
		localeMgr = gameObject.AddComponent<LocaleMgr>();       //加载本地化管理类
		poolMgr = gameObject.AddComponent<PoolManager>();       //加载对象池管理类
		skillManager = gameObject.AddComponent<SkillManager>(); //加载卡牌技能管理类
	}
	void Update()
	{
		if(curChosenCard != null)       //如果当前有选择的卡牌
		{
			if(Input.GetMouseButtonDown(0))
			{
				Ray tRay = Camera.main.ScreenPointToRay(Input.mousePosition);
				RaycastHit tRaycastHit;
				if(Physics.Raycast(tRay, out tRaycastHit, 9999))
				{
					GameObject tGo = tRaycastHit.collider.gameObject;
					if(tGo.CompareTag("Enermy"))
					{
						curChosenCard.Use(tGo.GetComponent<EnermyLogic>());
					}
				}
			}
		}
	}
	public void ChangeChosenCard(CardController _card = null)      //更改当前选择的卡牌
	{
		curChosenCard = _card;
	}
	public void StartBattle()		//开始战斗
	{
		initCardRes();
	}
	private void initCardRes()		//加载玩家卡库
	{
		for(int i = 0; i < PlayerMgr.CardGroup.Count; i++)
		{
			PoolMgr.Spwan(PlayerMgr.CardGroup[i]);
		}
	}

}
