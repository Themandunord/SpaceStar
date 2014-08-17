using UnityEngine;
using System.Collections;

public class CutScene : MonoBehaviour {

	public Vector2 speed = new Vector2 (2f, 2f);
	public bool isPlanet = false;

	// Use this for initialization
	void Start () {
	
		if(isPlanet)
			StartCoroutine("movePlanet");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 movement = Vector2.zero;

		if(isPlanet){
			movement = new Vector2(speed.x * -1 , speed.y * 0);
		}

		rigidbody2D.velocity = movement;

	}

	IEnumerator movePlanet()
	{
		yield return new WaitForSeconds(5f);
		isPlanet = false;
	}
}
