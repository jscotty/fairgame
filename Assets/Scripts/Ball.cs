using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public float speed = 2.0f;

    void Start() {
        rigidbody2D.velocity = Vector2.one.normalized * speed;
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
                Debug.Log("10 points to right");
                // 10 points to right
                break;
            case "20_left":
                Debug.Log("20 points to right");
                // 20 points to right
                break;
            case "30_left":
                Debug.Log("30 points to right");
                // 30 points to right
                break;

            case "10_right":
                Debug.Log("10 points to left");
                // 10 points to left
                break;
            case "20_right":
                Debug.Log("20 points to left");
                // 20 points to left
                break;
            case "30_right":
                Debug.Log("30 points to left");
                // 30 points to left
                break;
        }

    }


}