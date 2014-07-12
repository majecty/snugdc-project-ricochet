using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class GenericHelper
{
	public static T SelectRandom<T>( List<T> _list) 
	{
		return _list [Random.Range (0, _list.Count)];
	}
}

