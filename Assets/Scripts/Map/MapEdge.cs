﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEdge:IComparable<MapEdge>
{
    public bool IsTaken;

    public MapEdge(int _srcX,int _srcY,int _dtsX,int _dstY)
    {
        
    }

    public MapEdge(int _srcX,int _srcY,bool _isBoss)
    {
        
    }
    public int CompareTo(MapEdge other)
    {
        throw new NotImplementedException();
    }

    public void MarkAsTaken()
    {
        IsTaken = true;

    }
}