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
	public List<AbstractRelic> Potions;
	public 
	public override void Damage(DamageInfo _damageInfo)
	{
		throw new System.NotImplementedException();
		
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
