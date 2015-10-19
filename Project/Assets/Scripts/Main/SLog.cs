using UnityEngine;
using System.Collections;

public class SLog 
{
	public static void log (string message) {
		Debug.Log(message);
	}

	public static void logError (string message) {
		Debug.LogError(message);
	}
}
