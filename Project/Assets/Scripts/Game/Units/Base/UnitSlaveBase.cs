using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class UnitSlaveBase : UnitBase 
{
	// ------------------------------------------------------------------------------------ //

	protected List<IUnitBehindFenceObserver> unitBehindFenceObservers = new List<IUnitBehindFenceObserver> ();

	// ------------------------------------------------------------------------------------ //

	public sealed override bool isUnitMaster () {
		return false;
	}
	
	public sealed override bool isUnitSlave () {
		return true;
	}
	
	// ------------------------------------------------------------------------------------ //

	public virtual void setBehindFence () {
		unitModelImage.setModelTexture(UnitModelTextureType.BehindFence);
	}

	// ------------------------------------------------------------------------------------ //
	
	public void registerObserver (IUnitBehindFenceObserver observer) {
		unitBehindFenceObservers.Add(observer);
	}
	public void removeObserver (IUnitBehindFenceObserver observer) {
		unitBehindFenceObservers.Remove(observer);
	}
	
	public void notifyUnitBehindFenceObservers () {
		foreach (IUnitBehindFenceObserver observer in unitBehindFenceObservers.ToArray()) {
			if (observer != null) { 
				observer.onUnitBehindFence(this);
			}
		}
	}

	// ------------------------------------------------------------------------------------ //

}
