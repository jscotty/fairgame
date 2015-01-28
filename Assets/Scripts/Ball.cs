using UnityEngine;
using System.Collections;
using XInputDotNetPure;

public class Ball : MonoBehaviour {

    public float speed = 9.0f;
	private float randNum;
	private GameObject scoreCamel1;
	private GameObject scoreCamel2;

	public Transform shakeObject;
	private float shakecount;
	private float shakecountL;
	private float shakecountR;
	private float vibR;
	private float vibL;


    void Start() {
		collider2D.isTrigger = true;
		Invoke("StartMovement", 5f);

		scoreCamel1 = GameObject.FindWithTag ("CamelP1");
		scoreCamel2 = GameObject.FindWithTag ("CamelP2");
    }

	void Update(){
		speed += Time.deltaTime;

		if (shakecount <= 0f) {
			shakecount = 0f;	
			shakeObject.transform.position = new Vector3(0f, 0f, -10f);
		} else if( shakecount > 0f){
			shakecount -= 1.0f;
			GamePad.SetVibration(PlayerIndex.One,0f,2f);
			GamePad.SetVibration(PlayerIndex.Two,0f,2f);
			float randomNmX = Random.Range(-0.2f,0.2f);
			float randomNmY = Random.Range(-0.2f,0.2f);
			float randomNmZ = Random.Range(-9.2f,-10.2f);
			GamePad.SetVibration(PlayerIndex.One,0f,1f);
			GamePad.SetVibration(PlayerIndex.Two,0f,1f);
			
			shakeObject.transform.position = new Vector3(randomNmX, randomNmY, randomNmZ);
		}

		vibR -= 0.1f;
		if (vibR <= 0f) {
			vibR = 0f;	
		}
		GamePad.SetVibration(PlayerIndex.One,0f,vibL);

		vibL -= 0.1f;
		if (vibL <= 0f) {
			vibL = 0f;	
		}
		GamePad.SetVibration(PlayerIndex.Two,0f,vibR);
	}

	void StartMovement() {
		collider2D.isTrigger = false;
        rigidbody2D.velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(-1f, .1f));
        rigidbody2D.velocity = rigidbody2D.velocity.normalized * speed;
    }

    float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter2D(Collision2D col) {
        Vector2 dir;
        float y;

        switch (col.gameObject.tag) {
            case "P1":
			print("hit rackL");
                // Calculate hit Factor
                y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
				vibL = 1f;
                // Calculate direction, make length=1 via .normalized
                dir = new Vector2(1, y).normalized;
                rigidbody2D.velocity = dir * speed;
                break;
            case "P2":
				print("hit RackR");
                // Calculate hit Factor
                y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);
				vibR = 1f;
                // Calculate direction, make length=1 via .normalized
                dir = new Vector2(-1, y).normalized;
                rigidbody2D.velocity = dir * speed;
                break;

            case "10_left":
                Destroy();
				shakecount = 12f;
                Debug.Log("10 points to right");
				scoreCamel2.GetComponent<CamelBehaviour>().countdown += 10;
                // 10 points to right
                break;
            case "20_left":
                Destroy();
				shakecount = 32f;
                Debug.Log("20 points to right");
				scoreCamel2.GetComponent<CamelBehaviour>().countdown += 20;
                // 20 points to right
                break;
            case "30_left":
                Destroy();
				shakecount = 62f;
                Debug.Log("30 points to right");
				scoreCamel2.GetComponent<CamelBehaviour>().countdown += 30;
                // 30 points to right
                break;

            case "10_right":
                Destroy();
				shakecount = 12f;
                Debug.Log("10 points to left");
				scoreCamel1.GetComponent<CamelBehaviour>().countdown += 10;
                // 10 points to left
                break;
            case "20_right":
                Destroy();
				shakecount = 32f;
                Debug.Log("20 points to left");
				scoreCamel1.GetComponent<CamelBehaviour>().countdown += 20;
                // 20 points to left
                break;
            case "30_right":
                Destroy();

				shakecount = 62f;
                Debug.Log("30 points to left");
				scoreCamel1.GetComponent<CamelBehaviour>().countdown += 30;
                // 30 points to left
                break;
        }

    }

	void Destroy() {
		speed = 8.0f;
		randNum = Random.Range (-1.36f, 1.36f);
		transform.position = new Vector2(0f, randNum);
		rigidbody2D.velocity = new Vector2(0f, 0f);
		collider2D.isTrigger = true;
		Invoke("StartMovement", 5);

    }


}