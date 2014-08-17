using UnityEngine;
using System.Collections;

public class Ufo : MonoBehaviour {

	private Weapon weapon;

	// Use this for initialization
	void Start () {
		weapon = GetComponent<Weapon> ();
		Destroy (gameObject, 15f);
	}
	
	// Update is called once per frame
	void Update () {
		if(weapon != null && weapon.CanAttack)
		{
			weapon.Attack(false);
		}
	}
}
