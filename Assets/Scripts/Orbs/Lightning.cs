using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : AbstractOrb
{
    public static string OrbId = "Lightning";
    public static string[] Desc;

    public Lightning()
    {
        Id = "Lightning";
        BaseEvokeAmount = 8;
        EvokeAmount = BaseEvokeAmount;
        BasePassiveAmount = 3;
        PassiveAmount = BasePassiveAmount;

    }
    public void UpdateDescription()
    {
        ApplyFocus();

    }

    public void OnEvoke()
    {
        if (AbstractDungeon.Player.IsHasPower("Electro"))
        {
            AbstractDungeon.ActionManager.AddToTop(new LightningOrbEvokeAction(new DamageInfo(AbstractDungeon.Player, EvokeAmount, DamageType.Thorns), true));
        }
        else
        {
            AbstractDungeon.ActionManager.AddToTop(new LightningOrbEvokeAction(new DamageInfo(AbstractDungeon.Player, EvokeAmount, DamageType.Thorns), false));
        }
    }

    public void OnEndOfTurn()
    {
        if (AbstractDungeon.Player.IsHasPower("Electro"))
        {
            AbstractDungeon.ActionManager.AddToTop(new LightningOrbEvokeAction(new DamageInfo(AbstractDungeon.Player, PassiveAmount, DamageType.Thorns), true));
        }
        else
        {
            AbstractDungeon.ActionManager.AddToBottom(new LightningOrbPassiveAction(new DamageInfo(AbstractDungeon.Player, PassiveAmount, DamageType.Thorns), this, false));
        }
    }

    private void triggerPassiveEffect(DamageInfo _info, bool _isHitAll)
    {
        AbstractMonster tMonster;
        if (!_isHitAll)
        {
            AbstractCreature tCreature = AbstractDungeon.GetRandomMonster();
            for (int i = 0; i < AbstractDungeon.GetMonsters().Monsters.Count; i++)
            {
                tMonster = AbstractDungeon.GetMonsters().Monsters[i];
                if (tMonster.IsHasPower("Lockon")&&!tMonster.IsDeadOrEscaped())
                {
                    tCreature = tMonster;
                    break;
                }
            }

            if (null!=tCreature)
            {
                
            }
            AbstractDungeon.ActionManager.AddToBottom(new );
        }
    }
}
