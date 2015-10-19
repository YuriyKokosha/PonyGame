using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour, IGameTimerObserver, IUnitBehindFenceObserver, IItemRecievedObserver
{
	// ------------------------------------------------------------------------------------ //

	public static GameController createNewInstance (GameObject gameObject) 
	{
		GameController gameController = gameObject.AddComponent<GameController>();
		gameController.initialize();
		return gameController;
	}

	// ------------------------------------------------------------------------------------ //

	private GameTouchController gameTouchController;
	private ActiveUnitController activeUnitController;
	private FenceController fenceController;

	private GameCamera gameCamera;
	private GameTimer gameTimer;
	private GameUI gameUI;

	private int starsCount = 0;
	private List<UnitBase> slaveUnits = new List<UnitBase> ();

	public void initialize ()
	{
		gameCamera = GameCamera.createNewInstance();
		gameCamera.setPosition(new Vector3 (0,10.0f,0));
		gameCamera.setRotation(Quaternion.Euler(90.0f,0,0));

		gameTouchController = GameTouchController.createNewInstance(gameObject);
		gameTouchController.addCamera(gameCamera.getCamera());

		gameTimer = GameTimer.createNewInstance(gameObject);
		gameTimer.registerObserver((IGameTimerObserver) this);

		gameUI = GameUI.createNewInstance(gameObject);
		gameUI.setTimerText(gameTimer.getTime());
		gameUI.setStarsText(starsCount);

		activeUnitController = ActiveUnitController.createNewInstance(gameObject);
		gameTouchController.registerObserver((IGameTouchObserver) activeUnitController);

		fenceController = FenceController.createNewInstance(gameObject);

		// create ponys
		for (int i=0; i<6; i++) 
		{
			for (int j=0; j<2; j++) 
			{
				UnitSlaveBase unitSlave = (UnitSlaveBase) UnitFactory.createNewUnit(UnitType.Pony);
				unitSlave.UnitPosition = new Vector3 ((i-2.5f)*2.0f, 0.0f, j*3.0f);
				unitSlave.registerObserver((IUnitBehindFenceObserver) this);

				slaveUnits.Add(unitSlave);
			}
		}

		// create dogs
		for (int j=0; j<3; j++) 
		{
			UnitBase unit = UnitFactory.createNewUnit(UnitType.Dog);
			unit.UnitPosition = new Vector3 ((j-1.0f)*5.0f, 0.0f, -3.0f);
		}
	}

	// ------------------------------------------------------------------------------------ //

	public void onTimeValueChanged (int time)
	{
		gameUI.setTimerText(time);
	}

	// ------------------------------------------------------------------------------------ //

	public void onUnitBehindFence (UnitBase unit) 
	{
		if (slaveUnits.Contains(unit)) {
			slaveUnits.Remove(unit);
		}

		if (slaveUnits.Count == 0) {
			onLevelCompleted();
		}

		if (fenceController.isUnitCombo(unit)) 
		{
			// create bonus
			ItemBase item = ItemFactory.createNewItem(ItemType.Bonus);
			item.ItemPosition = new Vector3 ((Random.value - 0.5f) * 10.0f, 0.0f, 1.0f);
			item.registerObserver((IItemRecievedObserver) this);
		}
	}

	// ------------------------------------------------------------------------------------ //

	public void onItemRecieved (ItemBase item) 
	{
		if (item is ItemBonus) {
			starsCount++;
			gameUI.setStarsText(starsCount);
		}
	}

	// ------------------------------------------------------------------------------------ //

	private void onLevelCompleted () 
	{
		TimeController.setPause(true);
		SceneBase.getCurrentSceneClass().getPopupManager().showPopup(PopupType.LevelCompleted, null);
	}

	// ------------------------------------------------------------------------------------ //
}
