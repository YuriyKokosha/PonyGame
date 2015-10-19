using UnityEngine;
using System.Collections;

public class UnitStateFollowTheMaster : UnitStateBase, IUnitCollisionObserver, IUnitMasterObserver
{
	// ------------------------------------------------------------------------------------ //

	private UnitMasterBase _unitMaster;
	private Vector3 deltaPosition;

	public UnitStateFollowTheMaster (UnitMasterBase unitMaster)
	{
		_unitMaster = unitMaster;
	}

	// ------------------------------------------------------------------------------------ //
	
	public override void initialize (UnitBase unit) 
	{ 
		base.initialize(unit);

		_unit.registerObserver((IUnitCollisionObserver) this);
		_unitMaster.registerObserver((IUnitMasterObserver) this);

		deltaPosition = _unitMaster.UnitPosition - _unit.UnitPosition;
	}
	
	public override void destroyState () 
	{
		_unit.removeObserver((IUnitCollisionObserver) this);
		_unitMaster.removeObserver((IUnitMasterObserver) this);
		_unitMaster = null;

		base.destroyState();
	}

	// ------------------------------------------------------------------------------------ //

	public void onMasterMove (Vector3 masterPosition) 
	{
		_unit.UnitPosition = masterPosition - deltaPosition;
	}

	public void onMasterActive (bool active) 
	{
		_unit.setActive(active);
	}

	// ------------------------------------------------------------------------------------ //
	
	public void onUnitCollision (GameObject other)
	{
		if (other.tag.Equals("Fence") && _unit.isUnitSlave())
		{
			UnitSlaveBase unitSlave = ((UnitSlaveBase) _unit);
			unitSlave.notifyUnitBehindFenceObservers();
			unitSlave.setBehindFence();
			unitSlave.setUnitState(new UnitStateBehindFence());
		}
	}

	// ------------------------------------------------------------------------------------ //
}
