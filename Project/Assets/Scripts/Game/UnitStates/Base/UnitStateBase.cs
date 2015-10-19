using UnityEngine;
using System.Collections;

public abstract class UnitStateBase 
{
	protected UnitBase _unit = null;

	public virtual void initialize (UnitBase unit) {
		_unit = unit;
	}

	public virtual void updateState () {

	}

	public virtual void destroyState () {
		_unit = null;
	}
}
