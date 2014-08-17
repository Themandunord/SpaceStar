using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

	public float tumble;

	// Use this for initialization
	void Start () {
		rigidbody2D.angularVelocity = tumble * Random.insideUnitCircle.y;	
	}
}
