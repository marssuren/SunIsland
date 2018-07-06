using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionManager
{
	private List<AbstractGameAction> nextCombatActions=new List<AbstractGameAction>();
	public List<AbstractGameAction> Actions=new List<AbstractGameAction>();
	public List<AbstractGameAction> PreTurnActions=new List<AbstractGameAction>();
	public List<CardQueueItem> CardQueue=new List<CardQueueItem>();
	public List<MonsterQueueItem> MonsterQueue=new List<MonsterQueueItem>();
	public List<AbstractCard> CardsPlayedThisTurn=new List<AbstractCard>();
	public List<AbstractCard> CardsPlayedThisCombat=new List<AbstractCard>();
	public List<AbstractOrb> OrbsChanneledThisCombat=new List<AbstractOrb>();
	public List<AbstractOrb> OrbsChanneledThisTurn=new List<AbstractOrb>();
	public AbstractGameAction CurrentAction;
	public AbstractGameAction PreviousAction;
	public AbstractGameAction TurnStartCurrentAction;
	public AbstractCard LastCard = null;
	public Phase ManagerPhase;
	public bool IsHasControl;
	public bool IsTurnHasEnded;
	public bool IsUsingCard;
	public bool IsMonsterAttacksQueued;
	public static int TotalDiscardedThisTurn = 0;
	public static int DamageReceivedThisTurn = 0;
	public static int DamageReceivedThisCombat = 0;
	public static int HpLossThisCombat = 0;
	public static int PlayerHpLastTurn;
	public static int EnergyGainedThisCombat;
	public static int Turn = 0;

	public GameActionManager()
	{
		ManagerPhase = Phase.WaitingOnUser;
		IsHasControl = true;
		IsMonsterAttacksQueued = true;
	}
	public void AddToNextCombat(AbstractGameAction _action)
	{
		nextCombatActions.Add(_action);
	}
	public void UseNextCombatActions()
	{
		for (int i = 0; i < nextCombatActions.Count; i++)
		{
			
		}
	}
	public void AddToBottom(AbstractGameAction _action)
	{
		if (Abstract)
		{
			
		}
	}
}
public enum Phase
{
	None=0,
	WaitingOnUser=1,
	ExecutingActions=2,
}
