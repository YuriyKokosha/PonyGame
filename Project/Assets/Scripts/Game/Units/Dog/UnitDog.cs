using UnityEngine;
using System.Collections;

public class UnitDog : UnitMasterBase 
{
	// ------------------------------------------------------------------------------------ //

	public override void initialize () 
	{ 
		// initialize model
		unitModelImage = UnitModel.createNewInstance(gameObject);
		
		unitModelImage.addTexture(ResourcesBase.load("Textures/Units/Dog", true) as Texture, UnitModelTextureType.Normal);
		unitModelImage.addTexture(ResourcesBase.load("Textures/Units/DogActive", true) as Texture, UnitModelTextureType.Active);
		
		unitModelImage.setModelTexture(UnitModelTextureType.Normal);
		unitModelImage.setModelSize(150,150);

		// initialize physics
		PhysicsBase.addBoxCollider(gameObject, new Vector3 (0.01f,1.0f,0.01f), Vector3.zero);
		PhysicsBase.addRigidbody(gameObject);

		// initialize state
		setUnitState(new UnitStateQuiescence());
	}

	public override float getUnitPositionY () {
		return 2.0f;
	}

	public override void updateUnit () 
	{
		updateState();
	}

	// ------------------------------------------------------------------------------------ //
}
