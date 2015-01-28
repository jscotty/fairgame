using UnityEngine;
using System.Collections;

public class RotationScript : MonoBehaviour {
	
	private float rot = 0f;
	public float rotSpeed = 500f;
	private float rotS = 2f;

	void Update () {
		if (name == "RacketLeft") {
			rot = Input.GetAxis ("RightJoystickX");
		}else if (name == "RacketRight") {
			rot = Input.GetAxis ("RightJoystickX2");
		}

		if (transform.position.x <= -9) {
			transform.position = new Vector2(0,0);
		} else if (transform.position.x >= 9) {
			transform.position = new Vector2(0,0);	
		} else if (transform.position.y <= -4) {
			transform.position = new Vector2(0,0);
		} else if (transform.position.y >= 4) {
			transform.position = new Vector2(0,0);	
		}
		print (transform.position.y);
		transform.Rotate(new Vector3(0f,0f,rot) * -1 * rotSpeed * Time.deltaTime * rotS);
	}
}
