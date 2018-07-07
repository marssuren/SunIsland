using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractPanel : MonoBehaviour
{
	protected Texture Img;
	public bool IsHidden;
	public bool isDoneAnimating;

	public AbstractPanel(Texture _img, bool _isStartHidden)
	{
		isDoneAnimating = true;
	}

	//public AbstractPanel(Texture _img,bool _isStartHidden):this(_img,_isStartHidden)
	//{

	//}
	public void Show()
	{
		if (IsHidden)
		{
			IsHidden = false;
			isDoneAnimating = false;
		}
	}
	public void Hide()
	{
		if (!IsHidden)
		{
			IsHidden = true;
			isDoneAnimating = false;
		}
	}

}
