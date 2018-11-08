using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

	private const string TAG = "MAIN MANAGER: ";

	private GridManager _gridManager;
	private InputManager _inputManager;
	private CardManager _cardManager;
	private PieceManager _pieceManager;

	void Start () {
		Debug.Log(TAG + "Starting up.");

		_gridManager = GetComponent<GridManager>();
		_inputManager = GetComponent<InputManager>();
		_cardManager = GetComponent<CardManager>();
		_pieceManager = GetComponent<PieceManager>();


		_gridManager.SetUp(this);
		_cardManager.SetUp(this);
		_pieceManager.SetUp(this);
		_inputManager.SetUp(this,_cardManager);

	}

	public void SqaurePressed(Square square){
		Debug.Log(TAG + "a square was pressed. "+ "x = " + square.GetX() + " z = " + square.GetZ());

		//called when a square is pressed
		//must figure out which manager will handel this

		//_pieceManager.CreatePiece(_gridManager,square);
		_cardManager.SquarePressed(square);
	}
	public void CardPressed(Card card){
		_cardManager.CardSelected(card);
	}

	public void EndTurn(){
		Debug.Log(TAG + "Ending Player's Turn.");
		_cardManager.DrawCards();
	}


}
