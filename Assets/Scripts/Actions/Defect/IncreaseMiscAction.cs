using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseMiscAction : AbstractGameAction
{
    private int miscValue;
    private int miscIncrease;
    private string id;

    public IncreaseMiscAction(string _id,int _miscValue,int _miscIncrease)
    {
        miscIncrease = _miscIncrease;
        miscValue = _miscValue;
        id = _id;
    }

}
