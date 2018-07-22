using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCardAction : AbstractGameAction
{
    private bool isShuffleCheck;

    public DrawCardAction(AbstractCreature _source,int _amount,bool _isEndTurnDraw)
    {
        isShuffleCheck = false;
        if (_isEndTurnDraw)
        {
            //AbstractDungeon.TopLevelEffects.Add(new PlayerTurnEffect());


        }
        else if(AbstractDungeon.Player.IsHasPower("NoDraw"))
        {
            //AbstractDungeon.Player.GetPower("NoDraw").flash();
            SetValues(AbstractDungeon.Player,_source,_amount);
            IsDone = true;
            GameActionType = ActionType.Wait;
            return;
        }
        SetValues(AbstractDungeon.Player,_source,_amount);
        GameActionType = ActionType.Draw;
    }

    public DrawCardAction(AbstractCreature _source, int _amount) : this(_source, _amount, false)
    {
        
    }

}
