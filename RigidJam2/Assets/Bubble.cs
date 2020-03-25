using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour {
	public bool isPlaced = false;
	bool isJoin = false;

	private void OnCollisionEnter2D(Collision2D collision) {
		if (isJoin)
			return;

		if(collision.transform.tag == "Bubble") {
			if(!isPlaced)
				Player.instance.NeedNew();

			FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
			joint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
			isJoin = true;
		}
	}
}
