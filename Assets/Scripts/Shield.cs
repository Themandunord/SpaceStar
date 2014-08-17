using UnityEngine;
using System.Collections;

public class Shield : MonoBehaviour {
	private GameObject player;

	void Start(){
		Destroy (gameObject, 15f);
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update(){
		transform.position = player.transform.position;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Shot shot = other.gameObject.GetComponent<Shot>();
		if (shot != null)
		{
			if(shot.isEnemyShot)
			{
				Destroy(shot.gameObject);
			}
		}
	}
}
