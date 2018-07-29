using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSave
{

	public int Upgrades;
	public int Misc;
	public string Id;

	public CardSave(string _cardId, int _timesUpgraded, int _misc)
	{
		Id = _cardId;
		Upgrades = _timesUpgraded;
		Misc = _misc;
	}
}
