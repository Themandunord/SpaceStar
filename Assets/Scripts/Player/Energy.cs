using UnityEngine;
using System.Collections;

public class Energy : MonoBehaviour {

	// In percent
	public float energy = 0f;
	// EnergyBar for player;
	private SpriteRenderer energyBar;
	private Vector3 energyScale;
	
	// Use this for initialization
	void Start () {
		energyBar = GameObject.Find("EnergyBar").GetComponent<SpriteRenderer>();
		energyScale = energyBar.transform.localScale;

		UpdateEnergyBar ();
	}
	
	// Update is called once per frame
	void Update () {
		if(energy >= 100f)
			energy = 100f;
	}

	public void UpdateEnergyBar ()
	{
		if(energy <= 100f){
			// Set the scale of the energy bar to be proportional to the player's health.
			energyBar.transform.localScale = new Vector3(energyScale.x * energy * 0.01f, energyScale.y, 1);
		}
	}
}
