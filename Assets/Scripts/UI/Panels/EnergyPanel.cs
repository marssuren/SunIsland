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
    public static void AddEnergy(int _energy)
    {
        TotalCount += _energy;
        if (TotalCount >= 9)
        {
            //Achivement Unlock
        }

        if (TotalCount > 999)
        {
            TotalCount = 999;
        }
        AbstractDungeon.EffectList.Add(new RefreshEnergyEffect());
    }

    public static void UseEnergy(int _e)
    {
        TotalCount -= _e;
        if (TotalCount < 0)
        {
            TotalCount = 0;
        }
    }
    public static int GetCurrentEnergy()
	{
		return AbstractDungeon.Player == null ? 0 : TotalCount;
	}

    
}
