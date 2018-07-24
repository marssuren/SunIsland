using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompileDriverAction : AbstractGameAction
{
    public CompileDriverAction(AbstractPlayer _source,int _amount)
    {
        SetValues(Target,_source,Amount);
        GameActionType = ActionType.Wait;
    }
	
}
