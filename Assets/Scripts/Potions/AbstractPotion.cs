using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPotion : MonoBehaviour
{
	public readonly string[] Text;
	public string Id;
	public string Name;
	public string Description;
	public int Slot = -1;
	public bool IsObtained;
	protected bool IsCanUse;
	public bool Discarded;
	public bool IsThrown;
	public bool IsTargetRequired;

	public bool CanUse()
	{
		return AbstractDungeon.GetCurrRoom().Monsters!=null &&!AbstractDungeon.GetCurrRoom().Monsters.
	}
}
