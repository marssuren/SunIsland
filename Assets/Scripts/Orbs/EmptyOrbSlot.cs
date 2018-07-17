using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyOrbSlot : AbstractOrb
{
	public static string OrbId = "Empty";
	public static string[] Desc;
	private static Texture img1;
	private static Texture img2;

	public EmptyOrbSlot(float _x, float _y)
	{

	}

	public EmptyOrbSlot()
	{
		//Name=
		EvokeAmount = 0;

	}


	public override void OnEvoke()
	{
		
	}

	public override AbstractOrb MakeCopy()
	{
		return new EmptyOrbSlot();
	}
}
