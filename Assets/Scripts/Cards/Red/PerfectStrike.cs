using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectStrike : AbstractCard, IStrikable               //完美打击
{
    private const string Id = "PerfectStrike";
    public static string Name;
    public static string Description;
    private const int cost = 2;
    private const int damageAmt = 6;
    public const int Bonus = 2;
    public const int UpgBonus = 3;


    public PerfectStrike() : base("PerfectStrike", Name, "", 2, Description, CardType.Attack, CardRarity.Rare, CardTarget.Enemy)
    {
        BaseDamage = 6;
        BaseMagicNumber = 2;
        MagicNumber = BaseMagicNumber;
    }

    public PerfectStrike(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription,
        CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget, DamageType _damageType) : base(_cardId,
        _name, _imgURL, _cost, _rawDescription, _cardType, _cardRarity, _cardTarget, _damageType)
    {

    }



    public PerfectStrike(string _cardId, string _name, string _imgURL, int _cost, string _rawDescription,
        CardType _cardType, CardRarity _cardRarity, CardTarget _cardTarget) : base(_cardId, _name, _imgURL, _cost,
        _rawDescription, _cardType, _cardRarity, _cardTarget)
    {
    }

    public static int CountCards()
    {
        int tCount = 0;
        AbstractCard tCard;
        for (int i = 0; i < AbstractDungeon.Player.Hand.Group.Count; i++)
        {
            tCard = AbstractDungeon.Player.Hand.Group[i];
            if (tCard is IStrikable)
            {
                tCount++;
            }
        }

        for (int i = 0; i < AbstractDungeon.Player.DrawPile.Group.Count; i++)
        {
            tCard = AbstractDungeon.Player.DrawPile.Group[i];
            if (tCard is IStrikable)
            {
                tCount++;
            }
        }

        for (int i = 0; i < AbstractDungeon.Player.DiscardPile.Group.Count; i++)
        {
            tCard = AbstractDungeon.Player.DiscardPile.Group[i];
            if (tCard is IStrikable)
            {
                tCount++;
            }
        }

        return tCount;
    }
    public static bool IsStrike(AbstractCard _card)
    {
        return _card is IStrikable;
    }

    public void Use(AbstractPlayer _player, AbstractMonster _monster)
    {
        AbstractDungeon.ActionManager.AddToBottom(new DamageAction(_monster, new DamageInfo(_player, Damage, DamageTypeForTurn), AttackEffect.SlashDiagonal));
    }
    public override AbstractCard MakeCopy()
    {
        return new PerfectStrike();
    }

    public override void Upgrade()
    {
        throw new System.NotImplementedException();
    }


}