using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

	public bool isUfo = false;
	public bool isEnergy = false;
	public bool isHeal = false;
	public bool isShield = false;
	public GameObject bonus = null;

	void OnTriggerEnter2D(Collider2D other)
	{
		PlayerController player = other.gameObject.GetComponent<PlayerController> ();
		if(player != null)
		{
			if(isUfo)
				spawnUfo(player.transform);
			else if(isHeal)
				healPlayer(other.gameObject);
			else if(isShield)
				spawnShield(player.transform);
			else if(isEnergy)
				addEnergy(other.gameObject);

			Destroy(gameObject);
		}
	}

	void spawnUfo(Transform transform){
		GameObject o = Instantiate (bonus, transform.position, transform.rotation) as GameObject;
		FollowRotation f = o.GetComponent<FollowRotation> ();
		f.target = transform;
	}

	void healPlayer(GameObject player){
		Health health = player.GetComponent<Health> ();
		health.hp += 10;
		health.UpdateHealthBar ();
	}

	void spawnShield(Transform player){
		Instantiate (bonus, player.transform.position, player.transform.rotation);
	}

	void addEnergy(GameObject player){
		Energy playerEnergy = player.GetComponent<Energy> ();
		playerEnergy.energy += 10f;
		playerEnergy.UpdateEnergyBar ();
	}
}
