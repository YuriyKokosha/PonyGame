using UnityEngine;
using System.Collections;

public interface IUnitMasterObserver 
{
	void onMasterMove (Vector3 masterPosition);
	void onMasterActive (bool active);
}
