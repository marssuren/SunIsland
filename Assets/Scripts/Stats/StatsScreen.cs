using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScreen
{

	public void IncrementEnemySlain()
	{
		switch(AbstractDungeon.Player.ChosenClass)
		{
			case PlayerClass.IronClad:
			break;
			case PlayerClass.TheSilent:
			break;
			case PlayerClass.Defect:
			break;
		}
	}
}
