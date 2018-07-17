using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomEventDialog
{
	private bool isMoving = false;
	private bool isShow = false;

	private bool isTextDone = true;
	public static int SelectedOption;
	public static bool IsWaitForInput;
	public static List<Button> OptionBtnLst;
	public int GetSelectedOption()
	{
		IsWaitForInput = true;
		return SelectedOption;
	}
	public void Clear()
	{
		OptionBtnLst.Clear();

	}
}
