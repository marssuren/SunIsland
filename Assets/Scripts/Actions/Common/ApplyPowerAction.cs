using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyPowerAction : AbstractGameAction
{
    private AbstractPower powerToApply;

    public ApplyPowerAction(AbstractCreature _target, AbstractCreature _source, AbstractPower _powerToApply, int _stackAmount, bool _isFast, AttackEffect _attackEffect)
    {
        SetValues(_target, _source, _stackAmount);
        powerToApply = _powerToApply;
        if (AbstractDungeon.Player.HasRelic("SnakeSkull") && Source != null && Source.IsPlayer && Target != Source && powerToApply.ID.Equals("Poison"))
        {
            //AbstractDungeon.Player.GetRelic("SnakeSull").flash();
            powerToApply.Amount++;
            Amount++;

        }

        if (powerToApply.ID.Equals("Corruption"))       //腐化
        {
            for (int i = 0; i < AbstractDungeon.Player.Hand.Group.Count; i++)
            {
                AbstractCard tCard = AbstractDungeon.Player.Hand.Group[i];
                if (tCard.Type == CardType.Skill)
                {
                    tCard.ModifyCostForCombat(-9);
                }
            }

            for (int i = 0; i < AbstractDungeon.Player.DrawPile.Group.Count; i++)
            {
                AbstractCard tCard = AbstractDungeon.Player.DrawPile.Group[i];
                if (tCard.Type == CardType.Skill)
                {
                    tCard.ModifyCostForCombat(-9);
                }
            }

            for (int i = 0; i < AbstractDungeon.Player.DiscardPile.Group.Count; i++)
            {
                AbstractCard tCard = AbstractDungeon.Player.DiscardPile.Group[i];
                if (tCard.Type==CardType.Skill)
                {
                    tCard.ModifyCostForCombat(-9);
                }
            }

            for (int i = 0; i < AbstractDungeon.Player.ExhaustPile.Group.Count; i++)
            {
                AbstractCard tCard = AbstractDungeon.Player.ExhaustPile.Group[i];
                if (tCard.Type == CardType.Skill)
                {
                    tCard.ModifyCostForCombat(-9);
                }
            }
        }

        GameActionType = ActionType.Power;
        GameAttackEffect = _attackEffect;
        if (AbstractDungeon.GetMonsters().AreMonstersBasicallyDead())
        {
            IsDone = true;
        }
    }

    public ApplyPowerAction(AbstractCreature _target,AbstractCreature _source,AbstractPower _powerToApply,int _stackAmount,bool _isFast):this(_target,_source,_powerToApply,_stackAmount,_isFast,AttackEffect.None)
    {
        
    }
    public ApplyPowerAction(AbstractCreature _target, AbstractCreature _source, AbstractPower _powerToApply, int _stackAmount) : this(_target, _source, _powerToApply, _stackAmount, false, AttackEffect.None)
    {

    }
    public ApplyPowerAction(AbstractCreature _target,AbstractCreature _source,AbstractPower _powerToApply):this(_target,_source,_powerToApply,-1)
    {
        
    }

    public ApplyPowerAction(AbstractCreature _target,AbstractCreature _source,AbstractPower _powerToApply,int _stackAmount,AttackEffect _effect):this(_target,_source,_powerToApply,_stackAmount,false,_effect)
    {
            
    }
    

}
