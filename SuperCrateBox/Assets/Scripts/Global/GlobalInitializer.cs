using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalInitializer : MonoBehaviour
{
	public bool initializeOnStart = true;
	public bool destroyAfterInitialize = true;

	public bool bgmEnabled = true;
	public AudioClip bgm;

	public bool overrideTransitionGameCutScene = false;
	public GameObject transitionGameCutScenePrf;

	void Start ()
	{
		if (initializeOnStart)
			Initialize();
	}

	void Initialize() 
	{
		var _global = Global.Instance;
		var _game = Game.Instance;

		if (bgmEnabled && bgm != null)
		{
			_global.bgm.Stop();
			_global.bgm.clip = bgm;
			_global.bgm.loop = true;
			_global.bgm.Play();
		}

//		if (gameSetting != null)
//			Global.Instance.gameSetting = gameSetting;

		if (overrideTransitionGameCutScene)
			_global.transition.gameCutScene = transitionGameCutScenePrf;

		if (destroyAfterInitialize)
			Destroy( gameObject);
	}
}

