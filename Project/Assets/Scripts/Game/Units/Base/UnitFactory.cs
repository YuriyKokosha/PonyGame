using UnityEngine;
using System.Collections;

public class UnitFactory : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //

	public static UnitBase createNewUnit (UnitType unitType) 
	{
		GameObject unitGameObject = Instantiate (ResourcesBase.load("Prefabs/UI/Plane", true)) as GameObject;

		unitGameObject.name = "Unit" + unitType.ToString();
		unitGameObject.tag = UnitBase.UNIT_TAG;

		UnitBase unitBase = null;

		if (unitType == UnitType.Dog) {
			unitBase = unitGameObject.AddComponent<UnitDog>();
		}
		else if (unitType == UnitType.Pony) {
			unitBase = unitGameObject.AddComponent<UnitPony>();
		}
		else {
			SLog.logError("UnitFactory createNewUnit(): unknown type == " + unitType.ToString());
			return null;
		}

		unitBase.initialize();

		return unitBase;
	}

	// ------------------------------------------------------------------------------------ //
}
