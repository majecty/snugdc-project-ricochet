﻿using UnityEngine;
using System.Collections;

public class HUDScore : MonoBehaviour {

	void Start () {
		Game.Statistic().score.postChanged += Set;
	}
	
	void Update () {
	
	}

	public void Set(Statistic _statistic) {
		var _text = "Score: " + _statistic.val;
		guiText.text = _text;

	}
}