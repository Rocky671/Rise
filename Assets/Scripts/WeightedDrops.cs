using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedDrops : MonoBehaviour {

	public WeaponDrops[] drops;

	/// <summary>
	/// Drops the weapon.
	/// </summary>
	public void dropWeapon(){
		float[] CDFArray = new float[drops.Length];
		CDFArray [0] = drops [0].weight;

		// loops to drop an item
		for (int i = 1; i < drops.Length; i++) {
			CDFArray [i] = CDFArray [i - 1] + drops[i].weight;
		}

		// choose a random item from the range of the list
		float randomValue = Random.Range (0.0f, CDFArray [CDFArray.Length - 1]);

		// chooses a random item 
		int itemDrop = System.Array.BinarySearch (CDFArray, randomValue);
		if (itemDrop < 0) {
			itemDrop = ~itemDrop;
		}

		// creates the item drop
		Instantiate (drops [itemDrop].drop, transform.position, Quaternion.identity);
	}
}

[System.Serializable]
public class WeaponDrops {
	public GameObject drop;
	public float weight;
}