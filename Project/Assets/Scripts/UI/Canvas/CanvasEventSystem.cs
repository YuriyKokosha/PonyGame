using UnityEngine;
using System.Collections;

public class CanvasEventSystem : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //

	public static CanvasEventSystem createNewInstance () 
	{
		GameObject gameobject = Instantiate (ResourcesBase.load("Prefabs/Canvas/EventSystem")) as GameObject;
		gameobject.name = "EventSystem";

		CanvasEventSystem canvasEventSystem = gameobject.AddComponent<CanvasEventSystem>();
		canvasEventSystem.initialize();
		
		return canvasEventSystem;
	}
	
	// ------------------------------------------------------------------------------------ //

	public void initialize ()
	{

	}

	// ------------------------------------------------------------------------------------ //
}
