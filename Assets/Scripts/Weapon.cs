using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Transform laser;
	public float shootingRate = 0.25f;
	public Vector3 offset = Vector3.zero;
	private float shootCooldown;

	// Use this for initialization
	void Start () {
		shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if(shootCooldown > 0)
			shootCooldown -= Time.deltaTime;
	}

	public void Attack(bool isEnemy)
	{
		if(CanAttack)
		{
			shootCooldown = shootingRate;
			var shotTransform = Instantiate(laser) as Transform;
			shotTransform.position = transform.position + offset;

			Shot shot = shotTransform.gameObject.GetComponent<Shot>();
			if(shot != null)
				shot.isEnemyShot = isEnemy;

			Move move = shotTransform.gameObject.GetComponent<Move>();
			if(move != null)
			{
				if(!isEnemy)	
					move.direction = new Vector3(1,0,0);
				else 
					move.direction = - new Vector3(1,0,0);
			}
		}
	}

	public void decreaseEnergy(Energy e, float nb){
		if(CanAttack)
			e.energy -= nb;
	}

	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0;
		}
	}
}
