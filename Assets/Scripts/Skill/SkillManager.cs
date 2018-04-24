using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
	private Dictionary<int, Action<ActorBase>> skillDic;

	public Dictionary<int, Action<ActorBase>> SkillDic
	{
		get
		{
			if(null == skillDic)
			{
				skillDic = new Dictionary<int, Action<ActorBase>>();
				skillDic.Add(1,skill1);
			}
			return skillDic;
		}
	}
	public Action<ActorBase> GetSkillById(int _id)
	{
		return SkillDic[_id];
	}
	private void skill1(ActorBase _actorBase)
	{

	}

}
