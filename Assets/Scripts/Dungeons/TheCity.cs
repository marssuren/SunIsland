using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheCity:AbstractDungeon
{
    public readonly string[] Text;
    public readonly string Name;
    public const string Id = "TheCity";
    public TheCity(string _name, string _levelId, AbstractPlayer _player, List<string> _newSpecialOneTimeEventList) : base(_name, "TheCity", _player, _newSpecialOneTimeEventList)
    {
        
    }

}
