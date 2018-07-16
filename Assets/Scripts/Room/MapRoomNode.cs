﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapRoomNode
{

    private List<MapRoomNode> parents;
    public AbstractRoom Room;
    public bool IsTaken;
    public bool IsHighlighted;
    private List<MapEdge> edges;

    public MapRoomNode(int _x, int _y)
    {
        edges = new List<MapEdge>();
    }

    public bool IsHasEdges()
    {
        return edges.Count != 0;
    }

    public void AddEdge(MapEdge _mapEdge)
    {
        bool tIsUnique = true;
        for (int i = 0; i < edges.Count; i++)
        {
            MapEdge tOtherEdge = edges[i];
            if (_mapEdge.CompareTo(tOtherEdge) == 0)
            {
                tIsUnique = false;
            }
        }
        if (tIsUnique)
        {
            edges.Add(_mapEdge);
        }
    }

    public void DelEdge(MapEdge _mapEdge)
    {
        edges.Remove(_mapEdge);
    }

    public List<MapEdge> GetEdges()
    {
        return edges;
    }

    public bool IsConnectedTo(MapRoomNode _node)
    {
        MapEdge tMapEdge;
        if (edges.Count==0)
        {
            return false;
        }
        for (int i = 0; i < edges.Count; i++)
        {
            //if (edges[i].)
            //{
                
            //}
        }

        return true;
    }

    public void SetRoom(AbstractRoom _room)
    {
        Room = _room;
    }

    public bool LeftNodeAvailable()
    {
        MapEdge tMapEdge;
        for (int i = 0; i < edges.Count; i++)
        {
            
        }

        return true;
    }
    
    public AbstractRoom GetRoom()
    {
        return Room;
    }
}
