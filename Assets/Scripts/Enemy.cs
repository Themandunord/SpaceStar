using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private Weapon weapon;
	public Move move;
	public BoxCollider2D box;
	public bool isDead = false;
	public Sprite[] sprites;

	// Use this for initialization
	void Awake () {
		move = GetComponent<Move> ();
		box = GetComponent<BoxCollider2D> ();
		weapon = GetComponent<Weapon> ();

		int index = Random.Range (0, sprites.Length);
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer> ();
		spriteRenderer.sprite = sprites [index];
	}
	
	// Update is called once per frame
	void Update () {
		if(weapon != null && weapon.CanAttack && !isDead)
		{
			weapon.Attack(true);
		}
	}
}
