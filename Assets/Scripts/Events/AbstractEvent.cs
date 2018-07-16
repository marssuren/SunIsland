using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEvent
{
    protected Texture Img = null;
    protected string Body;
    protected bool IsWaitForInput;
    public bool IsHasDialog;
    protected int SceneNum;
    public static EventType Type;
    public static string Name;
    public static string[] Descriptions;
    public static string[] Options;
    public bool IsCombatTime;
    public List<int> OptionsSelected;

    public AbstractEvent()
    {
        Body = null;
        SceneNum = 0;
        OptionsSelected=new List<int>();
        Type = EventType.Room;
    }

    public void OnEnterRoom()
    {

    }

    public void EnterCombat()
    {
        AbstractDungeon.GetCurrRoom().Phase = RoomPhase.Combat;
        AbstractDungeon.LastCombatMetricKey = Name;
        AbstractDungeon.GetCurrRoom().Monsters.Init();
        AbstractDungeon.Player.
    }

}

public enum EventType
{
    None=0,
    Text=1,
    Image=2,
    Room=3,
}