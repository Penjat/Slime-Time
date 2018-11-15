using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction {
	UP,
	UP_RIGHT,
	RIGHT,
	DOWN_RIGHT,
	DOWN,
	DOWN_LEFT,
	LEFT,
	UP_LEFT
};

public class GridManager : MonoBehaviour {


	MainManager _mainManager;
	private int gridWidth = 10;
	private int gridDepth = 10;

	public GameObject _squarePrefabBlack;
	public GameObject _squarePrefabWhite;
	public GameObject _gridCon;

	private Square [,] _grid;



	public void SetUp(MainManager mainManager){
		_mainManager = mainManager;

		//CreateGrid();
	}
	public void StartBattle(){
		CreateGrid();
	}

	public void CreateGrid(){
		float spacing = 1.1f;

		_grid = new Square[gridWidth,gridDepth];
		for(int z=0;z<gridDepth;z++){
			for(int x=0;x<gridWidth;x++){
				//get the correct square color
				GameObject prefab = GetSquarePrefab(x+z);
				GameObject g = Instantiate(prefab);

				Square square = g.GetComponent<Square>();
				_grid[x,z] = square;
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
	public Square GetSquare(int x,int z){
		//returns null if is of the edge, otherwise returns the square
		if(x < 0 || z < 0 || x >= _grid.GetLength(0) || z >= _grid.GetLength(1) ){
			return null;
		}
		return _grid[x,z];
	}
	public Square GetSquare(Square square,Direction direction){
		//returns the square one point in that Direction
		//TODO be able to go more than one square away
		switch(direction){
			case Direction.UP: return GetSquare(square.GetX() + 0,square.GetZ() + 1);
			case Direction.UP_RIGHT: return GetSquare(square.GetX() + 1,square.GetZ() + 1);
			case Direction.RIGHT: return GetSquare(square.GetX() + 1,square.GetZ() + 0);
			case Direction.DOWN_RIGHT: return GetSquare(square.GetX() + 1,square.GetZ() - 1);
			case Direction.DOWN: return GetSquare(square.GetX() + 0,square.GetZ() - 1);
			case Direction.DOWN_LEFT: return GetSquare(square.GetX() - 1,square.GetZ() - 1);
			case Direction.LEFT: return GetSquare(square.GetX() - 1,square.GetZ() + 0);
			case Direction.UP_LEFT: return GetSquare(square.GetX() - 1,square.GetZ() + 1);
			default: return square;
		}
	}
	public void EndBattle(){
		foreach(Square square in _grid){
			Destroy(square.gameObject);
		}

	}

}
