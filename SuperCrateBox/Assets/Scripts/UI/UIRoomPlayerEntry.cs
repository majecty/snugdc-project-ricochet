﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIRoomPlayerEntry : MonoBehaviour 
{
	private PlayerInfo m_Player;
	public PlayerInfo player { 
		get { return m_Player; } 
		set { 
			if (m_Player != null) m_Player.postChanged -= ListenPlayerInfoChanged;

			m_Player = value;
			Refresh();

			if (m_Player != null) m_Player.postChanged += ListenPlayerInfoChanged;
		}
	}

	public UILabel nameLabel;

	private bool m_PrevReadyState = false;
	public List<UITweener> readyTweens;

	void Start()
	{
		if (readyTweens == null) readyTweens = new List<UITweener>();
		Global.Ready().postReady += ListenReady;
	}

	void OnDestroy()
	{
		Global.Ready().postReady -= ListenReady;
		if (player != null) player = null;
	}

	void Refresh()
	{
		if (player != null)
		{
			SetReady(Global.Ready().IsReady(player.guid));
		}

		if (nameLabel != null) 
			nameLabel.text = m_Player == null ? "undefined" : m_Player.name;
	}

	void SetReady(bool _ready)
	{
		if (m_PrevReadyState == _ready) return;

		m_PrevReadyState = _ready;
		
		foreach (var _tween in readyTweens)
			_tween.Play(_ready);

	}

	void OnTooltip (bool show)
	{
		if (show)
		{
			UITooltip.ShowText("highscore");
		}
		else 
		{
			UITooltip.ShowText(null);
		}
		return;
	}

	void ListenPlayerSetup(PlayerInfo _playerInfo)
	{
		if (player == _playerInfo)
			Refresh();
	}

	void ListenPlayerInfoChanged(PlayerInfo _playerInfo)
	{
		if (player == _playerInfo)
			Refresh();
	}

	void ListenReady(string _player, bool _ready)
	{
		if (player == null)
		{
			Debug.LogError("PlayerInfo is not set!");
			return;
		}

		if (player.guid == _player)
			SetReady(_ready);
	}
}
