using UnityEngine;
using System.Collections;

public class UnitPony : UnitSlaveBase 
{
	// ------------------------------------------------------------------------------------ //

	private AnimationTexture animationTexture;

	// ------------------------------------------------------------------------------------ //

	public override void initialize () 
	{ 
		// initialize model
		unitModelImage = UnitModel.createNewInstance(gameObject);

		unitModelImage.addTexture(ResourcesBase.load("Textures/Units/Pony", true) as Texture, UnitModelTextureType.Normal);
		unitModelImage.addTexture(ResourcesBase.load("Textures/Units/PonyActive", true) as Texture, UnitModelTextureType.Active);
		unitModelImage.addTexture(ResourcesBase.load("Textures/Units/PonyBehindFence", true) as Texture, UnitModelTextureType.BehindFence);

		unitModelImage.setModelTexture(UnitModelTextureType.Normal);
		unitModelImage.setModelSize(110,150);

		// initialize model animation
		animationTexture = AnimationTexture.createNewInstance(gameObject, 12, 1, 20);

		// initialize physics
		PhysicsBase.addBoxCollider(gameObject, new Vector3 (0.01f,1.0f,0.01f), Vector3.zero);
		PhysicsBase.addRigidbody(gameObject);

		// initialize state
		setUnitState(new UnitStateQuiescence());
	}

	public override float getUnitPositionY () {
		return 1.0f;
	}

	public override void updateUnit () 
	{
		updateState();

		if (animationTexture != null) {
			animationTexture.updateAnimation();
		}
	}

	// ------------------------------------------------------------------------------------ //
}
