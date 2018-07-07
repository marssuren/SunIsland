using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyPanel : AbstractPanel
{
	public static string[] Msg;
	public static string[] Label;
	public static int TotalCount;
	private Texture gainEnergyImg;

	public EnergyPanel(Texture _img, bool _isStartHidden) : base(_img, _isStartHidden)
	{
		gainEnergyImg = null;
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
	public static void SetEnergy(int _energy)
	{
		TotalCount = _energy;
		AbstractDungeon.EffectsQueue.Add(new RefreshEnergyEffect());
	}
}
