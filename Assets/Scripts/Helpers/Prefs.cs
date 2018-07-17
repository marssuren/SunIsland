using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prefs
{
	public Dictionary<string, string> Data = new Dictionary<string, string>();
	public string filePath;

	public string GetString(string _key, string _def = "")
	{
		Data.TryGetValue(_key, out _def);
		return _def;
	}
	public int GetInt(string _key, int _def = -999)
	{
		if(Data.ContainsKey(_key))
		{
			_def = Convert.ToInt32(Data[_key].Trim());
		}
		return _def;
	}
	public void PutInt(string _key, int _value)
	{
		Data[_key] = _value.ToString();
	}
	public float GetFloat(string _key, float _def)
	{
		if(Data.ContainsKey(_key))
		{
			_def = Convert.ToSingle(Data[_key]);
		}
		return _def;
	}
	public void PutFloat(string _key, float _value)
	{
		Data[_key] = _value.ToString();
	}
	public long GetLong(string _key, long _def)
	{
		if(Data.ContainsKey(_key))
		{
			_def = Convert.ToInt64(Data[_key].Trim());
		}
		return _def;
	}
	public void PutLong(string _key, long _value)
	{
		Data[_key] = _value.ToString();
	}
	public bool GetBool(string _key, bool _def)
	{
		if(Data.ContainsKey(_key))
		{
			_def = Convert.ToBoolean(Data[_key]);
		}
		return _def;
	}
	public void PutBool(string _key, bool _value)
	{
		Data[_key] = _value.ToString();
	}
}
