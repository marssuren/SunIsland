using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
	private static UIController instance;
	public UIController Instance
	{
		get
		{
			if(null == instance)
			{
				instance = this;
			}

			return Instance;
		}
	}
	//public void 

}
