using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitModel : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //
	
	public static UnitModel createNewInstance (GameObject gameObject) 
	{
		UnitModel unitModelImage = gameObject.AddComponent<UnitModel>();
		unitModelImage.initialize();
		return unitModelImage;
	}

	// ------------------------------------------------------------------------------------ //

	private Dictionary<UnitModelTextureType, Texture> images = new Dictionary<UnitModelTextureType, Texture> ();

	public void initialize ()
	{

	}

	// ------------------------------------------------------------------------------------ //

	public void addTexture (Texture texture, UnitModelTextureType type) 
	{
		images.Add(type, texture);
	}

	public void setModelTexture (UnitModelTextureType type) 
	{
		Texture texture = null;
		if (images.TryGetValue(type, out texture)) {
			renderer.material.mainTexture = texture;
		}
		else {
			SLog.log("UnitModelImage.setModelTexture(): unknown type == " + type.ToString());
		}
	}

	public void setModelSize (int x, int y) 
	{
		gameObject.transform.localScale = new Vector3 (x, 1.0f, y);
	}

	// ------------------------------------------------------------------------------------ //

}
