﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGameAction
{
	protected float Duration;
	protected float StartDuration;
	public ActionType GameActionType;
	public AttackEffect GameAttackEffect;
	public DamageType GameDamageType;
	public bool IsDone;
	public int Amount;
	public AbstractCreature Target;
	public AbstractCreature Source;

	public AbstractGameAction()
	{
		GameAttackEffect = AttackEffect.None;
		IsDone = false;
	}
	protected void SetValues(AbstractCreature _target, DamageInfo _info)
	{
		Target = _target;
		Source = _info.Owner;
		Amount = _info.Output;
		Duration = 0.5f;
	}
	protected void SetValues(AbstractCreature _target, AbstractCreature _source, int _amount)
	{
		Target = _target;
		Source = _source;
		Amount = _amount;
		Duration = 0.5f;
	}
	protected void SetValues(AbstractCreature _target, AbstractCreature _source)
	{
		Target = _target;
		Source = _source;
		Amount = 0;
		Duration = 0.5f;
	}
	protected bool IsDeadOrEscaped(AbstractCreature _target)
	{
		if (!_target.IsDying&&!_target.HalfDead)
		{
			if (!_target.IsPlayer)
			{
				AbstractMonster tAbstractMonster = (AbstractMonster) _target;
			}
		}
	}
}
public enum ActionType
{
	None = 0,
	Block = 1,
	CardManipulation = 2,
	Damage = 3,
	Debuff = 4,
	Discard = 5,
	Draw = 6,
	Exhaust = 7,
	Heal = 8,
	Energy = 9,
	Text = 10,
	Use = 11,
	ClearCardQueue = 12,
	Dialog = 13,
	Special = 14,
	Wait = 15,
	Shuffle = 16,
	ReducePower = 17,
}
public enum AttackEffect
{
	None = 0,
	BluntLigt = 1,
	BluntHeavy = 2,
	SlashDiagonal = 3,
	Smash = 4,
	SlashHeavy = 5,
	SlashHorizontal = 6,
	SlashVertical = 7,
	Fire = 8,
	Poison = 9,
	Shield = 10,
}