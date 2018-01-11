using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoints : MonoBehaviour {

	/// <summary>
	/// Gives the player points.
	/// </summary>
	public void givePlayerPoints(){
		GameObject.FindGameObjectWithTag ("Points").GetComponent<Points>().addPoints();
	}
}
