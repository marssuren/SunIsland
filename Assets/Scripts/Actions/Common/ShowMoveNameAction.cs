using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMoveNameAction : AbstractGameAction
{
    private string msg;

    public ShowMoveNameAction(AbstractMonster _source,string _msg)
    {
        SetValues(_source,_source);
        msg = _msg;
        GameActionType = ActionType.Text;

    }

    public ShowMoveNameAction(AbstractMonster _source)
    {
        SetValues(_source,_source);
        msg = _source.MoveName;
        _source.MoveName = null;
        GameActionType = ActionType.Text;
    }


}
