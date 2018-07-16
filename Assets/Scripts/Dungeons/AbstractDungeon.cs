using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

public abstract class AbstractDungeon
{
    public static string[] Text;
    public static string Name;
    public static string LevelNum;
    public static string Id;
    public static int FloorNum;
    public static int ActNum;
    public static AbstractPlayer Player;
    //public static List<abstract>
    protected static float shrineChance;
    private static bool isFirstChest;
    private static bool isEncounteredCursedChest;
    protected static float CardUpgradeedChance;
    public static AbstractCard TransformedCard;
    public static bool LoadingPostCombat;
    public static Random MonsterRng;
    public static Random MapRng;
    public static Random EventRng;
    public static Random MerchantRng;
    public static Random CardRng;
    public static Random TreasureRng;   //财宝
    public static Random RelicRng;      //遗迹
    public static Random PotionRng;     //药水
    public static Random MonsterHpRng;
    public static Random AIRng;
    public static Random ShuffleRng;    //洗牌
    public static Random CardRandomRng;
    public static Random MiscRng;
    public static CardGroup SRCColorlessCardPool;
    public static CardGroup SRCCurseCardPool;
    public static CardGroup SRCCommonCardPool;
    public static CardGroup SRCUncommonCardPool;
    public static CardGroup SRCRareCardPool;
    public static CardGroup ColorlessCardPool;
    public static CardGroup CurseCardPool;
    public static CardGroup CommonCardPool;
    public static CardGroup UncommonCardPool;
    public static CardGroup RareCardPool;
    public static List<string> CommonRelicPool;
    public static List<string> UncommonRelicPool;
    public static List<string> RareRelicPool;
    public static List<string> ShopRelicPool;
    public static List<string> BossRelicPool;
    public static string LastCombatMetricKey;
    public static List<string> MonsterList;
    public static List<string> EliteMonsterList;
    public static List<string> BossList;
    public static string BossKey;
    public static List<string> EventList;
    public static List<string> ShrineList;
    public static List<string> SpecialOneTimeEventList;
    public static GameActionManager ActionManager;
    public static List<AbstractGameEffect> TopLevelEffects;
    public static List<AbstractGameEffect> TopLevelEffectsQueue;
    public static List<AbstractGameEffect> EffectList;
    public static List<AbstractGameEffect> EffectsQueue;
    public static bool IsTurnPhaseEffectActive;
    public static float ColorlessRareChance;
    protected static float ShopRoomChance;
    protected static float RestRoomChance;
    protected static float EventRoomChance;
    protected static float EliteRoomChance;
    protected static float TreasureRoomChance;
    protected static int SmallChestChance;
    protected static int MediumChestChance;
    protected static int LargeChestChance;
    protected static int CommonRelicChance;
    protected static int UncommonRelicChance;
    protected static int RareRelicChance;
    public static AbstractScene Scene;
    public static MapRoomNode CurMapNode;
    public static List<List<MapRoomNode>> Map;
    public static bool LeftRoomAvailable;
    public static bool CenterRoomAvailable;
    public static bool RightRoomAvailable;
    public static bool FirstRoomChosen;
    public static OverlayMenu OverLayMenu;
    public static MapRoomNode NextRoom;
    public static List<string> RelicsToRemoveOnStart;
    public static int BossCount;
    public static bool IsAscensionMode;
    public static int ascensionLevel;
    public static List<AbstractBlight> Blights;
    public static bool ascensionCheck;
    public static Random random;

    public AbstractDungeon(string _name, string _levelId, AbstractPlayer _player, List<string> _newSpecialOneTimeEventList)
    {
        Name = _name;
        Id = _levelId;
        Player = _player;
        ActionManager = new GameActionManager();
        SpecialOneTimeEventList = _newSpecialOneTimeEventList;

    }
    public static void DungeonTransitionSetup()
    {
        ActNum++;
        EventList.Clear();
        ShrineList.Clear();
        MonsterList.Clear();
        EliteMonsterList.Clear();
        BossList.Clear();

    }
    public static void OnModifyPower()
    {

    }
    public void CheckForPactAchievement()
    {

    }
    public static AbstractRoom GetCurrRoom()
    {
        return CurMapNode.GetRoom();
    }
    public static MapRoomNode GetCurMapNode()
    {
        return CurMapNode;
    }
    public static void SetCurMapNode(MapRoomNode _curMapNode)
    {

    }

    public static AbstractChest GetRandomChest()
    {
        int tRoll = random.Next(0, 99);

        if (tRoll < SmallChestChance)
        {
            isFirstChest = false;
            return new SmallChest();
        }
        if (tRoll < MediumChestChance + SmallChestChance)
        {
            isFirstChest = false;
            return new MediumChest();
        }

        if (tRoll < LargeChestChance + MediumChestChance + SmallChestChance)
        {
            isFirstChest = false;
            return new LargeChest();
        }

        if (isFirstChest)
        {
            isFirstChest = false;
            return new SmallChest();
        }

        if (!isEncounteredCursedChest)
        {
            isEncounteredCursedChest = true;
            return new CursedChest();
        }

        return new SmallChest();
    }
    private AbstractRoom generateRoom()
    {

    }
    public static MonsterGroup GetMonsters()
    {
        return GetCurrRoom().Monsters;
    }
    protected static void GenerateMap()
    {
        if (Player.HasRelic("MemberShipCard"))
        {

        }

        int tMapHeight = 15;
        int tMapWidth = 7;
        int tMapDensity = 6;
        List<AbstractRoom> tRoomList = new List<AbstractRoom>();
        Map = MapGenerator.GenerateDungeon(tMapHeight, tMapWidth, tMapDensity, MapRng);
        int tCount = 0;
        for (int i = 0; i < Map.Count; i++)
        {
            for (int j = 0; j < Map[i].Count; j++)
            {
                MapRoomNode tNode = Map[i][j];
                if (tNode.)
                {
                    
                }
            }
        }
    }
}
