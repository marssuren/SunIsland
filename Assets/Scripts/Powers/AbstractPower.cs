using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractPower :MonoBehaviour, IComparable<AbstractPower>
{
	//public const float TipOffSet_X_M=10f;

	public AbstractCreature Owner;
	public string Name;
	public string Description;
	public string ID;
	public Texture Image;
	public int Amount;
	public int Priority = 5;
	public PowerType Type;
	protected bool IsTurnBased;
	public bool IsHovered;
	public bool IsPostActionPower;
	public bool IsSelected;
	public bool IsFinished;
	public bool IsCanGoNegative;
	public static string[] Descriptions;

	public AbstractPower()
	{
		Type = PowerType.Buff;
		IsTurnBased = false;
		IsHovered = false;
		IsPostActionPower = false;
		IsSelected = false;
		IsFinished = false;
		IsCanGoNegative = false;
	}
	public int CompareTo(AbstractPower other)
	{
		return Priority - other.Priority;
	}
}
public enum PowerType
{
	None=0,
	Buff=1,
	Debuff=2,
}
