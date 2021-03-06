﻿using System.Collections;
using System.Collections.Generic;
//using UnityEngine;
using Random = System.Random;

public class MapGenerator
{
    public MapGenerator()
    {

    }

    public static List<List<MapRoomNode>> GenerateDungeon(int _height, int _width, int _pathDesity, Random _rng)
    {
        List<List<MapRoomNode>> tMap = CreateNodes(_height, _width);
        return tMap;
    }

    //private static List<List<MapRoomNode>> filterRedundantEdgesFromRow(List<List<MapRoomNode>> _map)
    //{
    //    List<MapEdge> tExistingEdges = new List<MapEdge>();
    //    List<MapEdge> tDeleteEdges = new List<MapEdge>();
    //    for (int i = 0; i < _map[0].Count; i++)
    //    {
    //        MapRoomNode tNode = _map[0][i];
    //        if (!tNode.IsHasEdges() && i == _map[0].Count - 1)
    //        {
    //            return _map;
    //        }
    //    }

    //}

    public static List<List<MapRoomNode>> CreateNodes(int _height, int _width)
    {
        List<List<MapRoomNode>> tNodes = new List<List<MapRoomNode>>();
        for (int i = 0; i < _height; i++)
        {
            List<MapRoomNode> tRow = new List<MapRoomNode>();
            for (int j = 0; j < _width; j++)
            {
                tRow.Add(new MapRoomNode(i, j));
            }
            tNodes.Add(tRow);
        }
        return tNodes;
    }
}
