using UnityEngine;
using System.Collections;

public class ItemFactory : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //
	
	public static ItemBase createNewItem (ItemType itemType) 
	{
		GameObject itemGameObject = Instantiate (ResourcesBase.load("Prefabs/UI/Plane", true)) as GameObject;
		
		itemGameObject.name = "Item" + itemType.ToString();
		itemGameObject.tag = ItemBase.ITEM_TAG;
		
		ItemBase itemBase = null;
		
		if (itemType == ItemType.Bonus) {
			itemBase = itemGameObject.AddComponent<ItemBonus>();
		}
		else {
			SLog.logError("ItemFactory createNewItem(): unknown type == " + itemType.ToString());
		}
		
		if (itemBase != null) {
			itemBase.initialize();
		}
		
		return itemBase;
	}
	
	// ------------------------------------------------------------------------------------ //
}
