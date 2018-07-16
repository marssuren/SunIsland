using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractBlight
{
	public string Name;
	public string Description;
	public string BlightId;
	public Texture Img;
	public Texture OutlineImg;
	public Texture LargeImg;
	public bool IsUnique;
	public int Increment;
	public bool IsDone = false;
	public bool IsAnimating = false;
	public bool IsObtained = false;
	public int Cost;
	public int Counter = -1;
	public bool IsSeen = false;
	public bool IsDiscarded;
	protected bool IsPulse;

	public AbstractBlight(string _setId,string _name,string _desc,string _imgName,bool _isUnique)
	{
		BlightId = _setId;
		Name = _name;
		Description = _desc;
		IsUnique = _isUnique;
	}
	public void Effect()
	{

	}
	public void OnEquip()
	{

	}
	public void IncrementUp()
	{

	}
	public void SetIncrement(int _newInc)
	{
		Increment = _newInc;
	}

	public void OnPlayCard(AbstractCard _card, AbstractMonster _monster)
	{

	}
	public bool IsCanPlay(AbstractCard _card)
	{
		return true;
	}
	public void OnVictory()
	{

	}
	public void AtBattleStart()
	{

	}
	public void AtTurnStart()
	{

	}
	public void OnPlayerEndTurn()
	{

	}
	public void OnBossDefeat()
	{

	}
	//public float EffectFloat()
	//{
	//	return 
	//}
}
