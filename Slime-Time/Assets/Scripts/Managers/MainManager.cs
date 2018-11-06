using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

	private const string TAG = "MAIN MANAGER: ";

	private GridManager _gridManager;
	private InputManager _inputManager;

	void Start () {
		Debug.Log(TAG + "Starting up.");

		_gridManager = GetComponent<GridManager>();
		_inputManager = GetComponent<InputManager>();


		_gridManager.SetUp(this);
		_inputManager.SetUp(this);

	}


}
