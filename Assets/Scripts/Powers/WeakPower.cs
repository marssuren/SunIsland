using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakPower : AbstractPower
{
	public const string PowerId = "Weakened";
	public static string Name;
	public static string[] Descriptions;
	private bool isJustApplied;
	private const int effectivenessString = 25;

	public WeakPower(AbstractCreature _owner, int _amount, bool _isSourceMonster)
	{
		name = Name;
		ID = "Weakened";
		Owner = _owner;
		Amount = _amount;
		UpdateDescription();
		if (_isSourceMonster)
		{
			isJustApplied = true;
		}

		Type = PowerType.Debuff;
		IsTurnBased = true;
		Priority = 99;
	}

	public void AtEndOfRound()
	{
		if (isJustApplied)
		{
			isJustApplied = false;
		}
		else
		{
			if (Amount == 0)
			{
				AbstractDungeon.ActionManager.AddToBottom(new RemoveSpecificPowerAction(Owner, Owner, "Weakened"));
			}
			else
			{
				AbstractDungeon.ActionManager.AddToBottom(new ReducePowerAction(Owner, Owner, "Weakened", 1));
			}
		}
	}

	public float AtDamageGive(float _damage, DamageType _type)
	{
		if (_type == DamageType.Normal)
		{
			return !Owner.IsPlayer && AbstractDungeon.Player.HasRelic("PaperCrane") ? _damage * 0.5f : _damage * 0.75f;
		}
		return _damage;
	}

}
