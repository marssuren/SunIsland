using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMonster : AbstractCreature
{
	public static  string[] Text;
	public static string StingerKey;
	public static long StingerID;
	private const float deathTime = 1.8f;
	private const float escapeTime = 3f;
	protected const byte Escape = 99;
	protected const byte Roll=98;
	public float DeathTimer;
	protected Dictionary<byte, string> MoveSet;
	public bool IsEscaped;
	public bool IsEscapeNext;
	public EnemyType Type;
	private float hoverTime;
	public bool IsCannotEscape;
	public List<DamageInfo> DamageInfoList;
    private EnemyMoveInfo move;
    public List<byte> MoveHistory;
    public List<AbstractGameEffect> IntentFlash;
    private List<AbstractGameEffect> IntentVFX;
    public byte NextMove;

    public Intent MonsterIntent;
	public Intent TipIntent;
    private Texture intentImg;
    private Texture intentBg;
    private int intentDmg;
    private int intentBaseDmg;
    private int intentMultiAmt;
    private bool isMultiDmg;
    public string MoveName;
    public static string[] Moves;
    public static string[] Dialog;


	public static IEnumerator<AbstractMonster> SortByCollider;

	public AbstractMonster(string _name, string _id, int _maxHealth, string _imgURL) : this(_name, _id, _maxHealth,
		_imgURL, false)
	{
	}
	
	public AbstractMonster(string _name, string _id, int _maxHealth, string _imgURL, bool _isIgnoreBlights)
	{
		DeathTimer = 0f;
		IsEscaped = false;
		IsEscapeNext = false;
		Type = EnemyType.Normal;

		IsCannotEscape = false;
		DamageInfoList=new List<DamageInfo>();
		MonsterIntent = Intent.Debug;
		TipIntent = Intent.Debug;
		IsPlayer = false;
		Name = _name;
		Id = _id;
		MaxHealth = _maxHealth;
		CurrentHealth = MaxHealth;
		CurrentBlock = 0;

	}
	void Update()
	{
		if (powers.Count>0)
		{
			AbstractPower tAbstractPower = powers[0];

		}
		
	}
	private void updateIntent()
	{

	}
	public void Heal(int _healAmount)
	{
		if (!IsDying)
		{
			AbstractPower tAbstractPower;

		}
	}

    public void CreateIntent()
    {
        this.intent = move.InfoIntent;

    }
}
public enum EnemyType
{
	None=0,
	Normal=1,
	Elite=2,
	Boss=3,
}
public enum Intent		//意图
{
	None=0,
	Attack=1,
	AttackBuff=2,		
	AttackDebuff=3,
	AttackDefend=4,
	Buff=5,
	Debuff=6,
	StrongDebuff=7,
	Debug=8,
	Defend=9,
	DefendDebuff=10,
	DefendBuff=11,
	Escape=12,
	Magic=13,
	Sleep=14,
	Stun=15,		//昏迷
	Unknown=16

}
