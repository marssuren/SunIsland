using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AbstractPower : MonoBehaviour, IComparable<AbstractPower>
{
	//public const float TipOffSet_X_M=10f;
	private List<AbstractGameEffect> effectList = new List<AbstractGameEffect>();
	public AbstractCreature Owner;
	public string Name;
	public string Description;
	public string ID;
	public Texture Image;
	public int Amount;
	public int Priority = 5;
	public PowerType Type;
	protected bool IsTurnBased;
	public bool IsHovered;
	public bool IsPostActionPower;
	public bool IsSelected;
	public bool IsFinished;
	public bool IsCanGoNegative;
	public static string[] Descriptions;

	public AbstractPower()
	{
		Type = PowerType.Buff;
		IsTurnBased = false;
		IsHovered = false;
		IsPostActionPower = false;
		IsSelected = false;
		IsFinished = false;
		IsCanGoNegative = false;
	}
	public int CompareTo(AbstractPower other)
	{
		return Priority - other.Priority;
	}

    public void UpdateDescription()
    {

    }
    public void StackPower(int _stackAmount)            //叠加buff
    {
        if (Amount == -1)                                 //buff无法叠加
        {
            Debug.Log(Name + "does not stack");
        }
        else
        {
            Amount += _stackAmount;
        }
    }

    public void ReducePower(int _reduceAmount)
    {
        if (Amount - _reduceAmount <= 0)
        {
            Amount = 0;
        }
        else
        {
            Amount -= _reduceAmount;
        }
    }

    public string GetHoverMessage()
    {
        return Name + ".." + Description;
    }
    public float AtDamageGive(float _damage, DamageType _damageType)
	{
		return _damage;
	}
	public float AtDamageFinalGive(float _damage, DamageType _type)
	{
		return _damage;
	}
	public float AtDamageFinalReceive(float _damage, DamageType _type)
	{
		return _damage;
	}
	public float AtDamageReceive(float _damage, DamageType _damageType)
	{
		return _damage;
	}
	public void AtStartOfTurn()
	{

	}
	public void DuringTurn()
	{


	}
	public void AtStartOfTurnPostDraw()
	{

	}
	public void AtEndOfTurn(bool _isPlayer)
	{

	}
	public void AtEndOfRound()
	{

	}
	public void OnDamageAllEnemies(int[] _damages)
	{

	}

	public int OnHeal(int _healAmount)
	{
		return _healAmount;
	}
	public int OnAttacked(DamageInfo _info, int _damageAmount)
	{
		return _damageAmount;
	}
	public void OnAttack(DamageInfo _info, int _damageAmount, AbstractCreature _target)
	{

	}
	public void OnEvokeOrb()
	{

	}
	public void OnPlayCard(AbstractCard _card, AbstractMonster _monster)
	{

	}
	public void OnUseCard(AbstractCard _card, UseCardAction _action)
	{

	}
	public void OnAfterUseCard(AbstractCard _card, UseCardAction _action)
	{

	}
	public void OnSpecificTrigger()
	{

	}
	public void OnDeath()
	{

	}
	public void OnChannel()
	{

	}
	public void AtEnergyGain()
	{

	}
	public void OnExhaust(AbstractCard _card)
	{

	}
	public float ModifyBlock(float _blockAmount)
	{
		return _blockAmount;
	}
	public void OnGainedBlock(float _blockAmount)
	{

	}
	//public int OnPlayerGainedBlock(float _blockAmount)
	//{

	//}
	public int OnPlayerGainedBlock(int _blockAmount)
	{
		return _blockAmount;
	}
	public void OnGainCharge(int _chargeAmount)
	{

	}
	public void OnRemove()
	{

	}
	public void OnEnergyRecharge()
	{

	}
	public void OnDrawOrDiscard()
	{

	}
	public void OnAfterCardPlayed(AbstractCard _cardUsed)
	{

	}
	public void OnInitialApplication()
	{

	}
	//public void Flash()
	//{
	//	effectList.Add(new GainPowerEffect(this));
	//	AbstractDungeon.EffectList.Add(new);
	//}
	public int OnLoseHp(int _damageAmount)
	{
		return _damageAmount;
	}
	public void OnVictory()
	{

	}

    



}
public enum PowerType
{
	None = 0,
	Buff = 1,
	Debuff = 2,
}
