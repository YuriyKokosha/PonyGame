using UnityEngine;
using System.IO;

public class SceneGame : SceneBase 
{
	// ------------------------------------------------------------------------------------ //

	private GameController gameController;

	// ------------------------------------------------------------------------------------ //

	void Start () 
	{
		base.initialize();

		gameController = GameController.createNewInstance(gameObject);
	}

	void Update () 
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				base.onApplicationQuitClick();
			}
		}
	}

	// ------------------------------------------------------------------------------------ //

	public GameController getGameController () {
		return gameController;
	}

	// ------------------------------------------------------------------------------------ //
}
