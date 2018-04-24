using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyLogic : ActorBase
{
	[SerializeField]
	private int hp;     //生命值

	private Animator animator;
	void Start()
	{
		hp = 30;
		animator = GetComponent<Animator>();
	}
	private void action()            //准备阶段
	{

	}
	public void GetInjured(int _damage)       //受伤
	{
		hp -= _damage;
		if(hp > 0)
		{
			animator.SetTrigger("Injured");     //播放受伤动画
		}
		else
		{
			animator.SetTrigger("Die");         //播放死亡动画
		}
	}



}
