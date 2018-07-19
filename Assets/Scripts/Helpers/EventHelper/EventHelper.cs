using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHelper : MonoBehaviour
{
    public static RoomResult Roll()
    {
        float Roll = AbstractDungeon.EventRng.Next();
        RoomResult[] tPossibleResults=new RoomResult[100];
        
    }
	
}

public enum RoomResult
{
    None=0,
    Event=1,
    Elite=2,
    Treasure=3,
    Shop=4,
    Monster=5,
}