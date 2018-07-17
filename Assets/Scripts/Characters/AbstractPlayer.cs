using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractPlayer : AbstractCreature
{
	public static string[] Message;
	public static string[] Label;
	public PlayerClass ChosenClass;
	public int GameHandSize;
	public int MasterHandSize;
	public CardGroup MasterDeck;
	public CardGroup DrawPile;
	public CardGroup Hand;
	public CardGroup DiscardPile;
	public CardGroup ExhaustPile;
	public CardGroup Limbo;
	public List<AbstractRelic> Relics;
	public int PotionSlots;
	public List<AbstractPotion> Potions;
	public EnergyManager Energy;
	public bool IsEndingTurn;
	public bool IsViewingRelics;
	public bool IsInspectMode;
	public int DamagedThisCombat;
	public int CardsPlayedThisTurn;
	public string Title;

	public List<AbstractOrb> Orbs;
	public int MasterMaxOrbs;
	public int MaxOrbs;
	public AbstractCard HoveredCard;
	public AbstractCard ToHover;
	public AbstractCard CardInUse;
	public bool IsDraggingCard;
	private bool IsUsingClickDragControl;
	private float clickDragTimer;
	public bool IsSingleTargetMode;
	private AbstractMonster hoveredMonster;
	private Vector2[] points;
	private Vector2 controlPoint;
	public override void Damage(DamageInfo _damageInfo)
	{
		throw new System.NotImplementedException();

	}
	

	public bool HasRelic(string _targetId)
	{
		for(int i = 0; i < Relics.Count; i++)
		{
			if(Relics[i].relicId == _targetId)
			{
				return true;
			}
		}
		return false;
	}

	public bool HasPotion(string _id)
	{
		for(int i = 0; i < Potions.Count; i++)
		{
			if(Potions[i].Id == _id)
			{
				return true;
			}
		}

		return false;
	}

	public void LoseRandomRelics(int _amount)
	{
		if(_amount > Relics.Count)
		{
			for(int i = 0; i < Relics.Count; i++)
			{
				Relics[i].OnUnEquip();
			}
			Relics.Clear();
		}
		else
		{
			for(int i = 0; i < _amount; i++)
			{
				int tIndex = Random.Range(0, Relics.Count);
				Relics[tIndex].OnUnEquip();
				Relics.RemoveAt(tIndex);
			}

		}
	}

	public void ReorganizeRelics()
	{
		List<AbstractRelic> tRelicsLst = new List<AbstractRelic>();
		tRelicsLst.AddRange(Relics);
		Relics.Clear();
		for(int i = 0; i < tRelicsLst.Count; i++)
		{
			tRelicsLst[i].ReOrgnaizeObtain(this, i, false, tRelicsLst.Count);
		}
	}

	public AbstractRelic GetRelic(string _targetId)
	{
		AbstractRelic tAbstractRelic = null;
		for(int i = 0; i < Relics.Count; i++)
		{
			if(Relics[i].relicId == _targetId)
			{
				tAbstractRelic = Relics[i];
			}
		}
		return tAbstractRelic;
	}

	public void ObtainPotion(int _slot, AbstractPotion _potion)
	{
		if(_slot < PotionSlots)
		{
			Potions.Insert(_slot, _potion);
			_potion.SetAsObtained(_slot);
		}
	}
	public bool IsObtainPotion(AbstractPotion _potion2Obtain)
	{
		int tIndex = 0;
		for(int i = 0; i < Potions.Count; i++)
		{
			if(Potions[i] is PotionSlot)
			{
				break;
			}
		}
		if(tIndex < PotionSlots)
		{
			Potions.Insert(tIndex, _potion2Obtain);
			_potion2Obtain.SetAsObtained(tIndex);
			//_potion2Obtain.
			return true;
		}
		//AbstractDungeon.top
		return false;
	}
	public static string GetClass(PlayerClass _class)
	{
		switch(_class)
		{
			case PlayerClass.IronClad:
			return "TheIronClad";
			case PlayerClass.TheSilent:
			return "TheSilent";
			case PlayerClass.Defect:
			return "TheDefect";
			default:
			return "Unknown";
		}
	}
	public void BottleCardUpgradeCheck(AbstractCard _card)
	{
		if(_card.IsInBottleFlame && AbstractDungeon.Player.HasRelic("BottledFlame"))
		{
			//AbstractDungeon.Player.GetRelic("BottledFlame").
		}

		if(_card.IsInBottleLightning && AbstractDungeon.Player.HasRelic("BottledLightning"))
		{
			//AbstractDungeon.Player.GetRelic("BottledLightning")
		}

		if(_card.IsInBottleTornado && AbstractDungeon.Player.HasRelic("BottledTornado"))
		{
			//AbstractDungeon.Player.GetRelic("BottledTornado")
		}
	}
	public void TriggerEvokeAnimation(int _slot)
	{
		if(MaxOrbs > 0)
		{

		}
	}
	public void PreBattlePrep()
	{
		AbstractDungeon.ActionManager.Clear();
		DamagedThisCombat = 0;
		CardsPlayedThisTurn = 0;
		MaxOrbs = 0;
		Orbs.Clear();


	}
	public void IncreaseMaxOrbSlots(int _amount, bool _isPlaySfx)
	{
		if(MaxOrbs == 10)
		{
			//AbstractDungeon.EffectList.Add(new th);
		}
		else
		{
			if(_isPlaySfx)
			{
				//CardCrawlGam
			}
			MaxOrbs += _amount;
			for(int i = 0; i < _amount; i++)
			{
				Orbs.Add(new EmptyOrbSlot());
			}
			for(int i = 0; i < Orbs.Count; i++)
			{
				Orbs[i].SetSlot(i, MaxOrbs);
			}
		}
	}
	public void DecreaseMaxOrbSlots(int _amount)
	{
		if(MaxOrbs > 0)
		{
			MaxOrbs -= _amount;
			if(MaxOrbs < 0)
			{
				MaxOrbs = 0;
			}
			if(Orbs.Count != 0)
			{
				Orbs.RemoveAt(Orbs.Count - 1);
			}

			for(int i = 0; i < Orbs.Count; i++)
			{
				Orbs[i].SetSlot(i, MaxOrbs);
			}
		}
	}
	public void ApplyStartOfTurnOrbs()
	{
		if(AbstractDungeon.Player.Orbs.Count != 0)
		{
			for(int i = 0; i < Orbs.Count; i++)
			{
				Orbs[i].OnStartOfTurn();
			}

			if(AbstractDungeon.Player.HasRelic("Cables") && !AbstractDungeon.Player.Orbs[0] is EmptyOrbSlot)
			{
				AbstractDungeon.Player.Orbs[0].OnStartOfTurn();
			}
		}
	}
}
public enum PlayerClass
{
	None = 0,
	IronClad = 1,
	TheSilent = 2,
	Defect = 3,
}
public enum RHoverType
{
	None = 0,
	Relic = 1,
	Blight = 2,
}
