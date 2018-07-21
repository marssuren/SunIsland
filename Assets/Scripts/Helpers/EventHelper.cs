using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHelper : MonoBehaviour
{
    private static float BaseEliteChance = 0.02f;
    private static float BaseMonsterChance = 0.1f;
    private static float BaseShopChance = 0.03f;
    private static float BaseTreasureChance = 0.02f;
    private static float RampEliteChance = 0.02f;
    private static float RampMonsterChance = 0.1f;
    private static float RampShopChance = 0.03f;
    private static float RampTreasureChance = 0.02f;
    private static float ResetEliteChance = 0.0f;
    private static float ResetMonsterChance = 0.1f;
    private static float ResetShopChance = 0.03f;
    private static float ResetTreasureChance = 0.02f;
    private static float EliteChance = 0.02f;
    private static float MonsterChance = 0.1f;
    private static float ShopChance = 0.03f;
    public static float TreasureChance = 0.02f;

    public static RoomResult Roll()
    {
        float tRoll = AbstractDungeon.EventRng.Next();
        RoomResult[] tPossibleResults = new RoomResult[100];
        for (int i = 0; i < tPossibleResults.Length; i++)
        {
            tPossibleResults[i] = RoomResult.Event;
        }

        int tEliteSize = Convert.ToInt32(EliteChance * 100f);
        if (AbstractDungeon.GetCurMapNode().Y < 6)
        {
            tEliteSize = 0;
        }

        int tMonsterSize = Convert.ToInt32(MonsterChance * 100f);
        int tShopSize = Convert.ToInt32(ShopChance * 100f);
        if (AbstractDungeon.GetCurrRoom() is ShopRoom)
        {
            tShopSize = 0;
        }

        int tTreasureSize = Convert.ToInt32(TreasureChance * 100f);
        int tFillIndex = 0;
        int tStartIndex = Math.Min(99, tFillIndex);
        int tEndIndex = Math.Min(100, tFillIndex + tEliteSize);
        fillArray(tPossibleResults, tStartIndex, tEndIndex, RoomResult.Monster);
        tFillIndex += tEliteSize;
        tStartIndex = Math.Min(99, tFillIndex);
        tEndIndex = Math.Min(100, tFillIndex + tMonsterSize);
        fillArray(tPossibleResults, tStartIndex, tEndIndex, RoomResult.Monster);
        tFillIndex += tMonsterSize;
        tStartIndex = Math.Min(99, tFillIndex);
        tEndIndex = Math.Min(100, tFillIndex + tShopSize);
        fillArray(tPossibleResults, tStartIndex, tEndIndex, RoomResult.Shop);
        tFillIndex += tShopSize;
        tStartIndex = Math.Min(99, tFillIndex);
        tEndIndex = Math.Min(100, tFillIndex + tTreasureSize);
        fillArray(tPossibleResults, tStartIndex, tEndIndex, RoomResult.Treasure);
        RoomResult tChoice = tPossibleResults[Convert.ToInt32(tRoll * 100f)];
        if (tChoice == RoomResult.Elite)
        {
            if (AbstractDungeon.Player.HasRelic("JuzuBracelet"))
            {
                //AbstractDungeon.Player.GetRelic("JuzuBracelet").flash();
                tChoice = RoomResult.Event;
            }

            EliteChance = 0f;
        }
        else
        {
            EliteChance += 0.02f;
        }

        if (tChoice == RoomResult.Monster)
        {
            if (AbstractDungeon.Player.HasRelic("JuzuBracelet"))
            {
                //AbstractDungeon.Player.GetRelic("JuzuBracelet").flash();
                tChoice = RoomResult.Event;
            }
            MonsterChance = 0.1f;
        }
        else
        {
            MonsterChance += 0.1f;
        }

        if (tChoice == RoomResult.Shop)
        {
            ShopChance = 0.03f;
        }
        else
        {
            ShopChance += 0.03f;
        }

        if (tChoice == RoomResult.Treasure)
        {
            if (AbstractDungeon.Player.HasRelic("TinyChest"))
            {
                //AbstractDungeon.Player.GetRelic("TinyChest").flash();
                TreasureChance = 0.120000005f;
            }
            else
            {
                TreasureChance = 0.02f;
            }
        }
        else
        {
            TreasureChance += 0.02f;
        }

        return tChoice;

    }

    public static void ResetProbabilities()
    {
        EliteChance = 0.0f;
        MonsterChance = 0.1f;
        ShopChance = 0.03f;
        if (AbstractDungeon.Player.HasRelic("TinyChest"))
        {
            TreasureChance = 0.120000005f;
        }
        else
        {
            TreasureChance = 0.02f;
        }
    }

    public static void SetChances(List<float> _chances)
    {
        EliteChance = _chances[0];
        MonsterChance = _chances[1];
        ShopChance = _chances[2];
        TreasureChance = _chances[3];
    }

    public static List<float> GetChances()
    {
        List<float> tChances = new List<float>();
        tChances.Add(EliteChance);
        tChances.Add(MonsterChance);
        tChances.Add(ShopChance);
        tChances.Add(TreasureChance);
        return tChances;
    }

    private static void fillArray(RoomResult[] tArr, int _startIndex, int _endIndex, RoomResult _result)
    {
        for (int i = 0; i < tArr.Length; i++)
        {
            if (i >= _startIndex && i < _endIndex)
            {
                tArr[i] = _result;
            }
        }
    }
}

public enum RoomResult
{
    None = 0,
    Event = 1,
    Elite = 2,
    Treasure = 3,
    Shop = 4,
    Monster = 5,
}