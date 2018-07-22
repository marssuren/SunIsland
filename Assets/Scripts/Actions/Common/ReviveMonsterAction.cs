using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveMonsterAction : AbstractGameAction
{
    private bool isHealingEffect;

    public ReviveMonsterAction(AbstractMonster _target, AbstractCreature _source, bool _isHealEffect)
    {
        isHealingEffect = false;
        SetValues(_target, _source, 0);
        GameActionType = ActionType.Special;
        if (AbstractDungeon.Player.HasRelic("Philosopher'sStone"))
        {
            _target.AddPower(new StrengthPower(_target, 2));
        }

        isHealingEffect = _isHealEffect;
    }

    public ReviveMonsterAction(AbstractMonster _target,AbstractCreature _source):this(_target,_source,true)
    {
        
    }
}
