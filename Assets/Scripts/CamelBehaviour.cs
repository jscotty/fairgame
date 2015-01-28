using UnityEngine;
using System.Collections;

public class CamelBehaviour : MonoBehaviour {
	public float moveSpeed;
	public float score;
	public float countdown;
	private float dirY;
	private string P1Win = "P1WinScreen";
	private string P2Win = "P2WinScreen";

	void Update()
	{
		if (transform.position.y <= 3.19f) {
			dirY = 1f;	
		} else if (transform.position.y >= 3.6f) {
			dirY = -1f;	
		}

		if (countdown > 0)
		{
			//print("hoi");
			transform.Translate(new Vector3(-1f,0f,0f)* moveSpeed * Time.deltaTime);
			countdown -= 1;


			transform.Translate(new Vector3(0f,dirY,0f)* moveSpeed * Time.deltaTime);
		//	transform.Translate(new Vector3(0f,-1f,0f)* moveSpeed * Time.deltaTime);
		//	
			
		}

		if (transform.position.x <= -8.2) {
			if(name == "CamelP1"){
				Endscreen("P1");
			} else if(name == "CamelP2"){
				Endscreen("P2");
			}
		}
	}

	void Endscreen(string player){
		if (player == "P1")
						Application.LoadLevel (P1Win);
		else if (player == "P2")
						Application.LoadLevel (P2Win);
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "Finish")
        {
            print("winner!!");
            Destroy(gameObject);
        }
    }
}

