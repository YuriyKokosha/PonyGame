using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FenceController : MonoBehaviour
{

	// ------------------------------------------------------------------------------------ //
	
	public static FenceController createNewInstance (GameObject gameObject) 
	{
		FenceController fenceController = gameObject.AddComponent<FenceController>();
		fenceController.initialize();
		return fenceController;
	}

	// ------------------------------------------------------------------------------------ //

	public const float comboTime = 1.0f;
	public const int comboUnitCount = 5;

	private List<float> times = new List<float>();

	public void initialize ()
	{

	}

	// ------------------------------------------------------------------------------------ //

	public bool isUnitCombo (UnitBase unit) 
	{
		times.Add(Time.time);
		return isCombo();
	}

	// ------------------------------------------------------------------------------------ //

	private bool isCombo ()
	{
		int count = times.Count;
		if (count >= comboUnitCount)
		{
			if ((times[count-1] - times[0]) < comboTime) 
			{
				times.Clear();
				return true;
			}
			else {
				// no combo, remove firs't time
				times.RemoveAt(0);
			}
		}

		return false;
	}

	// ------------------------------------------------------------------------------------ //

}
