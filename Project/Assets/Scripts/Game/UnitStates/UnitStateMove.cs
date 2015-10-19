using UnityEngine;
using System.Collections;

public class UnitStateMove : UnitStateBase, IUnitCollisionObserver
{
	// ------------------------------------------------------------------------------------ //

	private UnitMasterBase _unitMaster;

	private Vector3 _positionStart;
	private Vector3 _positionEnd;

	private float speed = 2.0f;
	private float moveDistance;
	private float moveTime;

	private float life;

	public UnitStateMove (UnitMasterBase unitMaster, Vector3 positionEnd)
	{
		_unitMaster = unitMaster;
		_positionEnd = positionEnd;
	}
	
	// ------------------------------------------------------------------------------------ //
	
	public override void initialize (UnitBase unit) 
	{ 
		_positionStart = _unitMaster.UnitPosition;

		moveDistance = Vector3.Distance(_positionStart, _positionEnd);
		moveTime = moveDistance / speed;

		_unitMaster.registerObserver((IUnitCollisionObserver) this);
	}
	
	public override void destroyState () 
	{
		_unitMaster.removeObserver((IUnitCollisionObserver) this);
		_unitMaster = null;

		base.destroyState();
	}
	
	public override void updateState () 
	{
		life += Time.deltaTime / moveTime;

		if (life < 1.0f) {
			setUnitPosition(calculatePoint(life, _positionStart, _positionEnd));
		}
		else {
			setUnitPosition(_positionEnd);
			_unitMaster.setUnitState(new UnitStateQuiescence ());
		}
	}

	// ------------------------------------------------------------------------------------ //

	public void onUnitCollision (GameObject other)
	{
		if (other.tag.Equals(ItemBase.ITEM_TAG))
		{
			ItemBase itemOther = other.GetComponent<ItemBase>();
			if (itemOther != null) {
				itemOther.onItemRecieved();
			}
		}
	}

	// ------------------------------------------------------------------------------------ //

	private void setUnitPosition (Vector3 position)
	{
		_unitMaster.UnitPosition = position;
		_unitMaster.notifyMasterMoveObservers();
	}

	private Vector3 calculatePoint(float t, Vector3 p0, Vector3 p1)
	{
		//float u = 1 – t;
		float u;
		u=1-t;
		
		Vector3 p = u * p0;    //first term
		p += t * p1;    //second term
		
		return p;
	}

	// ------------------------------------------------------------------------------------ //
}
