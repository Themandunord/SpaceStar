using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {

	private SpriteRenderer sprite;
	private float fadeTime = 1.5f;
	private float alpha = 0;
	private Color endColor;
	private Color startColor;
	private bool isRendered = false;

	// Use this for initialization
	void Start () {
		sprite = this.GetComponent<SpriteRenderer> ();
		endColor = new Color (sprite.color.r,
		                      sprite.color.g,
		                      sprite.color.b,
		                      0);
		startColor = sprite.color;
	}
	
	// Update is called once per frame
	void Update () {

		if(alpha <= 1)
			alpha += Time.deltaTime / fadeTime;

		if(!isRendered)
			sprite.color = Color.Lerp (startColor, endColor, alpha);

	}

	public void activeFire()
	{
		sprite.color = startColor;
		isRendered = true;
	}
	
	public void deactiveFire()
	{
		if(alpha > 1 && isRendered)
			alpha = 0;
		isRendered = false;
	}
}
