using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//易伤
public class VulnerablePower : AbstractPower				
{
	public static string PowerId = "Vulnerable";
	public static string Name;
	public static string[] Description;
	private bool isJustApplied = false;
	private const float effectiveness = 1.5f;
	private const int effectiveString = 50;

	public VulnerablePower(AbstractCreature _owner, int _amount, bool _isSourceMonster)
	{
		name = Name;
		ID = "Vulnerable";
		Owner = _owner;
		Amount = _amount;
		UpdateDescription();
		if (AbstractDungeon.ActionManager.IsTurnHasEnded && _isSourceMonster)
		{
			isJustApplied = true;
		}
		Type = PowerType.Debuff;
		IsTurnBased = true;
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
				AbstractDungeon.ActionManager.AddToBottom(new RemoveSpecificPowerAction(Owner, Owner, "Vulnerable"));
			}
			else
			{
				AbstractDungeon.ActionManager.AddToBottom(new ReducePowerAction(Owner, Owner, "Vulnerable", 1));
			}
		}
	}

	public float AtDamageReceive(float _damage, DamageType _damageType)
	{
		if (_damageType==DamageType.Normal)
		{
			if (Owner.IsPlayer&&AbstractDungeon.Player.HasRelic("OddMushroom"))
			{
				return _damage * 1.25f;
			}
			return Owner != null && Owner.IsPlayer && AbstractDungeon.Player.HasRelic("PaperFog")
					? _damage * 1.75f
					: _damage * 1.5f;
		}
		return _damage;
	}

}
