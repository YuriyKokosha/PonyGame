using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public abstract class PopupBase : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //

	public const float POPUP_FIRST_POSITION = 25.0f;
	public const float POPUP_NEXT_POSITION = 2.5f;

	// ------------------------------------------------------------------------------------ //

	public GameObject popupCanvasGO;

	public int _popupNumber = 0;
	public PopupType _type;
	public string _name; 

	// ------------------------------------------------------------------------------------ //

	public PopupType getPopupType () {
		return _type;
	}

	// ------------------------------------------------------------------------------------ //

	public virtual void initialize (PopupType type, int popupNumber, PopupParamsBase popupParams) 
	{
		_type = type;
		_name = "Popup" + type.ToString();
		_popupNumber = popupNumber;

		popupCanvasGO = Instantiate (ResourcesBase.load(getCanvasPrefabPath()) as GameObject) as GameObject;
		popupCanvasGO.name = _name;
		popupCanvasGO.transform.localScale = Vector3.zero;
		
		Canvas popupCanvas = popupCanvasGO.GetComponent<Canvas>();
		popupCanvas.planeDistance = POPUP_FIRST_POSITION - popupNumber * POPUP_NEXT_POSITION;
		popupCanvas.sortingOrder = (popupNumber + 10);
		popupCanvas.worldCamera = SceneBase.getCurrentSceneClass().getUIManager().getUICamera().getCamera();
	}

	public virtual void destroyPopup () 
	{
		if (popupCanvasGO != null) {
			Destroy(popupCanvasGO);
			popupCanvasGO = null;
		}
	}

	// ------------------------------------------------------------------------------------ //
	
	public void addDelegateToButton (string buttonName, UnityEngine.Events.UnityAction call) 
	{
		GameObject buttonGO = popupCanvasGO.transform.FindChild(buttonName).gameObject;
		Button button = buttonGO.GetComponent<Button>();
		button.onClick.AddListener(call);
	}
	
	public void setCanvasText (string canvasTextName, string text) 
	{
		GameObject canvasTextGO = popupCanvasGO.transform.FindChild(canvasTextName).gameObject;
		Text canvasText = canvasTextGO.GetComponent<Text>();
		canvasText.text = text;
	}

	// ------------------------------------------------------------------------------------ //

	public string getCanvasPrefabPath () {
		if (_name != null) {
			return "Prefabs/Canvas/Popups/" + _name + "Canvas";
		}
		return null;
	}
	
	// ------------------------------------------------------------------------------------ //
}
