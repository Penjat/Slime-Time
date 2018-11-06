using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {

	private int _x,_z;

	public Animator animator;

	public void SetUp(int x,int z){
		_x = x;
		_z = z;
	}
	public void IsLight(bool b){
		
		animator.SetBool("isLight",b);
		if(b){
			Debug.Log("x = " + _x +" z = " + _z);

		}
	}
}
