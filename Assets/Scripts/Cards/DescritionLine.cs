using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescritionLine
{
	public string Text;
	public float Width;
	private static float offest;

	public DescritionLine(string _text,float _width)
	{
		Text = _text.Trim();
		Width = _width - offest;
	}
}
