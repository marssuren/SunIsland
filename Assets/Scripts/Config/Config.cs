using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{
	public static string CardPath = "Prefabs/Card/Card";
}

public enum CardType
{
    None=0,
    Attack=1,
    Skill=2,
    Ability=3,
}
