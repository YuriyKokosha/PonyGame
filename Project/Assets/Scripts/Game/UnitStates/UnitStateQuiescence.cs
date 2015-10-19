using UnityEngine;
using System.Collections;

public class UnitStateQuiescence : UnitStateBase, IUnitCollisionObserver
{
	// ------------------------------------------------------------------------------------ //
	
	public override void initialize (UnitBase unit) 
	{ 
		base.initialize(unit);
		unit.registerObserver((IUnitCollisionObserver) this);
	}
	
	public override void destroyState () 
	{
		_unit.removeObserver((IUnitCollisionObserver) this);
		base.destroyState();
	}

	// ------------------------------------------------------------------------------------ //
	
	public void onUnitCollision (GameObject other)
	{
		if (other.tag.Equals(UnitBase.UNIT_TAG) && _unit.isUnitSlave())
		{
			UnitBase unitOther = other.GetComponent<UnitBase>();
			if (unitOther != null && unitOther.isUnitMaster()) 
			{
				_unit.setActive(unitOther.isActive());
				_unit.setUnitState(new UnitStateFollowTheMaster((UnitMasterBase) unitOther));
			}
		}
		else if (other.tag.Equals(ItemBase.ITEM_TAG) && _unit.isUnitMaster())
		{
			ItemBase itemOther = other.GetComponent<ItemBase>();
			if (itemOther != null) {
				itemOther.onItemRecieved();
			}
		}
	}
	
	// ------------------------------------------------------------------------------------ //
}
