using UnityEngine;
using System.Collections;

public class FollowRotation : MonoBehaviour {

	public Transform target;
	public float rotationSpeed = 150f;

	void Start() {
		transform.position = target.position;
	}
	
	void Update () {
		transform.Rotate (Vector3.forward, rotationSpeed * Time.deltaTime);
		transform.position = Vector3.Lerp(transform.position,target.position, 0.1f);
	}
}
