using UnityEngine;
using System.Collections;

public class UICamera : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //

	public static UICamera createNewInstance () 
	{
		GameObject uiCameraGO = Instantiate (ResourcesBase.load(getUICameraPrefabName()) as GameObject, 
		                                     getUICameraBasePosition(), 
		                                     getUICameraRotation()) as GameObject;

		UICamera uiCamera = uiCameraGO.AddComponent<UICamera>();
		uiCamera.initialize();

		return uiCamera;
	}

	// ------------------------------------------------------------------------------------ //
	
	private static string getUICameraPrefabName () {
		return "Prefabs/Camera/UICamera";
	}
	
	private static Quaternion getUICameraRotation () {
		return Quaternion.Euler(0, 0, 0);
	}
	
	private static Vector3 getUICameraBasePosition () {
		return new Vector3 (10.0f,10.0f,0.0f);
	}

	// ------------------------------------------------------------------------------------ //

	public UICamera ()
	{

	}

	public void initialize ()
	{
		name = "UICamera";
	}

	// ------------------------------------------------------------------------------------ //

	public Camera getCamera () {
		return gameObject.camera;
	}

	// ------------------------------------------------------------------------------------ //

}
