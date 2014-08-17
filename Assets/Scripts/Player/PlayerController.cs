using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Fire[] fires;
	public bool CutScene = false;

	private Weapon[] weapons;
	private Weapon laser, multi1, multi2;

	private Energy energy;

	// Use this for initialization
	void Start () {
		fires = GetComponentsInChildren<Fire> ();
		weapons = GetComponents<Weapon> ();
		energy = gameObject.GetComponent<Energy> ();
		laser = weapons [0];
		multi1 = weapons [1];
		multi2 = weapons[2];
	}
	
	// Update is called once per frame
	void Update () {
		bool shoot = Input.GetButton	 ("Fire1");
		if(shoot)
		{
			if(laser != null)
				laser.Attack(false);
		}

		bool multiShoot = Input.GetButton ("Fire2");
		if(multiShoot)
		{
			if(multi1 != null && multi2 != null){
				if(energy.energy >= 1f){
					multi1.decreaseEnergy(energy,1f);
					multi1.Attack(false);
					multi2.Attack(false);
					energy.UpdateEnergyBar();
				}
			}
		}
	}

	void FixedUpdate()
	{
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");

		if(CutScene){
			h = 0.25f;
		}

		Vector2 movement = new Vector2 (h , v);
		if (h > 0.1)
			activeFire ();
		else 
			deactiveFire();

		rigidbody2D.velocity = movement * speed;

		rigidbody2D.position = new Vector2
		(
				Mathf.Clamp (rigidbody2D.position.x, -5.5f, 5.5f),
			 	Mathf.Clamp (rigidbody2D.position.y, -2.5f, 2.5f)
		);
	}

	private void activeFire()
	{
		foreach(Fire f in fires)
			f.activeFire();
	}
	
	private void deactiveFire()
	{
		foreach(Fire f in fires)
			f.deactiveFire();
	}

	public  Vector2 Position
	{
		get
		{
			Vector2 pos = rigidbody2D.position;
			return pos;
		}
	}


	
}
