using UnityEngine;
using System.Collections;

public class AnimationTexture : MonoBehaviour 
{
	// ------------------------------------------------------------------------------------ //

	public static AnimationTexture createNewInstance (GameObject gameObject, 
	                                                  int textureTileX,
	                                                  int textureTileY,
	                                                  int fps) 
	{
		AnimationTexture animation = gameObject.AddComponent<AnimationTexture>();
		animation.initialize(textureTileX,
		                     textureTileY,
		                     fps);
		return animation;
	}

	// ------------------------------------------------------------------------------------ //

	private int uvAnimationTileX;
	private int uvAnimationTileY;
	private float framesPerSecond;

	private int index;

	private Vector2 size;
	private Vector2 offset;

	private bool startTimeDeltaSet;
	private float startTimeDelta;

	// ------------------------------------------------------------------------------------ //

	public void initialize (int textureTileX,
	                        int textureTileY,
	                        int fps)
	{
		uvAnimationTileX = textureTileX;
		uvAnimationTileY = textureTileY;
		framesPerSecond = fps;

		size = new Vector2 (1.0f / uvAnimationTileX, 1.0f / uvAnimationTileY);
		renderer.material.SetTextureScale ("_MainTex", size);
		updateAnimation();
	}

	// ------------------------------------------------------------------------------------ //

	public void updateAnimation () 
	{
		if (!startTimeDeltaSet)
		{
			startTimeDeltaSet=true;
			startTimeDelta = Time.time;
		}
		
		index = (int) ((Time.time-startTimeDelta) * framesPerSecond);
		index = index % (uvAnimationTileX * uvAnimationTileY);
			
		float uIndex = index % uvAnimationTileX;
		float vIndex = index / uvAnimationTileX;

		offset = new Vector2 (uIndex * size.x, 1.0f - size.y - vIndex * size.y);
		   
		renderer.material.SetTextureOffset ("_MainTex", offset);
	}

	// ------------------------------------------------------------------------------------ //

}