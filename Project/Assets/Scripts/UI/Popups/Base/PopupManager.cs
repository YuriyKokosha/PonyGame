using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopupManager : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //
	
	public static PopupManager createNewInstance () 
	{
		GameObject popupManagerGO = new GameObject ("PopupManager");
		return createNewInstance (popupManagerGO);
	}
	
	public static PopupManager createNewInstance (GameObject popupManagerGO) 
	{
		PopupManager popupManager = popupManagerGO.AddComponent<PopupManager>();
		return popupManager;
	}
	
	// ------------------------------------------------------------------------------------ //

	private List<PopupBase> popups;

	private PopupManager () 
	{
		popups = new List<PopupBase>();
	}

	// ------------------------------------------------------------------------------------ //

	public void showPopup (PopupType type, PopupParamsBase popupParams)
	{
		int popupNumber = popups.Count;
		PopupBase popup = PopupFactory.createPopup(gameObject, type);

		if (popup == null) {
			SLog.logError("PopupManager showPopup: type == " + type.ToString() + ", PopupBase popup == null");
			return;
		}

		popup.initialize(type, popupNumber, popupParams);
		popups.Add(popup);
	}

	// ------------------------------------------------------------------------------------ //

	public bool isPopupShown ()
	{
		if (popups.Count != 0) {
			return true;
		}
		return false;
	}

	public bool isPopupShown (PopupType type)
	{
		if (popups.Count != 0) {
			foreach (PopupBase popup in popups) {
				if (popup.getPopupType() == type) {
					return true;
				}
			}
		}
		return false;
	}

	// ------------------------------------------------------------------------------------ //

	public PopupBase getCurrentPopup ()
	{
		int num = popups.Count;
		if (num != 0)
		{
			PopupBase popup = popups[num-1];
			return popup;
		}

		return null;
	}
	
	// ------------------------------------------------------------------------------------ //

	public void removePopup (bool removeAll)
	{
		if (removeAll) 
		{
			foreach (PopupBase popup in popups) 
			{
				popup.destroyPopup();
				Destroy(popup);
			}

			popups.Clear();
		}
		else 
		{
			int num = popups.Count;
			if (num != 0)
			{
				PopupBase popup = popups[num-1];
				popup.destroyPopup();
				Destroy(popup);

				popups.RemoveAt(num-1);
			}
		}
	}

	// ------------------------------------------------------------------------------------ //

}
