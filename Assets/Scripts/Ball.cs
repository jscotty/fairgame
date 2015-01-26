using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float speed = 2.0f;

    void Start() {
        Invoke("StartMovement", 3f);
    }

    void StartMovement() {
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
            case "RacketLeft":
                // Calculate hit Factor
                y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

                // Calculate direction, make length=1 via .normalized
                dir = new Vector2(1, y).normalized;
                rigidbody2D.velocity = dir * speed;
                break;
            case "RacketRight":
                // Calculate hit Factor
                y = hitFactor(transform.position, col.transform.position, col.collider.bounds.size.y);

                // Calculate direction, make length=1 via .normalized
                dir = new Vector2(-1, y).normalized;
                rigidbody2D.velocity = dir * speed;
                break;

            case "10_left":
                Destroy();
                Debug.Log("10 points to right");
                // 10 points to right
                break;
            case "20_left":
                Destroy();
                Debug.Log("20 points to right");
                // 20 points to right
                break;
            case "30_left":
                Destroy();
                Debug.Log("30 points to right");
                // 30 points to right
                break;

            case "10_right":
                Destroy();
                Debug.Log("10 points to left");
                // 10 points to left
                break;
            case "20_right":
                Destroy();
                Debug.Log("20 points to left");
                // 20 points to left
                break;
            case "30_right":
                Destroy();
                Debug.Log("30 points to left");
                // 30 points to left
                break;
        }

    }

    void Destroy() {
        transform.position = new Vector2(0f, 0f);
        rigidbody2D.velocity = new Vector2(0f, 0f);
        Invoke("StartMovement", 3);
    }


}