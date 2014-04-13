using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {

		Movement();
	}

	void Movement() {

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Translate (Vector2.right * 4f * Time.deltaTime);
			transform.eulerAngles = new Vector3(0,0,-10);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (-Vector2.right * 4f * Time.deltaTime);
			transform.eulerAngles = new Vector3(0,0,10);
		}
	}
}
