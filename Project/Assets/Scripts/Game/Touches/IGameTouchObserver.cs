using UnityEngine;
using System.Collections;

public interface IGameTouchObserver 
{
	void onTouchBegan (GameTouchController gameTouchController, GameTouchParams gameTouchParams);
}
