using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class UnitBase : MonoBehaviour
{
	// ------------------------------------------------------------------------------------ //

	public const string UNIT_TAG = "Unit";

	// ------------------------------------------------------------------------------------ //

	protected List<IUnitCollisionObserver> unitCollisionObservers = new List<IUnitCollisionObserver> ();

	protected UnitStateBase state;
	protected UnitModel unitModelImage;
	protected bool unitActive = false;

	// ------------------------------------------------------------------------------------ //

	public Vector3 UnitPosition {
		get { return transform.position; }
		set { transform.position = new Vector3 (value.x, getUnitPositionY(), value.z); }
	}

	// ------------------------------------------------------------------------------------ //

	void Update () {
		if (!TimeController.getPause()) {
			updateUnit();
		}
	}

	void OnTriggerEnter(Collider other) {
		notifyUnitCollisionObservers(other.gameObject);
	}

	// ------------------------------------------------------------------------------------ //

	public abstract void initialize ();
	public abstract void updateUnit ();

	public abstract bool isUnitMaster ();
	public abstract bool isUnitSlave ();

	public abstract float getUnitPositionY ();

	// ------------------------------------------------------------------------------------ //

	public bool isActive () {
		return unitActive;
	}

	public virtual void setActive (bool active) 
	{
		unitActive = active;

		if (unitModelImage != null) {
			if (active) {
				unitModelImage.setModelTexture(UnitModelTextureType.Active);
			}
			else {
				unitModelImage.setModelTexture(UnitModelTextureType.Normal);
			}
		}
	}

	public virtual void destroyUnit () {
		Destroy(gameObject);
	}

	// ------------------------------------------------------------------------------------ //

	public void setUnitState (UnitStateBase unitState) {
		if (state != null) {
			state.destroyState();
		}
		state = unitState;
		state.initialize(this);
	}

	public void updateState () {
		if (state != null) {
			state.updateState();
		}
	}

	// ------------------------------------------------------------------------------------ //
	
	public void registerObserver (IUnitCollisionObserver observer) {
		unitCollisionObservers.Add(observer);
	}
	public void removeObserver (IUnitCollisionObserver observer) {
		unitCollisionObservers.Remove(observer);
	}

	public void notifyUnitCollisionObservers (GameObject other) {
		foreach (IUnitCollisionObserver observer in unitCollisionObservers.ToArray()) {
			if (observer != null) { 
				observer.onUnitCollision(other);
			}
		}
	}

	// ------------------------------------------------------------------------------------ //
}
