using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureRoom : AbstractRoom
{
    public readonly string[] Text;
    public AbstractChest Chest;
    public TreasureRoom()
    {

    }
    public override void OnPlayerEntry()
    {
        Chest = AbstractDungeon.GetRandomChest();

    }

    public CardRarity GetCardRarity(int _roll)
    {
        byte tRareRate;
        if (AbstractDungeon.Player.HasRelic("Nolth'sGift"))
        {
            tRareRate = 9;
        }
        else
        {
            tRareRate = 3;
        }

        if (_roll < tRareRate)
        {
            if (AbstractDungeon.Player.HasRelic("Nolth'sGift") && _roll > 3)
            {
                //AbstractDungeon.Player.GetRelic("Nolth'sGift").flash();
            }

            return CardRarity.Rare;
        }
        else
        {
            return _roll < 40 ? CardRarity.UnCommon : CardRarity.Common;
        }
    }
}
