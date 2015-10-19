using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //
	
	private static bool pause = false;
	
	public static bool getPause () {
		return pause;
	}
	
	public static void setPause (bool value) {
		if (value) {
			Time.timeScale = 0.0f;
		}
		else {
			Time.timeScale = gameTimeScale;
		}
		
		pause = value;
	}

	// ------------------------------------------------------------------------------------ //

	private static float gameTimeScale = 1.0f;

	public static void setGameTimeScale (float value) {
		gameTimeScale = value;
		Time.timeScale = gameTimeScale;
	}

	// ------------------------------------------------------------------------------------ //

}
