using UnityEngine;
using System.Collections;

public abstract class SceneBase : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //

	private static GameObject currentSceneGameObject = null;
	private static SceneBase currentSceneClass = null;

	public static GameObject getCurrentSceneGameObject () {
		return currentSceneGameObject;
	}

	public static SceneBase getCurrentSceneClass () {
		return currentSceneClass;
	}

	// ------------------------------------------------------------------------------------ //

	private UIManager uiManager;
	private bool loadingNewScene = false;

	public virtual void initialize () 
	{
		// base initialization
		currentSceneGameObject = gameObject;
		currentSceneClass = this;
		
		// add audio listner
		gameObject.AddComponent<AudioListener>();
		
		// create UI Manager
		uiManager = UIManager.createNewInstance();
	}

	// ------------------------------------------------------------------------------------ //

	public UIManager getUIManager () {
		return uiManager;
	}

	public PopupManager getPopupManager () {
		return uiManager.getPopupManager();
	}

	public bool isLoadingNewScene () {
		return loadingNewScene;
	}

	// ------------------------------------------------------------------------------------ //
	
	public virtual void onPopupButtonReturnClick () 
	{
		uiManager.getPopupManager().removePopup(false);
	}

	public virtual void onApplicationQuitClick () 
	{
		Application.Quit();
	}

	// ------------------------------------------------------------------------------------ //

	public void reloadScene () 
	{
		loadApplicationLevel(Application.loadedLevelName);
	}

	public void loadApplicationLevel (string levelName) 
	{
		//ResourcesBase.unloadUnused();

		TimeController.setPause(false);
		TimeController.setGameTimeScale(1.0f);
		
		loadingNewScene = true;
		Application.LoadLevel(levelName);
	}

	// ------------------------------------------------------------------------------------ //
}
