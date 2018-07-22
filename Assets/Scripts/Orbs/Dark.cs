using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dark : AbstractOrb
{
    public const string OrbId = "Dark";
    public static string[] Desc;

    public Dark()
    {
        Id = "Dark";
        BaseEvokeAmount = 6;
        EvokeAmount = BaseEvokeAmount;
        BasePassiveAmount = 6;
        PassiveAmount = BasePassiveAmount;

    }

    public override void OnEvoke()
    {
        AbstractMonster tWeakestMonster = null;
        for (int i = 0; i < AbstractDungeon.GetMonsters().Monsters.Count; i++)
        {
            AbstractMonster tMonster = AbstractDungeon.GetMonsters().Monsters[i];
            if (!tMonster.IsDeadOrEscaped())
            {
                if (null == tWeakestMonster)
                {
                    tWeakestMonster = tMonster;
                }
                else if (tMonster.CurrentHealth < tWeakestMonster.CurrentHealth)
                {
                    tWeakestMonster = tMonster;
                }
            }
        }

        for (int i = 0; i < AbstractDungeon.GetMonsters().Monsters.Count; i++)
        {
            AbstractMonster tMonster = AbstractDungeon.GetMonsters().Monsters[i];
            if (tMonster.IsHasPower("Lockon") && !tMonster.IsDeadOrEscaped())
            {
                tWeakestMonster = tMonster;
                break;
            }
        }

        if (null != tWeakestMonster)
        {
            AbstractDungeon.ActionManager.AddToTop(new DamageAction(tWeakestMonster, new DamageInfo(AbstractDungeon.Player, EvokeAmount, DamageType.Thorns), AttackEffect.Fire));
        }
    }

    public void OnEndOfTurn()
    {
        //AbstractDungeon.ActionManager.AddToBottom();
        EvokeAmount += PassiveAmount;

    }

    public void TriggerEvokeAnimation()
    {
        //AbstractDungeon.EffectsQueue.Add(new DarkOrbActiveEffect());
    }

    public void ApplyFocus()
    {
        AbstractPower tPower = AbstractDungeon.Player.GetPower("Focus");
        if (null != tPower)
        {
            PassiveAmount = Mathf.Max(0, PassiveAmount + tPower.Amount);
        }
    }

    public override AbstractOrb MakeCopy()
    {
        throw new System.NotImplementedException();
    }
}
