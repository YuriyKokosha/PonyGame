using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameUI : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //
	
	public static GameUI createNewInstance (GameObject gameObject) 
	{
		GameUI gameUI = gameObject.AddComponent<GameUI>();
		gameUI.initialize();
		return gameUI;
	}

	// ------------------------------------------------------------------------------------ //

	private Canvas gameCanvas;

	private Text timerText;
	private Text starsText;

	public void initialize ()
	{
		gameCanvas = CanvasBase.getSceneCanvas("GameCanvas");

		// initialize timer
		GameObject timerTextGameObject = gameCanvas.transform.FindChild("TimerText").gameObject;
		timerText = timerTextGameObject.GetComponent<Text>();

		// initialize stars
		GameObject starsTextGameObject = gameCanvas.transform.FindChild("StarText").gameObject;
		starsText = starsTextGameObject.GetComponent<Text>();
	}

	// ------------------------------------------------------------------------------------ //

	public void setTimerText (int time) 
	{
		TimePrint.TimeFormat format;
		if (time > 60*60) {
			format = TimePrint.TimeFormat.HMS;
		}
		else {
			format = TimePrint.TimeFormat.MS;
		}

		timerText.text = TimePrint.timeToText(time, format);
	}

	public void setStarsText (int stars) 
	{
		starsText.text = stars.ToString();
	}

	// ------------------------------------------------------------------------------------ //

}
