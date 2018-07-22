using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionLogEntry
{
    public ActionType Type;

    public ActionLogEntry(ActionType _type)
    {
        Type = _type;
    }

    public string ToString()
    {
        return Type.ToString();
    }

}
