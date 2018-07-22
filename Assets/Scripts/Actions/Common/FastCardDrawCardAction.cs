using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastCardDrawCardAction : AbstractGameAction
{
    private bool isShuffleCheck;

    public FastCardDrawCardAction(AbstractCreature _source, int _amount, bool _isEndTurnDraw)
    {
        isShuffleCheck = false;
        if (_isEndTurnDraw)
        {
            //AbstractDungeon.EffectList.Add(new PlayerTurnEffect());
        }
        else if (AbstractDungeon.Player.IsHasPower("NoDraw"))
        {
            //AbstractDungeon.Player.GetPower("NoDraw").flash();
            SetValues(AbstractDungeon.Player, _source, _amount);
            IsDone = true;
            GameActionType = ActionType.Wait;
            return;
        }
        SetValues(AbstractDungeon.Player, _source, _amount);
        GameActionType = ActionType.Draw;

    }

    public FastCardDrawCardAction(AbstractCreature _source, int _amount) : this(_source, _amount, false)
    {

    }
}
