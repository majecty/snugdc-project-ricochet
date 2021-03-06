using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NetworkView))]
public class NetworkBridge : MonoBehaviour
{
	public NetworkViewAllocator allocator;

	public NetworkView global;
	public NetworkView game;

	void Start()
	{
		if (networkView == null
		    || global == null
		    || game == null)
		{
			LogCommon.MissingComponent();
			return;
		}
		
		allocator = gameObject.AddComponent<NetworkViewAllocator>();

		Global.Instance.networkBridge = this;
		Global.Instance.networkView.viewID = global.viewID;
		global.viewID = NetworkViewID.unassigned;
		Destroy(global);

		Game.Instance.networkView.viewID = game.viewID;
		game.viewID = NetworkViewID.unassigned;
		Destroy(game);
	}

	void OnDestroy()
	{
		Global.Instance.networkBridge = null;
	}
}

