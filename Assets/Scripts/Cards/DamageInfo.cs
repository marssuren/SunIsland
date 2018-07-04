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

}
public enum DamageType
{
	None = 0,
	Normal = 1,
	Thorns = 2,
	HpLoss = 3,
}
