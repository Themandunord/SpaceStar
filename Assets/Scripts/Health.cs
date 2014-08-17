using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Health : MonoBehaviour {

	public int hp = 1;
	private int maxHP = 0;
	public bool isEnemy = true;
	public bool isMeteor = false;
	public Dictionary<Shot,Vector2> shots;
	private Enemy enemy;
	private PlayerController playerController;

	// HealthBar for player;
	private SpriteRenderer healthBar;
	private Vector3 healthScale;

	void Start()
	{
		maxHP = hp;
		enemy = GetComponent<Enemy> ();
		playerController = GetComponent<PlayerController> ();
		shots = new Dictionary<Shot,Vector2>();

		if(playerController != null)
		{
			healthBar = GameObject.Find("HealthBar").GetComponent<SpriteRenderer>();
			healthScale = healthBar.transform.localScale;
			UpdateHealthBar ();
		}
	}

	public void Damage(int damageCount)
	{
		hp -= damageCount;
		if(playerController != null)
			UpdateHealthBar();
		
		if (hp <= 0)
		{	// Dead!
			if(isEnemy)
			{
				enemy.move.speed.x = 0.2f;
				enemy.box.enabled = false;
				enemy.isDead = true;
				Score.score +=100;

				Energy e = GameObject.FindGameObjectWithTag("Player").GetComponent<Energy>() as Energy;
				e.energy += 2f;
				e.UpdateEnergyBar();
				Health h = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>() as Health;
				h.hp += 2;
				e.UpdateEnergyBar();
			}
			else if(isMeteor)
			{
				Score.score += 50;
			}
			else{
				// Player Dead
				Score.score = 0;
				Application.LoadLevel(Application.loadedLevel);
			}
			Destroy(gameObject,1f);
		}
	}

	void FixedUpdate()
	{
		foreach(KeyValuePair<Shot,Vector2> s in shots)
		{
			if(!isEnemy && !isMeteor)
				s.Key.setPosition(playerController.Position + s.Value);
			else if(isMeteor)
			{
				Vector2 pos = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y);
				s.Key.setPosition(pos + s.Value);
			}
			else
			{
				Vector2 pos = new Vector2(enemy.transform.position.x, enemy.transform.position.y);
				s.Key.setPosition(pos + s.Value);
			}
		}

		if(hp >= maxHP)
			hp = maxHP;
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		Shot shot = otherCollider.gameObject.GetComponent<Shot>();

		if (shot != null)
		{
			// If is meteor
			if(isMeteor && !shot.isEnemyShot)
			{
				if(!shots.ContainsKey(shot))
				{	
					Damage(shot.damage);
					if(shot.anim != null)
						shot.anim.SetBool("Hit",true);
					Vector2 shotPos = shot.rigidbody2D.position;
					Vector2 offset;
					offset = new Vector2(shotPos.x - this.gameObject.transform.position.x, shotPos.y - this.gameObject.transform.position.y);;
					shots.Add(shot,offset);
					Destroy (shot.gameObject,1f);
				}
			}

			// .. if not
			else if (shot.isEnemyShot != isEnemy && !isMeteor)
			{
				if(!shots.ContainsKey(shot))
				{	
					Damage(shot.damage);
					if(shot.anim != null)
						shot.anim.SetBool("Hit",true);
					Vector2 shotPos = shot.rigidbody2D.position;
					Vector2 offset;
					if(!isEnemy)
						offset = shotPos - playerController.Position;
					else
						offset = new Vector2(shotPos.x - enemy.transform.position.x, shotPos.y - enemy.transform.position.y);;

					shots.Add(shot,offset);
					Destroy (shot.gameObject,1f);
				}
			}
		}
	}

	public void UpdateHealthBar ()
	{
		if(hp <= maxHP){
			// Set the health bar's colour to proportion of the way between green and red based on the player's health.
			healthBar.material.color = Color.Lerp(Color.green, Color.red, 1 - hp * 0.01f);

			// Set the scale of the health bar to be proportional to the player's health.
			healthBar.transform.localScale = new Vector3(healthScale.x * hp * 0.01f, healthScale.y, 1);
		}
	}
}
