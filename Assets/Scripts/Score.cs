﻿using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int score = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		guiText.text = "Score : " + score;
	}
}
