using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

	private const string TAG = "MAIN MANAGER: ";

	private GridManager _gridManager;
	private InputManager _inputManager;
	private CardManager _cardManager;
	private TurnManager _turnManager;
	private CardEffectManager _cardEffectManager;
	private PieceManager _pieceManager;

	void Start () {
		Debug.Log(TAG + "Starting up.");

		_gridManager = GetComponent<GridManager>();
		_inputManager = GetComponent<InputManager>();
		_cardManager = GetComponent<CardManager>();
		_pieceManager = GetComponent<PieceManager>();
		_turnManager = new TurnManager();
		DeckManager deckManager = new DeckManager();
		_cardEffectManager = GetComponent<CardEffectManager>();


		_turnManager.SetUp(this);
		_gridManager.SetUp(this);
		_pieceManager.SetUp(this);
		_cardManager.SetUp(this,_cardEffectManager,_pieceManager,_gridManager,deckManager);
		_inputManager.SetUp(this,_cardManager,_turnManager);

	}

	public void SqaurePressed(Square square){
		Debug.Log(TAG + "a square was pressed. "+ "x = " + square.GetX() + " z = " + square.GetZ());

		//called when a square is pressed
	
		//check if the cardEffectManager is waiting for input
		if(_cardEffectManager.IsWaiting()){
			Debug.Log(TAG + "card manager is waiting for input.");
			_cardEffectManager.SquarePressed(square);
			return;
		}
		_cardManager.SquarePressed(square);
	}
	public void CardPressed(Card card){
		_cardManager.CardSelected(card);
	}

	public void EndTurn(){
		Debug.Log(TAG + "Ending Player's Turn.");
		_cardManager.DrawCards();
		StartEnemyTurn();
	}
	public void StartEnemyTurn(){
		Debug.Log(TAG + "Starting Enemy's Turn.");
		//_turnManager.SetTurn(TurnManager.Turn.ENEMY);
		EndEnemyTurn();
	}
	public void EndEnemyTurn(){
		Debug.Log(TAG + "Ending Enemy's Turn.");
		StartPlayerTurn();
	}
	public void StartPlayerTurn(){
		Debug.Log(TAG + "Starting Player's Turn.");
		//_turnManager.SetTurn(TurnManager.Turn.PLAYER);
	}


}
