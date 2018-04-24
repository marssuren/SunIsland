using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IDragHandler, IPointerEnterHandler
{
	private int cardId;     //卡牌Id
	public int CardId
	{
		get; set;
	}
	private int cost;       //费用
	public int Cost
	{
		get; set;
	}
	private string desc;      //卡牌描述
	private bool isChosen;      //是否被选中
	[SerializeField]
	private Text textDes;   //卡牌描述

	private Action<ActorBase> skill;	//卡牌拥有的效果

	private bool isNeedTarget;      //是否为指向性卡牌
	private bool isWaitingForUse;       //是否等待使用
	void Start()
	{
		gameObject.GetComponent<Button>().onClick.AddListener(onChosen);
	}
	void OnEnable()
	{
		initData();
		textDes.text = desc;
	}
	public void SetData(int _id)
	{
		CardId = _id;
	}
	private void initData()     //加载数据
	{
		desc = GameManager.GameMgr.LocaleMgr.GetDesById(CardId);
	}
	public void OnDrag(PointerEventData eventData)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{

	}
	private void highLight()            //高亮
	{

	}
	public void Use(ActorBase _actor = null)                  //使用
	{
		active(_actor);
		useUp();
	}
	private void useUp()        //使用完毕
	{
		GameManager.GameMgr.ChangeChosenCard();
		isWaitingForUse = false;
		GameManager.PoolMgr.Recover(this);
	}
	private void onChosen()     //点选触发事件
	{
		Debug.LogError(isWaitingForUse);
		if(!isWaitingForUse)
		{
			highLight();
			GameManager.GameMgr.ChangeChosenCard(this); //更改当前选中的卡牌
			isWaitingForUse = true;
		}
		else
		{
			GameManager.GameMgr.ChangeChosenCard();
			isWaitingForUse = false;
		}
	}
	private void active(ActorBase _actor = null)   //实际激活的事件
	{
		if (null==skill)
		{
			skill = GameManager.SkillManager.GetSkillById(CardId);
		}
		if(_actor is EnermyLogic)
		{
			((EnermyLogic)_actor).GetInjured(10);
		}
	}
	private void reset()
	{
		isWaitingForUse = false;
		isChosen = false;
	}

}
