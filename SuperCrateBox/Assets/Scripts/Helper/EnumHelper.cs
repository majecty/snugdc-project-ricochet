using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class EnumHelper 
{
	public static IEnumerable<T> GetValues<T>() {
		return Enum.GetValues(typeof(T)).Cast<T>();
	}
}

