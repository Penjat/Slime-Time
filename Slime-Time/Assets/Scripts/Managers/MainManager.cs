using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

	private const string TAG = "MAIN MANAGER: ";

	private GridManager gridManager;

	void Start () {
		Debug.Log(TAG + "Starting up.");

		gridManager = GetComponent<GridManager>();

		
		gridManager.SetUp(this);

	}


}
