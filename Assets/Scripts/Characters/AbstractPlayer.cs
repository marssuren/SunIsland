using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractPlayer : AbstractCreature
{
	public static string[] Message;
	public static string[] Label;
	public PlayerClass ChosenClass;
	public int GameHandSize;
	public int MasterHandSize;
	public CardGroup MasterDeck;
	public CardGroup DrawPile;
	public CardGroup Hand;
	public CardGroup DiscardPile;
	public CardGroup ExhaustPile;
	public CardGroup Limbo;
	public List<AbstractRelic> Relics;
	public int PotionSlots;
	public List<AbstractPotion> Potions;
	//public 
	public override void Damage(DamageInfo _damageInfo)
	{
		throw new System.NotImplementedException();
		
	}
	public void ApplyStartOfTurnOrbs()
	{
		if (!AbstractDungeon.Player)
		{
			
		}
	}

    public bool HasRelic(string _targetId)
    {
        for (int i = 0; i < Relics.Count; i++)
        {
            if (Relics[i].relicId==_targetId)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasPotion(string _id)
    {
        for (int i = 0; i < Potions.Count; i++)
        {
            if (Potions[i].Id==_id)
            {
                return true;
            }
        }

        return false;
    }

    public void LoseRandomRelics(int _amount)
    {
        if (_amount>Relics.Count)
        {
            for (int i = 0; i < Relics.Count; i++)
            {
                Relics[i].OnUnEquip();
            }
            Relics.Clear();
        }
        else
        {
            for (int i = 0; i < _amount; i++)
            {
                int tIndex = Random.Range(0, Relics.Count);
                Relics[tIndex].OnUnEquip();
                Relics.RemoveAt(tIndex);
            }
            
        }
    }

    public void ReorganizeRelics()
    {
        List<AbstractRelic> tRelicsLst=new List<AbstractRelic>();
        tRelicsLst.AddRange(Relics);
        Relics.Clear();
        for (int i = 0; i < tRelicsLst.Count; i++)
        {
            tRelicsLst[i].ReOrgnaizeObtain(this,i,false,tRelicsLst.Count);
        }
    }

    public AbstractRelic GetRelic(string _targetId)
    {
        AbstractRelic tAbstractRelic = null;
        for (int i = 0; i < Relics.Count; i++)
        {
            if (Relics[i].relicId==_targetId)
            {
                tAbstractRelic = Relics[i];
            }
        }
        return tAbstractRelic;
    }

    public void ObtainPotion(int _slot, AbstractPotion _potion)
    {
        if (_slot<PotionSlots)
        {
            Potions.Insert(_slot,_potion);
            _potion.
        }
    }
}
public enum PlayerClass
{
	None=0,
	IronClad=1,
	TheSilent=2,
	Defect=3,
}
public enum RHoverType
{
	None=0,
	Relic=1,
	Blight=2,
}
