using UnityEngine;
using System.Collections;

public class PhysicsBase 
{
	// ------------------------------------------------------------------------------------ //
	
	public static BoxCollider addBoxCollider (GameObject gameObject, Vector3 size, Vector3 center) {
		BoxCollider boxCollider = gameObject.AddComponent<BoxCollider>();
		boxCollider.isTrigger = true;
		boxCollider.size = size;
		boxCollider.center = center;
		return boxCollider;
	}
	
	public static CapsuleCollider addCapsuleCollider (GameObject gameObject, float radius, float height, Vector3 center) {
		CapsuleCollider capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
		capsuleCollider.isTrigger = true;
		capsuleCollider.radius = radius;
		capsuleCollider.height = height;
		capsuleCollider.center = center;
		return capsuleCollider;
	}
	
	public static Rigidbody addRigidbody (GameObject gameObject) {
		Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
		rigidbody.isKinematic = true;
		rigidbody.useGravity = false;
		return rigidbody;
	}

	// ------------------------------------------------------------------------------------ //
}
