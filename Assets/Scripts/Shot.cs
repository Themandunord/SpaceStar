using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public int damage = 1;
	public bool isEnemyShot;
	public Animator anim;
	private Move move;
	private SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		move = GetComponent<Move> ();
		sprite = GetComponent<SpriteRenderer> ();
		Destroy (gameObject, 20);

		audio.Play ();
	}

	void FixedUpdate()
	{
		if(anim != null && anim.GetBool("Hit"))
			sprite.sortingLayerName = "OnPlayer";
	}

	public void setMovement(Move _move)
	{
		move.direction = _move.direction;
		move.speed = _move.speed;
		rigidbody2D.position += new Vector2 (0.2f, 0f);;
	}

	public void setPosition(Vector2 pos)
	{
		if(move != null) move.enabled = false;
		if(this != null) rigidbody2D.position = pos;
	}
}
