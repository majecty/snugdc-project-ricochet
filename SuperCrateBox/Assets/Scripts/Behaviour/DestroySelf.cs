﻿using UnityEngine;
using System.Collections;

public class DestroySelf : MonoBehaviour {

	public void Destroy() 
	{
		GameObject.Destroy (gameObject);
	}
}
