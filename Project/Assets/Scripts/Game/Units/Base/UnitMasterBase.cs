using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class UnitMasterBase : UnitBase 
{
	// ------------------------------------------------------------------------------------ //

	protected List<IUnitMasterObserver> unitMasterObservers = new List<IUnitMasterObserver> ();

	// ------------------------------------------------------------------------------------ //

	public sealed override bool isUnitMaster () {
		return true;
	}
	
	public sealed override bool isUnitSlave () {
		return false;
	}

	public override void setActive (bool active) 
	{
		base.setActive(active);

		foreach (IUnitMasterObserver observer in unitMasterObservers.ToArray()) {
			if (observer != null) { 
				observer.onMasterActive(active);
			}
		}
	}

	// ------------------------------------------------------------------------------------ //
	
	public virtual void moveAtPosition (Vector3 position)
	{
		Vector3 positionEnd = new Vector3 (position.x, getUnitPositionY(), position.z);
		setUnitState(new UnitStateMove(this, positionEnd));
	}

	// ------------------------------------------------------------------------------------ //
	
	public void registerObserver (IUnitMasterObserver observer) {
		unitMasterObservers.Add(observer);
	}
	public void removeObserver (IUnitMasterObserver observer) {
		unitMasterObservers.Remove(observer);
	}
	
	public void notifyMasterMoveObservers () {
		foreach (IUnitMasterObserver observer in unitMasterObservers.ToArray()) {
			if (observer != null) { 
				observer.onMasterMove(UnitPosition);
			}
		}
	}

	// ------------------------------------------------------------------------------------ //
}
