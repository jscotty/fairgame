using UnityEngine;
using System.Collections;

public class bulletBehaviour : MonoBehaviour {

	public float speed = 15f;
	public float counter = 3f;
	private float count;

	void Update () {
		transform.Translate (new Vector3 (1f,0f,0f) * speed * Time.deltaTime);
		count += Time.deltaTime;
		if (count >= counter) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (tag == "P1Bullet") {
			if (other.transform.tag == "P2") {
				other.transform.Translate(new Vector3(-1f,0f,0f)* 15f * Time.deltaTime);
				Destroy(gameObject);
			}
		} else if (tag == "P2Bullet") {
			if (other.transform.tag == "P1") {
				other.transform.Translate(new Vector3(-1f,0f,0f)* 15f * Time.deltaTime);
				Destroy(gameObject);
			}
		}

		if (other.transform.tag == "Ball") {
			Destroy(gameObject);
		}
	}
}
