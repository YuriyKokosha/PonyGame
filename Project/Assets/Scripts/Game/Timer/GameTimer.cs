using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameTimer : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //

	public static GameTimer createNewInstance (GameObject gameObject) 
	{
		GameTimer gameTimer = gameObject.AddComponent<GameTimer>();
		gameTimer.initialize();
		return gameTimer;
	}

	// ------------------------------------------------------------------------------------ //

	private List<IGameTimerObserver> gameTimerObservers = new List<IGameTimerObserver> ();

	private float life;
	private int gameTime = 0;

	public void initialize ()
	{
		life = gameTime;
	}

	// ------------------------------------------------------------------------------------ //

	public int getTime () {
		return gameTime;
	}

	// ------------------------------------------------------------------------------------ //
	
	void Update ()
	{
		if (!TimeController.getPause())
		{
			life += Time.deltaTime;

			// check game time 
			if (gameTime != (int) life)
			{
				gameTime = (int) life;
				
				foreach (IGameTimerObserver observer in gameTimerObservers.ToArray()) {
					observer.onTimeValueChanged(gameTime);
				}
			}
		}
	}

	// ------------------------------------------------------------------------------------ //
	
	public void registerObserver (IGameTimerObserver observer) {
		gameTimerObservers.Add(observer);
	}
	public void removeObserver (IGameTimerObserver observer) {
		gameTimerObservers.Remove(observer);
	}

	// ------------------------------------------------------------------------------------ //
}
