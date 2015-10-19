using UnityEngine;
using System.Collections;

public interface IItemRecievedObserver  
{
	void onItemRecieved (ItemBase item);
}
