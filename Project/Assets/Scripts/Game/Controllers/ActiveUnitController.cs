using UnityEngine;
using System.Collections;

public class ActiveUnitController : MonoBehaviour, IGameTouchObserver 
{
	// ------------------------------------------------------------------------------------ //
	
	public static ActiveUnitController createNewInstance (GameObject gameObject) 
	{
		ActiveUnitController activeUnitController = gameObject.AddComponent<ActiveUnitController>();
		activeUnitController.initialize();
		return activeUnitController;
	}
	
	// ------------------------------------------------------------------------------------ //

	private UnitBase activeUnit;

	public void initialize ()
	{

	}

	// ------------------------------------------------------------------------------------ //
	
	public void onTouchBegan (GameTouchController gameTouchController, GameTouchParams gameTouchParams)
	{
		// Check active unit
		if (gameTouchParams.touchGameObject.tag.Equals(UnitBase.UNIT_TAG))
		{
			UnitBase unit = gameTouchParams.touchGameObject.GetComponent<UnitBase>();
			if (unit != null && unit.isUnitMaster()) 
			{
				if (activeUnit != null && activeUnit.Equals(unit)) 
				{
					activeUnit.setActive(false);
					activeUnit = null;
				}
				else 
				{
					setNewActiveUnit(unit);
				}

				return;
			}
		}

		// Move active unit if not return
		if (activeUnit != null) {
			((UnitMasterBase) activeUnit).moveAtPosition(gameTouchParams.touchPosition);
		}
	}

	// ------------------------------------------------------------------------------------ //

	private void setNewActiveUnit (UnitBase unit) 
	{
		if (activeUnit != null) {
			activeUnit.setActive(false);
		}

		activeUnit = unit;
		activeUnit.setActive(true);
	}

	// ------------------------------------------------------------------------------------ //

}
