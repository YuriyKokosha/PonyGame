using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ItemBase : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //
	
	public const string ITEM_TAG = "Item";

	// ------------------------------------------------------------------------------------ //

	protected List<IItemRecievedObserver> itemRecievedObservers = new List<IItemRecievedObserver> ();

	// ------------------------------------------------------------------------------------ //
	
	public abstract void initialize ();
	public abstract void updateItem ();



	public abstract float getUnitPositionY ();

	// ------------------------------------------------------------------------------------ //

	public Vector3 ItemPosition {
		get { return transform.position; }
		set { transform.position = new Vector3 (value.x, getUnitPositionY(), value.z); }
	}

	// ------------------------------------------------------------------------------------ //
	
	void Update () {
		if (!TimeController.getPause()) {
			updateItem();
		}
	}

	// ------------------------------------------------------------------------------------ //

	public virtual void onItemRecieved () {
		notifyItemRecievedObservers();
		destroyItem();
	}

	public virtual void destroyItem () {
		Destroy(gameObject);
	}

	// ------------------------------------------------------------------------------------ //
	
	public void registerObserver (IItemRecievedObserver observer) {
		itemRecievedObservers.Add(observer);
	}
	public void removeObserver (IItemRecievedObserver observer) {
		itemRecievedObservers.Remove(observer);
	}
	
	public void notifyItemRecievedObservers () {
		foreach (IItemRecievedObserver observer in itemRecievedObservers.ToArray()) {
			if (observer != null) { 
				observer.onItemRecieved(this);
			}
		}
	}

	// ------------------------------------------------------------------------------------ //

}
