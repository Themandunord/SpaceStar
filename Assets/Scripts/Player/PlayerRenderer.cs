using UnityEngine;
using System.Collections;

public class PlayerRenderer : MonoBehaviour {

	public bool CutScene = false;
	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		playerController = GetComponent<PlayerController> ();

		StartCoroutine ("movePlayerDuringCutScene");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}

	IEnumerator movePlayerDuringCutScene()
	{
		playerController.CutScene = true;
		yield return new WaitForSeconds(3f);
		playerController.CutScene = false;
		GameController.isStart = true;
	}
}
