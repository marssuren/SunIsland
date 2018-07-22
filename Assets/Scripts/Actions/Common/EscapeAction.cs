using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeAction : AbstractGameAction
{
    public EscapeAction(AbstractMonster _source)
    {
        SetValues(_source,_source);
        GameActionType = ActionType.Text;
    }
	
}
