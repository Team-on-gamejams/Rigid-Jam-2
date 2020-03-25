using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using TMPro;

public class Player : MonoBehaviour {
	public static Player instance;

	public GameObject goPrefab;
	public GameObject currGo;
	public CinemachineVirtualCamera cam;

	List<Vector3> prevMousePos = new List<Vector3>(30);
	float posDelta = 0.0f;

	Camera main;

	public void NeedNew() {
		currGo.GetComponent<Rigidbody2D>().gravityScale = 1.0f;

			currGo = Instantiate(goPrefab, currGo.transform.position + Vector3.up * 5, Quaternion.identity);
		transform.SetParent(currGo.transform, false);
		currGo.GetComponent<Rigidbody2D>().gravityScale = 0.0f;
	}

	private void Awake() {
		instance = this;
		main = Camera.main;
		Cursor.lockState = CursorLockMode.Locked;
		transform.SetParent(currGo.transform, false);
	}

	private void Update() {
		if (Input.GetKeyDown(KeyCode.R)) {
			Application.LoadLevel(0);
		}
		else if (Input.GetKeyDown(KeyCode.R)) {
			Application.Quit();
		}

		Vector3 mouseMove = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
		if(mouseMove.magnitude >= 0.1f) {
			currGo.transform.position += mouseMove * Time.deltaTime * 75;
		}

		if (mouseMove.magnitude >= 0.01f)
			cam.m_Lens.OrthographicSize += Time.deltaTime * 6;
	}
}
