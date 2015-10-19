using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CanvasBase : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //

	public static Canvas getSceneCanvas (string sceneCanvasName) 
	{
		GameObject canvasGO = Instantiate (ResourcesBase.load("Prefabs/Canvas/Scenes/" + sceneCanvasName) as GameObject) as GameObject;
		canvasGO.name = sceneCanvasName;
		canvasGO.transform.localScale = Vector3.zero;

		Canvas canvas = canvasGO.GetComponent<Canvas>();
		canvas.planeDistance = 50;
		canvas.worldCamera = SceneBase.getCurrentSceneClass().getUIManager().getUICamera().getCamera();

		return canvas;
	}

	// ------------------------------------------------------------------------------------ //

}
