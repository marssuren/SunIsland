using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameActionManager
{
    private List<AbstractGameAction> nextCombatActions = new List<AbstractGameAction>();
    public List<AbstractGameAction> Actions = new List<AbstractGameAction>();
    public List<AbstractGameAction> PreTurnActions = new List<AbstractGameAction>();
    public List<CardQueueItem> CardQueue = new List<CardQueueItem>();
    public List<MonsterQueueItem> MonsterQueue = new List<MonsterQueueItem>();
    public List<AbstractCard> CardsPlayedThisTurn = new List<AbstractCard>();
    public List<AbstractCard> CardsPlayedThisCombat = new List<AbstractCard>();
    public List<AbstractOrb> OrbsChanneledThisCombat = new List<AbstractOrb>();
    public List<AbstractOrb> OrbsChanneledThisTurn = new List<AbstractOrb>();
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
    public void AddToTop(AbstractGameAction _action)
    {
        if (AbstractDungeon.GetCurrRoom().Phase == RoomPhase.Combat)
        {
            Actions.Insert(0, _action);
        }
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
        if (AbstractDungeon.GetCurrRoom().Phase == RoomPhase.Combat)
        {
            Actions.Add(_action);
        }
    }
    public void RemoveFromQueue(AbstractCard _card)
    {
        int tIndex = -1;
        for (int i = 0; i < CardQueue.Count; i++)
        {
            if (null != CardQueue[i] && CardQueue[i].Equals(_card))
            {
                tIndex = i;
                break;
            }
        }

        if (tIndex != -1)
        {
            CardQueue.RemoveAt(tIndex);
        }
    }
    public void ClearPostCombatActions()
    {

        for (int i = Actions.Count-1; i >=0 ; i++)
        {
            if (!(Actions[i] is HealAction)&&!(Actions[i] is UseCardAction )&&(Actions[i].GameActionType!=ActionType.Damage))
            {
                Actions.Remove(Actions[i]);
            }
        }
    }
    public void CleanCardQueue()
    {

        for (int i = CardQueue.Count - 1; i >= 0; i--)
        {
            CardQueueItem tItem = CardQueue[i];
            if (AbstractDungeon.Player.Hand.IsContains(tItem.Card))
            {
                CardQueue.Remove(tItem);
            }
        }

        AbstractCard tCard;
        for (int i = 0; i < AbstractDungeon.Player.Limbo.Group.Count; i++)
        {
            tCard = AbstractDungeon.Player.Limbo.Group[i];
            //tCard.FadingOut = true;

        }
    }

    public bool IsEmpty()
    {
        return Actions.Count == 0;
    }

    public void GetNextRoomCombatActions()
    {
        nextCombatActions.Clear();
    }

    public void Clear()
    {
        Actions.Clear();
        PreTurnActions.Clear();
        CurrentAction = null;
        PreviousAction = null;
        TurnStartCurrentAction = null;
        CardsPlayedThisCombat.Clear();
        CardsPlayedThisTurn.Clear();
        OrbsChanneledThisCombat.Clear();
        OrbsChanneledThisTurn.Clear();
        CardQueue.Clear();
        EnergyGainedThisCombat = 0;
        DamageReceivedThisCombat = 0;
        HpLossThisCombat = 0;
        IsTurnHasEnded = false;
        Turn = 1;
        ManagerPhase = Phase.WaitingOnUser;
        TotalDiscardedThisTurn = 0;

    }

    public void UpdateEnergyGain(int _energyGain)
    {
        EnergyGainedThisCombat += _energyGain;
    }

    

   
}
public enum Phase
{
    None = 0,
    WaitingOnUser = 1,
    ExecutingActions = 2,
}
