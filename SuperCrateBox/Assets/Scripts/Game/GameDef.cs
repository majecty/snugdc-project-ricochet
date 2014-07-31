using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameDef : MonoBehaviour
{
	public bool applyOnStart = true;
	public bool deleteAfterApply = true;
	public GameAudioDef audio_;
	public GameCameraDef camera_;

	public bool useCharacterDef = false;
	public GameCharacterDef character;

	public bool useWeaponDef = false;
	public GameWeaponDef weapon;

	void Start ()
	{
		// for instantiation...
		if (Game.Instance.name == "") { int n; }
		if (applyOnStart) Apply();
	}

	void Apply()
	{
		if (audio_ != null) audio_.Apply();
		if (camera_ != null) camera_.Apply();
		if (useCharacterDef && character != null) character.Apply();
		if (useWeaponDef && weapon != null) weapon.Apply();
		if (deleteAfterApply) Destroy(gameObject);
	}
}

[System.Serializable]
public class GameAudioDef 
{
	public bool pause = false;
	public float volume = 1;
	
	public void Apply()
	{
		AudioListener.pause = pause;
		AudioListener.volume = volume;
	}
}

[System.Serializable]
public class GameCameraDef
{
	public Camera camera;

	public void Apply() 
	{
		if (camera != null) 
		{
			Game.Camera().camera = camera;
		}
	}
}

[System.Serializable]
public class GameCharacterDef
{
	public Character character;

	public bool useMaxUpForce = false;
	public float maxUpForce = 2f;

	public bool useUpForce = false;
	public float upForce = 30f;
	
	public GameObject weaponDefault;
	
	public List<Color> characterColors;
	
	public void Apply()
	{
		if (character != null) Game.Character().character = character;
		if (useMaxUpForce) Game.Character().maxUpForce = maxUpForce;
		if (useUpForce) Game.Character().upForce = upForce;
		if (characterColors != null && characterColors.Count > 0) 
			Game.Character().characterColors = new List<Color>(characterColors);
	}
}

[System.Serializable]
public class GameWeaponDef
{
	public List<string> weaponSet;

	public void Apply()
	{
		if (weaponSet != null && weaponSet.Count > 0) Game.Weapon().weaponSet = new List<string>(weaponSet);
	}
}

