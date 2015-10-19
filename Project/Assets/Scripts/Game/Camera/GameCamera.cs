using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //
	
	public static GameCamera createNewInstance () 
	{
		GameObject gameCameraGameObject = Instantiate (ResourcesBase.load("Prefabs/Camera/GameCamera")) as GameObject;
		GameCamera gameCamera = gameCameraGameObject.AddComponent<GameCamera>();
		gameCamera.initialize();
		return gameCamera;
	}

	// ------------------------------------------------------------------------------------ //

	public void initialize () {
		name = "GameCamera";
	}
	
	// ------------------------------------------------------------------------------------ //

	public void setPosition (Vector3 position) {
		transform.position = position;
	}

	public void setRotation (Quaternion rotation) {
		transform.rotation = rotation;
	}

	public Camera getCamera () {
		return gameObject.camera;
	}
	
	// ------------------------------------------------------------------------------------ //
}
