using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul
{
	public AbstractCard Card;
	public CardGroup Group;
	private List<Vector2> controlPoints=new List<Vector2>();
	private const int NumPoints = 20;
	private Vector2[] points=new Vector2[20];
	private Vector2 pos;
	private Vector2 target;
	private const float vfxInterval = 0.015f;
	private float backupTime;
	private float vfxTimer = 0.015f;
	private const float backUpTime = 1.5f;
	private bool isInvisible = false;
	private static float discardX;
	private static float discardY;
	private static float drawPileX;
	private static float drawPileY;
	private static float masterDeckX;
	private static float masterDeckY;
	private float currentSpeed = 0f;
	private static float startVelocity;
	private static float maxVelocity;
	private static float velocityRampRate;
	public bool isReadyForReuse;
	public bool isDone;
	private static float dstThreshold;
	private static float homeInThreshold;
	private float rotation;
	private bool isRotateClockwise=true;
	private bool isStopRotating;
	private float rotationRate;
	private static float rotation_Rate;
	private static float rotation_Ramp_Rate = 800f;

	public Soul()
	{
		
	}



}
