using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractOrb : MonoBehaviour
{
	public string Name;
	public string Description;
	public string Id;
	//protected List<>
	public int EvokeAmount = 0;
	public int PassiveAmount = 0;
	protected int BaseEvokeAmount = 0;
	protected int BasePassiveAmount = 0;

	protected bool isShowEvokeValue;

	public void UpdateDescription()
	{

	}

	public abstract void OnEvoke();

	public static AbstractOrb GetRandomOrb(bool _isUseCardRng)
	{
		List<AbstractOrb> tOrbs = new List<AbstractOrb>();
		tOrbs.Add(new Dark());
		tOrbs.Add(new Frost());
		tOrbs.Add(new Lightning());
		tOrbs.Add(new Plasma());
		return _isUseCardRng ? tOrbs[Random.Range(0, tOrbs.Count)] : tOrbs[Random.Range(0, tOrbs.Count)];
	}
	public void OnStartOfTurn()
	{

	}
	public void OnEndOfTurn()
	{

	}
	public void ApplyFocus()
	{
		AbstractPower tPower = AbstractDungeon.Player.GetPower("Focus");
		if(tPower != null && Id.Equals("Plasma"))
		{
			PassiveAmount = Mathf.Max(0, BasePassiveAmount + tPower.Amount);
			EvokeAmount = Mathf.Max(0, BaseEvokeAmount + tPower.Amount);
		}
	}

	public abstract AbstractOrb MakeCopy();
	public void SetSlot(int _slotNum, int _maxOrbs)
	{
		if(_maxOrbs == 1)
		{

		}
	}
	public void TriggerEvokeAnim()
	{

	}
	public void ShowEvokeValues()
	{
		isShowEvokeValue = true;
	}
	public void HideEvokeValues()
	{
		isShowEvokeValue = false;
	}
}
