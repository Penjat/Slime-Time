using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {


	MainManager _mainManager;
	public GameObject _squarePrefabBlack;
	public GameObject _squarePrefabWhite;
	public GameObject _gridCon;


	public void SetUp(MainManager mainManager){
		_mainManager = mainManager;

		CreateGrid();
	}

	public void CreateGrid(){
		float spacing = 1.1f;


		for(int z=0;z<10;z++){
			for(int x=0;x<10;x++){
				//get the correct square color
				GameObject prefab = GetSquarePrefab(x+z);
				GameObject g = Instantiate(prefab);

				Square square = g.GetComponent<Square>();
				square.SetUp(x,z);
				g.transform.SetParent(_gridCon.transform);
				g.transform.localPosition = new Vector3(x*spacing,0,z*spacing);
			}
		}
	}
	public GameObject GetSquarePrefab(int i){
		//returns the correct square color depending where on the grid it is
		if(!Calc.IsEven(i)){
			return _squarePrefabBlack;
		}
		return _squarePrefabWhite;
	}
}
