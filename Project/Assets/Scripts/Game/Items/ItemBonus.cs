using UnityEngine;
using System.Collections;

public class ItemBonus : ItemBase 
{
	// ------------------------------------------------------------------------------------ //

	private AnimationTexture animationTexture;
	private float life = 10.0f;

	// ------------------------------------------------------------------------------------ //

	public override void initialize () 
	{ 
		// initialize model
		renderer.material.mainTexture = ResourcesBase.load("Textures/Items/Star", true) as Texture;
		gameObject.transform.localScale = new Vector3 (128, 1.0f, 128);

		// initialize model animation
		animationTexture = AnimationTexture.createNewInstance(gameObject, 6, 6, 20);

		// initialize physics
		PhysicsBase.addBoxCollider(gameObject, new Vector3 (0.01f,1.0f,0.01f), Vector3.zero);
		PhysicsBase.addRigidbody(gameObject);		
	}

	public override float getUnitPositionY () {
		return 1.0f;
	}

	public override void updateItem () 
	{
		life -= Time.deltaTime;
		if (life > 0) {
			if (animationTexture != null) {
				animationTexture.updateAnimation();
			}
		}
		else {
			base.destroyItem();
		}
	}

	// ------------------------------------------------------------------------------------ //

}
