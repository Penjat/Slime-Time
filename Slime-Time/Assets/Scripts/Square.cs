using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {

	private int _x,_z;

	private Slime _slime;
	

	public Animator animator;

	public void SetUp(int x,int z){
		_x = x;
		_z = z;
	}
	public void IsLight(bool b){

		animator.SetBool("isLight",b);

	}

	public int GetX(){
		return _x;
	}
	public int GetZ(){
		return _z;
	}

	public bool HasSlime(){
		return (_slime != null);
	}
	public void SetSlime(Slime slime){
		_slime = slime;
	}
	public Slime GetSlime(){
		return _slime;
	}
}
