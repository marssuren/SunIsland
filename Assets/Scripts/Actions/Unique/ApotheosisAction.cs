using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApotheosisAction : AbstractGameAction      //神化
{
    public ApotheosisAction()
    {
        GameActionType = ActionType.Wait;
    }

    private void upgradeAllCardsInGroup(CardGroup _cardGroup)
    {
        for (int i = 0; i < _cardGroup.Group.Count; i++)
        {
            AbstractCard tCard = _cardGroup.Group[i];
            if (tCard.IsCanUpgrade())
            {
                if (_cardGroup.Type==CardGroupType.Hand)
                {
                    //tCard.SuperFlash();
                }
                tCard.Upgrade();
                //tCard.
            }
        }
    }
}
