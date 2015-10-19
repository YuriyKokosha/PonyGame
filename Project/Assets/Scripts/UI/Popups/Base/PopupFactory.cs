using UnityEngine;
using System.Collections;

public class PopupFactory : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //

	public static PopupBase createPopup (GameObject popupGameObject, 
	                                     PopupType popupType) 
	{
		if (popupType == PopupType.LevelCompleted) {
			return popupGameObject.AddComponent<PopupLevelCompleted>();
		}

		SLog.logError("PopupFactory createPopup(): unknown type == " + popupType.ToString());
		return null;
	}

	// ------------------------------------------------------------------------------------ //
}
