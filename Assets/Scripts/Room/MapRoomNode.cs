﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRoomNode
{

	private List<MapRoomNode> parents;
	public AbstractRoom Room;
	public bool IsTaken;
	public bool IsHighlighted;

    public MapRoomNode(int _x,int _y)
    {
        
    }
	//public bool IsConnectedTo(MapRoomNode _node)
	//{

	//}
	public AbstractRoom GetRoom()
	{
		return Room;
	}
}
