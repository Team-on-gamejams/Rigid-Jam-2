using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;

public class Player : MonoBehaviour {
	public static Player instance;

	private void Awake() {
		instance = this;
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(0);
		}
		else if (Input.GetKeyDown(KeyCode.R)) {
			Application.Quit();
		}
	}
}
