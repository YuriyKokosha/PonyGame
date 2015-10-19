using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTouchController : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //
	
	public static GameTouchController createNewInstance (GameObject gameObject) 
	{
		GameTouchController gameTouchController = gameObject.AddComponent<GameTouchController>();
		gameTouchController.initialize();
		return gameTouchController;
	}

	// ------------------------------------------------------------------------------------ //

	private List<IGameTouchObserver> gameTouchObservers = new List<IGameTouchObserver> ();
	private List<Camera> cameras = new List<Camera>();

	private Ray ray;
	private RaycastHit hit;

	public void initialize ()
	{

	}

	// ------------------------------------------------------------------------------------ //

	public void addCamera (Camera camera) {
		cameras.Add(camera);
	}

	public void removeCamera (Camera camera) {
		cameras.Remove(camera);
	}
	
	// ------------------------------------------------------------------------------------ //
	
	public void registerObserver (IGameTouchObserver observer) {
		gameTouchObservers.Add(observer);
	}
	public void removeObserver (IGameTouchObserver observer) {
		gameTouchObservers.Remove(observer);
	}
	
	public void notifyGameTouchObservers (GameTouchParams gameTouchParams) {
		foreach (IGameTouchObserver observer in gameTouchObservers.ToArray()) {
			if (observer != null) { 
				observer.onTouchBegan(this, gameTouchParams);
			}
		}
	}

	// ------------------------------------------------------------------------------------ //
	
	void Update () 
	{
		if (!TimeController.getPause())
		{
			if (Input.GetMouseButtonDown (0))
			{
				foreach (Camera camera in cameras)
				{
					ray = camera.ScreenPointToRay(Input.mousePosition);
					if (Physics.Raycast(ray, out hit, 1000)) 
					{
						GameTouchParams gameTouchParams = new GameTouchParams (hit.collider.gameObject, hit.point);
						notifyGameTouchObservers(gameTouchParams);
					}
				}
			}
		}
	}

	// ------------------------------------------------------------------------------------ //

}
