using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSlot : AbstractPotion
{
	public static string PotionId = "PotionSlot";
	//private readonly 
	public static string Name;
	public static string[] Descriptions;

	public PotionSlot(int _slot):base(Name,"PotionSlot",PotionRarity.PlaceHolder,PotionSize.T,PotionColor.None)
	{
		IsObtained = true;
		Description = Descriptions[0];
		Name = Descriptions[1];

	}
	public override void Use(AbstractCreature _creature)
	{
		throw new System.NotImplementedException();
	}

	public override int GetPotency(int _arg)
	{
		return 0;
	}

	public override AbstractPotion MakeCopy()
	{
		return null;
	}
}
