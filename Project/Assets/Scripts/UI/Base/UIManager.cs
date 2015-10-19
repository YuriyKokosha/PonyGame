using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //
	
	public static UIManager createNewInstance () 
	{
		GameObject uiManagerGO = new GameObject ("UIManager");
		return createNewInstance (uiManagerGO);
	}

	public static UIManager createNewInstance (GameObject uiManagerGO) 
	{
		UIManager uiManager = uiManagerGO.AddComponent<UIManager>();
		uiManager.initialize();

		return uiManager;
	}

	// ------------------------------------------------------------------------------------ //

	private UICamera uiCamera;
	private PopupManager popupManager;
	private CanvasEventSystem eventSystem;

	public UIManager () 
	{

	}

	private void initialize ()
	{
		uiCamera = UICamera.createNewInstance();
		popupManager = PopupManager.createNewInstance(gameObject); 
		eventSystem = CanvasEventSystem.createNewInstance();
	}

	// ------------------------------------------------------------------------------------ //

	public UICamera getUICamera () {
		return uiCamera;
	}

	public PopupManager getPopupManager () {
		return popupManager;
	}
	
	public CanvasEventSystem getEventSystem () {
		return eventSystem;
	}

	// ------------------------------------------------------------------------------------ //

}
