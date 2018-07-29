using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModUnused
{
	public string Key;
	public CardModEffectType Type;
	private int amount;
	private bool isApplied = false;

	public CardModUnused(CardModEffectType _type, int _amount, string _key)
	{
		Type = _type;
		_amount = _amount;
		Key = _key;
	}
	public void Apply(AbstractCard _card)
	{
		if(!isApplied)
		{
			isApplied = true;
			switch(Type)
			{
				case CardModEffectType.Damage:
				_card.Damage += amount;
				break;
			}
		}
	}
}
public enum CardModEffectType
{
	None = 0,
	Damage = 1,
}
