using UnityEngine;
using System.Collections;

public struct GameTouchParams 
{
	public GameObject touchGameObject { get; private set; }
	public Vector3 touchPosition { get; private set; }

	public GameTouchParams (GameObject gameObject, Vector3 position) 
	{
		touchGameObject = gameObject;
		touchPosition = position;
	}
}
