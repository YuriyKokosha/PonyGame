using UnityEngine;
using System.Collections;

public interface IUnitCollisionObserver 
{
	void onUnitCollision (GameObject other);
}
