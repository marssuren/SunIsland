using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInfo : MonoBehaviour
{
	public AbstractCreature Owner;
	public string Name;
	public DamageType Type;
	public int Base;
	public int Output;
	public bool IsModified;
	public DamageInfo(AbstractCreature _damageSource, int _base, DamageType _type)
	{
		IsModified = false;
		Owner = _damageSource;
		Base = _base;
		Type = _type;
		Output = _base;
	}
	public DamageInfo(AbstractCreature _owner, int _base):this(_owner, _base, DamageType.Normal)
	{

	}
	public void ApplyPower(AbstractCreature _owner, AbstractCreature _target)
	{
		Output = Base;
		IsModified = false;
		float tempValue = Output;
		AbstractPower tAbstractPower;
		IEnumerator tVar6;
		if (!Owner.IsPlayer)
		{
			
		}
	}

	public void ApplyEnemyPowersOnly(AbstractCreature _target)
	{
		Output = Base;
		IsModified = false;
		float tValue = Output;
		AbstractPower tPower;
		for (int i = 0; i < _target.powers.Count; i++)
		{
			tPower = _target.powers[i];
			tValue = tPower.AtDamageReceive(Output, Type);
			if (Base!=Output)
			{
				IsModified = true;
			}
		}

		for (int i = 0; i < _target.powers.Count; i++)
		{
			tPower = _target.powers[i];
			tValue = tPower.AtDamageFinalReceive(Output, Type);
			if (Base!=Output)
			{
				IsModified = true;
			}
		}

		if (tValue<0f)
		{
			tValue = 0f;
		}

		Output = (int)Mathf.Floor(tValue);
	}

	public static int[] CreateDamageMatrix(int _baseDamage)
	{
		return CreateDamageMatrix(_baseDamage, false);
	}

	public static int[] CreateDamageMatrix(int _baseDamage, bool _isPureDamage)
	{
		int[] tRetVal=new int[AbstractDungeon.GetMonsters().Monsters.Count];
		for (int i = 0; i < tRetVal.Length; i++)
		{
			DamageInfo tDamageInfo=new DamageInfo(AbstractDungeon.Player,_baseDamage);
			if (!_isPureDamage)
			{
				tDamageInfo.ApplyEnemyPowersOnly(AbstractDungeon.GetMonsters().Monsters[i]);
			}

			tRetVal[i] = tDamageInfo.Output;

		}

		return tRetVal;
	}
}
public enum DamageType
{
	None = 0,
	Normal = 1,
	Thorns = 2,
	HpLoss = 3,
}
