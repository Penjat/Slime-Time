using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour {

	private const string TAG = "MAIN MANAGER: ";

	private BattleManager _battleManager;
	private MenuManager _menuManager;
	private DeckManager _deckManager;
	private InputManager _inputManager;


	void Start () {
		Debug.Log(TAG + "Starting up.");

		_battleManager = GetComponentInChildren<BattleManager>();
		_menuManager = GetComponent<MenuManager>();
		_inputManager = GetComponent<InputManager>();
		_deckManager = new DeckManager();



		_battleManager.SetUp(this,_deckManager);
		_inputManager.SetUp(this,_battleManager);
		_menuManager.SetUp(this);

		ToTitle();
	}

	public void ToTitle(){
		_menuManager.NavigateMenu(Menu.TITLE);
	}
	public void StartGame(){
		//TODO Load game data
		ToWorldMap();
	}
	public void RedyForBattle(){
		_menuManager.NavigateMenu(Menu.PRE_BATTLE);
	}
	public void StartBattle(){
		_menuManager.NavigateMenu(Menu.BATTLE);
		//TODO pass in info about the battle
		_battleManager.StartBattle();

	}
	public void ToWorldMap(){
		_menuManager.NavigateMenu(Menu.WORLD_MAP);
	}
	public void RepacpBattle(){
		//shows win lose data, stats about how the battle went and what was won
		//TODO win or lose
		_menuManager.NavigateMenu( (Menu)((int)Menu.BATTLE + (int)Menu.BATTLE_OVER));
	}
	public void LeaveBattle(){
		//clears all the battle elements: cards,grid
		//called from the battle over menu
		_battleManager.LeaveBattle();


		ToWorldMap();
	}







}
